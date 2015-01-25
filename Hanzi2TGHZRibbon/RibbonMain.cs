using System;
using Microsoft.Office.Tools.Ribbon;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Xml.Linq;

namespace Hanzi2TGHZRibbon
{
    public partial class RibbonMain
    {
        private hanzi2tghz tghz;
        toneCorrectionForm tcform;
        colorForm colorform;
        lookupForm luform;
        wordlistForm wlform;
        private readonly string dictpath = AppDomain.CurrentDomain.BaseDirectory + "\\cedict_ts.u8";

        private void RibbonMain_Load(object sender, RibbonUIEventArgs e)
        {
            tghz = new hanzi2tghz
                        ( dictpath
                        , Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\tghzToneCorrections.txt"
                        , AppDomain.CurrentDomain.BaseDirectory + "\\bopomofo.u8"
                        );
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                Version currentver = ApplicationDeployment.CurrentDeployment.CurrentVersion;
                vlabel.Label = string.Format("Version: {0}.{3}", currentver.Major, currentver.Minor, currentver.Build, currentver.Revision);
            }
            else
            {
                vlabel.Label = "Devel Version";
            }

            if (colorform == null || colorform.IsDisposed == true)
            {
                colorform = new colorForm();
            }
        }


        private static string convertlong(string xml, VbStrConv convert)
        {
            string output = "";
            const int buffersize = 10000;
            int length = xml.Length;
            for (int i = 0; i < length - buffersize; i += buffersize) // put it through in Chunks
                output += Strings.StrConv(xml.Substring(i, buffersize), convert);
            output += Strings.StrConv(xml.Substring(length - (length % buffersize), length % buffersize), convert); // last bit is < buffersize
            return output;
        }

        /* Converter Methods*/
        private void tradSimpConvert(VbStrConv convert)
        {
            Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;
            if (currentRange.Text == null)
                System.Windows.Forms.MessageBox.Show("Please select some text.");
            else
            {
                // don't use get_XML(), converts equations to pictures, use WordOpenXML               
                currentRange.InsertXML(convertlong(currentRange.WordOpenXML, convert));
            }
        }

        private void totradbutton_Click(object sender, RibbonControlEventArgs e)
        {
            tradSimpConvert(VbStrConv.TraditionalChinese);
        }

        private void tosimpbutton_Click(object sender, RibbonControlEventArgs e)
        {
            tradSimpConvert(VbStrConv.SimplifiedChinese);
        }

        /* Pinyin Tone Methods */
        private void pinyintones(Func<string, List<XAttribute>, XNamespace, bool, bool, List<string>, List<XElement>> function)
        {
            Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;
            try
            {
                if (currentRange.Text == null)
                    System.Windows.Forms.MessageBox.Show("Please select some text.");
                else
                {
                    string rangexml = currentRange.WordOpenXML;
                    XDocument doc = XDocument.Parse(rangexml);

                    XNamespace w = doc.Descendants().First(x => x.Name.LocalName == "document").Name.Namespace;

                    List<XElement> wts = doc.Descendants(w + "t").Where(x => 0 == x.Ancestors(w + "ruby").Count()).ToList();
                    foreach (XElement ele in wts) // w+"t" equivalent to "w:t"
                    {
                        if (0 == ele.Ancestors(w + "ruby").Count())
                        {
                            string text = ele.Value;
                            List<XAttribute> attributes = ele.Attributes().ToList();
                            List<XElement> tree = function(text, attributes, w, colorform.getTop(), colorform.getBottom(), colorform.getColors());
                            ele.ReplaceWith(tree);
                        }
                    }

/*
                    MatchCollection rubies = new Regex(@"(?<=<w:ruby>)(.*?)(?=<\/w:ruby>)").Matches(rangexml);
                    MatchCollection text = new Regex(@"(?<=<w:t>)(.*?)(?=<\/w:t>)").Matches(rangexml);

                    int rubiespos = rubies.Count - 1;
                    for (int t = text.Count - 1; t >= 0; t--)
                    {

                        for (; rubiespos >= 0; rubiespos--)
                        {
                            if (text[t].Index > rubies[rubiespos].Index) //find current ruby pos
                                break;
                        }

                        if (rubiespos < 0 || text[t].Index > rubies[rubiespos].Index + rubies[rubiespos].Length)
                        {
                            rangexml = rangexml.Remove(text[t].Index, text[t].Length);
                            rangexml = rangexml.Insert(text[t].Index,
                                        "</w:t></w:r>"
                                        + function(text[t].Value, colorform.getTop(), colorform.getBottom(), colorform.getColors())
                                        + "<w:r><w:t>");

                        }

                    }
                    */
                    currentRange.InsertXML(doc.ToString());
                }


                //Hack to prevent other east asian languages (See issue 5.)
                if (Globals.ThisAddIn.Application.ActiveDocument.Content.LanguageIDFarEast != Word.WdLanguageID.wdSimplifiedChinese)
                    Globals.ThisAddIn.Application.ActiveDocument.Content.LanguageIDFarEast = Word.WdLanguageID.wdSimplifiedChinese;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("There was an error(" + e.Message + "), please select less text to determine what it does not like");
            }
        }

