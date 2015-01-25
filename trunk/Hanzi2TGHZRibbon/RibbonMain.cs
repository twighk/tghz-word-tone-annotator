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
                currentRange.Select();
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
        private void pinyintones(Func<string, List<XAttribute>, List<XElement>, XNamespace, bool, bool, List<string>, List<XElement>> function)
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
                            List <XElement> properties = new List<XElement>();
                            foreach (XElement p in ele.Parent.Descendants(w+"rPr"))
                                properties.AddRange(p.Descendants());
                            
                            string text = ele.Value;
                            List<XAttribute> attributes = ele.Attributes().ToList();
                            List<XElement> tree = function(text, attributes, properties, w,
                                colorform.getTop(), colorform.getBottom(), colorform.getColors()
                                );
                            ele.ReplaceWith(tree);
                        }
                    }

                    currentRange.InsertXML(doc.ToString());
                    currentRange.Select();
                    
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
            pinyintones(tghz.withPinYinXMLRuby);
            resizepinyin_Click(sender, e);
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

            string rangexml = currentRange.WordOpenXML;
            XDocument doc = XDocument.Parse(rangexml);
            XNamespace w = doc.Descendants().First(x => x.Name.LocalName == "document").Name.Namespace;

            List<XElement> elements = doc.Descendants(w+"ruby").ToList();
            foreach (XElement ele in elements)
            {
                ele.Descendants(w + "hpsRaise").Remove(); // Remove lowering (e.g. if tone)
                string size = ele.Descendants(w + "hpsBaseText").Single().Attribute(w + "val").Value;
                if (0 < ele.Descendants(w + "rubyBase").Single().Descendants(w + "sz").Count())
                    size = ele.Descendants(w + "rubyBase").Single().Descendants(w + "sz").First().Attribute(w + "val").Value;
                ele.Descendants(w+"hpsBaseText").Single().SetAttributeValue(w+"val",size);
                Double sz = Double.Parse(pysize.Text) * Double.Parse(size);
                ele.Descendants(w+"hps").Single().Attribute(w+"val").SetValue(Math.Round(sz, 1).ToString());
            }

            currentRange.InsertXML(doc.ToString());
            currentRange.Select();
        }

        private void AddTonesRuby_Click(object sender, RibbonControlEventArgs e)
        {
            pinyintones(tghz.withToneXMLRuby);
            ResizeTones_Click(sender, e);
        }

        private void AddZhuyin_Click(object sender, RibbonControlEventArgs e)
        {
            pinyintones(tghz.withZhuyinXMLRuby);
            resizepinyin_Click(sender, e);
        }

        private void ResizeTones_Click(object sender, RibbonControlEventArgs e)
        {
            Word.Selection currentSelection = Globals.ThisAddIn.Application.Selection;
            if (currentSelection.Start == currentSelection.End)
                currentSelection.MoveRight(Word.WdUnits.wdCharacter, 1, Word.WdMovementType.wdExtend);

            Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;

            currentRange.InsertXML(ToneResize(currentRange.WordOpenXML));
            currentRange.Select();
        }

        private string ToneResize(string xmlstr)
        {
            XDocument doc = XDocument.Parse(xmlstr);
            XNamespace w = doc.Descendants().First(x => x.Name.LocalName == "document").Name.Namespace;

            foreach (XElement ele in doc.Descendants(w + "ruby"))
            {
                ele.Descendants(w + "hpsRaise").Single().Attribute(w+"val").SetValue(toneheight.Text);
                string size = ele.Descendants(w + "hpsBaseText").Single().Attribute(w + "val").Value;
                if (0 < ele.Descendants(w + "rubyBase").Single().Descendants(w + "sz").Count())
                    size = ele.Descendants(w + "rubyBase").Single().Descendants(w + "sz").First().Attribute(w + "val").Value;
                Double sz = Double.Parse(tnsize.Text) * Double.Parse(size);
                ele.Descendants(w + "hps").Single().Attribute(w + "val").SetValue(Math.Round(sz, 1).ToString());
            }
            return doc.ToString();
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
            XDocument doc = XDocument.Parse(xmlstr);
            XNamespace w = doc.Descendants().First(x => x.Name.LocalName == "document").Name.Namespace;
            List<XElement> elements = doc.Descendants(w + "ruby").ToList();
            foreach (XElement ele in elements)
            {

                List<XElement> tproperties = ele.Descendants(w + "rubyBase").Single().Descendants(w + "rPr").ToList();
                XElement t = ele.Descendants(w + "rubyBase").Single().Descendants(w + "t").Single();
                ele.ReplaceWith(tproperties, t);
            }

            currentRange.InsertXML(doc.ToString());
            currentRange.Select();
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
            currentRange.Select();
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