        private void AddPinyin_Click(object sender, RibbonControlEventArgs e)
        {
            //pinyintones(tghz.withPinYinXML, brackets.Checked);
            pinyintones(tghz.withPinYinXMLRuby);
        }

        private void undobutton_Click(object sender, RibbonControlEventArgs e)
        {
            Globals.ThisAddIn.Application.ActiveDocument.Undo();
        }

        private void tonecorrectionbutton_Click(object sender, RibbonControlEventArgs e)
        {
            if (tcform == null || tcform.IsDisposed == true)
            {
                tcform = new toneCorrectionForm(ref tghz, dicton.Checked);
                tcform.Show();
            }
            else
            {
                tcform.BringToFront();
            }
        }

        private void resizepinyin_Click(object sender, RibbonControlEventArgs e)
        {
            Word.Selection currentSelection = Globals.ThisAddIn.Application.Selection;
            if (currentSelection.Start == currentSelection.End)
                currentSelection.MoveRight(Word.WdUnits.wdCharacter, 1, Word.WdMovementType.wdExtend);

            Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;

            string xmlstr = currentRange.WordOpenXML;

            xmlstr = Regex.Replace(xmlstr, @"<w:hpsRaise w:val=""\d*""\/>", "");

            string size = new Regex(@"(?<=<w:hpsBaseText w:val="")\d*").Match(xmlstr).Value;
            Double sz = Double.Parse(pysize.Text) * Double.Parse(size);
            xmlstr = Regex.Replace(xmlstr, @"(?<=<w:hps w:val="")\d*", Math.Round(sz, 1).ToString());
            currentRange.InsertXML(xmlstr);

        }

        private void AddTonesRuby_Click(object sender, RibbonControlEventArgs e)
        {
            pinyintones(tghz.withToneXMLRuby);
        }

        private void AddZhuyin_Click(object sender, RibbonControlEventArgs e)
        {
            pinyintones(tghz.withZhuyinXMLRuby);
        }

        private void ResizeTones_Click(object sender, RibbonControlEventArgs e)
        {
            Word.Selection currentSelection = Globals.ThisAddIn.Application.Selection;
            if (currentSelection.Start == currentSelection.End)
                currentSelection.MoveRight(Word.WdUnits.wdCharacter, 1, Word.WdMovementType.wdExtend);

            Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;

            currentRange.InsertXML(ToneResize(currentRange.WordOpenXML));
        }

        private string ToneResize(string xmlstr)
        {
            string size = new Regex(@"(?<=<w:hpsBaseText w:val="")\d*").Match(xmlstr).Value; // get text size

            xmlstr = Regex.Replace(xmlstr, @"(?<=<w:hpsRaise w:val="")\d*", toneheight.Text); // set raise

            Double sz = Double.Parse(tnsize.Text) * Double.Parse(size);
            xmlstr = Regex.Replace(xmlstr, @"(?<=<w:hps w:val="")\d*", Math.Round(sz, 1).ToString()); // set tone size

            return xmlstr;
        }

        private void edittnpy_Click(object sender, RibbonControlEventArgs e)
        {
            Word.Selection currentSelection = Globals.ThisAddIn.Application.Selection;
            if (currentSelection.Start == currentSelection.End)
                currentSelection.MoveRight(Word.WdUnits.wdCharacter, 1, Word.WdMovementType.wdExtend);
            new editForm().Show();
        }

        private void dicton_Click(object sender, RibbonControlEventArgs e)
        {
            tghz.makeMap(dicton.Checked);
        }

        private void remove_Click(object sender, RibbonControlEventArgs e)
        {
            Word.Selection currentSelection = Globals.ThisAddIn.Application.Selection;
            if (currentSelection.Start == currentSelection.End)
                currentSelection.MoveRight(Word.WdUnits.wdCharacter, 1, Word.WdMovementType.wdExtend);

            Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;

            string xmlstr = currentRange.WordOpenXML;

            MatchCollection rubies = new Regex(@"<w:ruby>.*?<\/w:ruby>").Matches(xmlstr);

            foreach (Match ruby in rubies)
            {
                xmlstr = Regex.Replace(xmlstr, ruby.Value, new Regex(@"<w:t>.*?<\/w:t>").Matches(ruby.Value)[1].Value);
            }

            currentRange.InsertXML(xmlstr);
        }

        private void py2tones_Click(object sender, RibbonControlEventArgs e)
        {
            // Get the range
            Word.Selection currentSelection = Globals.ThisAddIn.Application.Selection;
            if (currentSelection.Start == currentSelection.End)
                currentSelection.MoveRight(Word.WdUnits.wdCharacter, 1, Word.WdMovementType.wdExtend);
            Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;

            //convert 
            string xml = currentRange.WordOpenXML;
            List<hanzipytn> datalist = editForm.convert(hanzi2tghz.rubyXML2hanzistring(xml));
            foreach (hanzipytn a in datalist)
                a.pytn = new Regex(@"\d+").Match(a.pytn).Value;

            //unconvert
            currentRange.InsertXML(ToneResize(hanzi2tghz.XMLhanzistring2XML(xml, editForm.unconvert(datalist))));

        }

        private string getplaintext(string xmlstr)
        {
            // Remove phonetic guides
            MatchCollection rubies = new Regex(@"<w:ruby>.*?<\/w:ruby>").Matches(xmlstr);
            foreach (Match ruby in rubies)
            {
                xmlstr = Regex.Replace(xmlstr, ruby.Value, new Regex(@"<w:t>.*?<\/w:t>").Matches(ruby.Value)[1].Value);
            }

            // Get Text
            string text = "";
            MatchCollection texts = new Regex(@"<w:t>.*?<\/w:t>").Matches(xmlstr);
            foreach (Match t in texts)
            {
                text += t.Value.Replace(@"<w:t>", "").Replace(@"</w:t>", "");
            }
            return text;
        }

        /* Look Up words Methods */
        private void lookUp_Click(object sender, RibbonControlEventArgs e)
        {
            // Get the range
            Word.Selection currentSelection = Globals.ThisAddIn.Application.Selection;
            if (currentSelection.Start == currentSelection.End)
                currentSelection.MoveRight(Word.WdUnits.wdCharacter, 1, Word.WdMovementType.wdExtend);
            Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range.Duplicate;
            
            string text = getplaintext(currentRange.WordOpenXML);

            // Create the form if it doesn't exist
            if (luform == null || luform.IsDisposed == true)
            {
                luform = new lookupForm(dictpath);
                luform.Show();
            }

            luform.BringToFront(text);
         

        }

        private void color_Click(object sender, RibbonControlEventArgs e)
        {
            colorform.Show();
        }

        private void colorcheck_Click(object sender, RibbonControlEventArgs e)
        {
            colorform.Show();
        }

        private void wordlist_Click(object sender, RibbonControlEventArgs e)
        {
            Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;
            if (currentRange.Text == null)
                System.Windows.Forms.MessageBox.Show("Please select some text.");
            else
            {
                if (wlform == null || wlform.IsDisposed == true)
                {
                    wlform = new wordlistForm();
                    wlform.Show();
                }

                string text = getplaintext(currentRange.WordOpenXML);

                wlform.BringToFront(ref tghz, text, colorform.getColors(), tghz.zhuyin);
            }
        }

    }
}
