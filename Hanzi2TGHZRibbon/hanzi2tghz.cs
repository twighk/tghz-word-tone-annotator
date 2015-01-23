using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Hanzi2TGHZRibbon
{
    public class hanzi2tghz
    {
        private static readonly short[] accent = { 713, 714, 711, 715, 729 };
        private static readonly string[] toneorder = { "a", "o", "e", "i", "u", "v", "" };
        private static readonly string[] tones = { "āáǎàa", "ōóǒòo", "ēéěèe", "īíǐìi", "ūúǔùu", "ǖǘǚǜü", accent2string() }; // aoeiuv
        private static readonly string[] ctones = { "ĀÁǍÀA", "ŌÓǑÒO", "ĒÉĚÈE", "ĪÍǏÌI", "ŪÚǓÙU", "ǕǗǙǛÜ", accent2string() }; // aoeiuv
        private static readonly char gap = '\u2009';
        //private static readonly short[] accent = { 772, 769, 711, 768, 775 };
        private int longestword;
        private Dictionary<string, List<string>> map; // character, list of pinyin
        private Dictionary<string, string> zhuyin;
        private readonly string dictpath;
        private readonly string tonepath;
        private readonly string zypath;


        private static string accent2string()
        {
            string output = "";
            foreach (short c in accent)
                output += (char)c;
            return output;
        }

        public hanzi2tghz(string dictionarypath, string tonecorrectionpath, string zhuyinpath)
        {
            dictpath = System.IO.Path.GetFullPath(dictionarypath);
            tonepath = System.IO.Path.GetFullPath(tonecorrectionpath);
            zypath = System.IO.Path.GetFullPath(zhuyinpath);
            makeMap(false);
            makeZhuyin();
        }

        private void makeZhuyin()
        {
            zhuyin= new Dictionary<string,string>();
            try
            {
                FileStream fin = new FileStream(zypath, FileMode.Open);
                StreamReader stream = new StreamReader(fin, Encoding.UTF8);
                string line;
                while ((line = stream.ReadLine()) != null) // Read through the Text file
                {
                    if (line.Length > 0 && line[0] != '#') //ignore commented lines and off lines
                    {
                        string[] dictline = line.Split(new char[] { '\t' });// split line on tabs
                        zhuyin.Add(dictline[0].Trim(), dictline[1].Trim());
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                System.Windows.Forms.MessageBox.Show("bopomofo.u8 could not be found at '" + Path.GetFullPath(zypath)
                    + "'. FileNotFoundException (" + e.Message + ") Thrown.");
            }
        }

        private static Tuple<int, Dictionary<string, List<string>>> LoadDicionary(string dictionarypath)
        {
            Dictionary<string, List<string>> dictout = new Dictionary<string, List<string>>();
            int lenghtout = 0;
            try
            {
                FileStream fin = new FileStream(dictionarypath, FileMode.Open);
                StreamReader stream = new StreamReader(fin, Encoding.UTF8);
                string line;
                while ((line = stream.ReadLine()) != null) // Read through the Text file
                {
                    if (line.Length > 0 && line[0] != '#') //ignore commented lines and off lines
                    {
                        string[] dictline = line.Split(new char[] { ' ' });// split line on spaces
                        string simp = dictline[0];
                        string trad = dictline[1];

                        lenghtout = Math.Max(simp.Length, lenghtout); // Find the Longest word

                        string pinyin = ""; // make string of pinyin
                        for (int i = 0; i != simp.Length; i++)
                            pinyin += dictline[2 + i] + " ";
                        pinyin = pinyin.Trim(); //clean off trailing space

                        foreach (string simptrad in new string[] { simp, trad })
                        { // add it to the Map
                            if (!dictout.ContainsKey(simptrad))
                                dictout.Add(simptrad, new List<string>(new string[] { pinyin }));
                            else
                                if (!dictout[simptrad].Contains(pinyin))
                                    dictout[simptrad].Add(pinyin);
                        }
                    }
                }
                fin.Close();
            }
            catch (FileNotFoundException e)
            {
                System.Windows.Forms.MessageBox.Show("Dictionary could not be found at '" + Path.GetFullPath(dictionarypath)
                    + "'. FileNotFoundException (" + e.Message + ") Thrown.");
            }

            return new Tuple<int, Dictionary<string, List<string>>>(lenghtout, dictout);

        }

        public static Tuple<int, List<Tuple<string, bool, string>>> LoadToneCorrections(string tonecorrectionpath)
        {
            List<Tuple<string, bool, string>> dictout = new List<Tuple<string, bool, string>>();
            int lenghtout = 0;

            if (File.Exists(tonecorrectionpath))
            {
                FileStream fin = new FileStream(tonecorrectionpath, FileMode.Open);
                StreamReader stream = new StreamReader(fin, Encoding.UTF8);
                string line;
                while ((line = stream.ReadLine()) != null) // Read through the Text file
                {

                    if (line.Length > 0 && line[0] != '#') //ignore commented lines and off lines
                    {
                        bool on = true;
                        if (line[0] == '!')
                        { // turned off
                            on = false;
                            line = line.TrimStart('!');
                        }

                        string[] dictline = line.Split(new char[] { ' ' });// split line on spaces
                        string character = dictline[0];


                        string pinyin = ""; // make string of pinyin
                        for (int i = 0; i != character.Length; i++)
                            pinyin += dictline[1 + i] + " ";
                        pinyin = pinyin.Trim(); //clean off trailing space

                        dictout.Add(new Tuple<string, bool, string>(character, on, pinyin));
                    }
                }
                fin.Close();
            }
            return new Tuple<int, List<Tuple<string, bool, string>>>(lenghtout, dictout);
        }

        public static void saveCorrections(List<Tuple<string, bool, string>> corrections, string filepath, bool hidden = true)
        {
            try
            {
                if(File.Exists(filepath))
                    File.SetAttributes(filepath, File.GetAttributes(filepath) & ~FileAttributes.Hidden);
                FileStream fout = new FileStream(filepath, FileMode.Create);
                StreamWriter stream = new StreamWriter(fout, Encoding.UTF8);
                stream.AutoFlush = true;
                stream.WriteLine("# File that forces the tones for character combinations");

                foreach (Tuple<string, bool, string> cop in corrections)
                {
                    string output = "";
                    if (!cop.Item2) output += "!";
                    output += cop.Item1;
                    output += " ";
                    output += cop.Item3;
                    stream.WriteLine(output);
                }
                stream.Flush();
                fout.Close();
                if (hidden)
                    File.SetAttributes(filepath, File.GetAttributes(filepath) | FileAttributes.Hidden);
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Problem saving the corrections file to  '" + Path.GetFullPath(filepath)
                    + "'. (" + e.Message + ") Thrown.");
            }
        }

        public void updatecorrections(List<Tuple<string, bool, string>> corrections, bool enabled)
        {
            saveCorrections(corrections, tonepath);
            makeMap(enabled);
        }

        Dictionary<string, List<string>> corrections2dict(List<Tuple<string, bool, string>> corr)
        {
            Dictionary<string, List<string>> output = new Dictionary<string, List<string>>();

            foreach (Tuple<string, bool, string> x in corr)
                if (x.Item2)
                    if (output.ContainsKey(x.Item1))
                        output[x.Item1].Add(x.Item3);
                    else
                        output.Add(x.Item1, new List<string>(new string[] { x.Item3 }));

            return output;
        }

        public void makeMap(bool usecorrections)
        {
            Tuple<int, Dictionary<string, List<string>>> dict = LoadDicionary(dictpath);
            map = dict.Item2;
            longestword = dict.Item1;

            if (usecorrections)
            {
                Tuple<int, List<Tuple<string, bool, string>>> corrections = LoadToneCorrections(tonepath);

                longestword = Math.Max(dict.Item1, corrections.Item1);


                Dictionary<string, List<string>> correctionsmap = corrections2dict(corrections.Item2);

                foreach (KeyValuePair<string, List<string>> x in correctionsmap)
                    if (map.ContainsKey(x.Key))
                        map[x.Key] = x.Value;
                    else
                        map.Add(x.Key, x.Value);
            }
        }

        public List<Tuple<string, bool, string>> getCorrections()
        {
            return LoadToneCorrections(tonepath).Item2;
        }


        public static List<List<T>> Transpose<T>(List<List<T>> lists)
        {
            var longest = lists.Any() ? lists.Max(l => l.Count) : 0;
            List<List<T>> outer = new List<List<T>>(longest);
            for (int i = 0; i < longest; i++)
                outer.Add(new List<T>());
            for (int j = 0; j < lists.Count; j++)
                for (int i = 0; i < longest; i++)
                    outer[i].Add(lists[j].Count > i ? lists[j][i] : default(T));
            return outer;
        }

        public string withToneXMLRuby(string input, bool topcolor = false, bool bottomcolor = false, List<string> colors = null)
        //superflous bools to match withpiyinxml type
        {
            List<Tuple<string, List<string>>> hzpi = hanziWithPinyin(input);
            string output = "";
            foreach (Tuple<string, List<string>> c in hzpi)
                if (c.Item2.Count == 0)
                    output += withNone(c.Item1);
                else
                {
                    for (int i = 0; i != c.Item1.Length; i++)
                    {
                        output += withRubyTones(c.Item1[i].ToString(), Transpose(str2tones(c.Item2))[i],topcolor,bottomcolor,colors);
                    }
                }

            return output ;
        }


        public string withPinYinXMLRuby(string input, bool topcolor = false, bool bottomcolor = false, List<string> colors = null)
        {
            List<Tuple<string, List<string>>> hzpi = hanziWithPinyin(input);
            string output = "";
            foreach (Tuple<string, List<string>> c in hzpi)
                if (c.Item2.Count == 0)
                    output += withNone(c.Item1);
                else
                    foreach (string pi in c.Item2)
                    {
                        string pi2 = pi;
                        pi2 = pi.Trim(new char[] { '[', ']' });
                        string[] splt = pi2.Split(new char[] { ' ' });
                        for (int i = 0; i != c.Item1.Length; i++)
                        {
                            int tone;
                            splt[i] = num2tonegraphs(splt[i], out tone);
                            output += withRuby(c.Item1[i].ToString(), splt[i],tone,topcolor,bottomcolor,colors);
                        }
                    }
            return output;
        }

        public string withZhuyinXMLRuby(string input, bool topcolor = false, bool bottomcolor = false, List<string> colors = null)
        {
            string output = "";
            List<Tuple<string, List<string>>> hzpi = hanziWithPinyin(input);
            foreach (Tuple<string, List<string>> c in hzpi)
                if (c.Item2.Count == 0)
                    output += withNone(c.Item1);
                else
                {
                    HashSet<string> items = new HashSet<string>();
                    foreach (string pi in c.Item2)
                    {
                        string item = pi.ToLower();
                        if (!items.Contains(item))
                        {
                            items.Add(item);
                            string pi2 = item;
                            pi2 = item.Trim(new char[] { '[', ']' });
                            string[] splt = pi2.Split(new char[] { ' ' });
                            for (int i = 0; i != c.Item1.Length; i++)
                            {
                                int tone;
                                splt[i] = pinyin2fuyin(splt[i], out tone);
                                output += withRuby(c.Item1[i].ToString(), splt[i], tone, topcolor, bottomcolor, colors);
                            }
                        }
                    }
                }
            return output;
        }
        public string pinyin2fuyin(string str, out int t)
        {
            t = -1;
            if (str != null)
            {
                string tone = Regex.Match(str, @"\d+").Value; //Get tone number
                if (tone != "")
                {
                    str = str.Replace(tone, "");
                    t = Int32.Parse(tone) - 1;
                    if (zhuyin.ContainsKey(str))
                        str = zhuyin[str];
                    if (t >= 0 && t <= 4)
                    {
                        str += tones[6][t];
                    }
                    else
                    {
                        t = -1;
                    }
                }
            }
            return str;
        }
        public static string num2tonegraphs(string str, out int t)
        {
            t = -1;
            if (str != null)
            {
                string tone = Regex.Match(str, @"\d+").Value; //Get tone number
                if (tone != "")
                {
                    str = str.Replace(tone, "");
                    t = Int32.Parse(tone) - 1;
                    //System.Console.WriteLine(t);
                    if (t >= 0 && t <= 4)
                    {
                        if (str.Contains('a'))
                            str = str.Replace('a', tones[0][t]);
                        else if (str.Contains('A'))
                            str = str.Replace('A', ctones[0][t]);
                        else if (str.Contains('o'))
                            str = str.Replace('o', tones[1][t]);
                        else if (str.Contains('O'))
                            str = str.Replace('O', ctones[1][t]);
                        else if (str.Contains('e'))
                            str = str.Replace('e', tones[2][t]);
                        else if (str.Contains('E'))
                            str = str.Replace('E', ctones[2][t]); // words cannot start with an i (->y) or u (->w)
                        else if (str.Contains("iu"))
                            str = str.Replace("u", tones[4][t].ToString());
                        else if (str.Contains("iu:")
                              || str.Contains("iv"))
                        {
                            str = str.Replace("u:", tones[5][t].ToString());
                            str = str.Replace("v", tones[5][t].ToString());
                        }
                        else if (str.Contains('i'))
                            str = str.Replace('i', tones[3][t]);
                        else if (str.Contains('u'))
                            str = str.Replace('u', tones[4][t]);
                        else if (str.Contains("u:")
                              || str.Contains("v"))
                        {
                            str = str.Replace("u:", tones[5][t].ToString());
                            str = str.Replace("v", tones[5][t].ToString());
                        }
                        else if (str.Contains("U:")
                             || str.Contains("V"))
                        {
                            str = str.Replace("U:", ctones[5][t].ToString());
                            str = str.Replace("V", ctones[5][t].ToString());
                        }
                        else
                            str += tones[6][t].ToString();
                    }
                    else
                    {
                        t = -1;
                    }
                }
            }
            return str;
        }

        public List<List<int>> str2tones(List<string> str)
        {
            List<List<int>> output = new List<List<int>>();

            foreach (string s in str)
            {
                List<int> tl = new List<int>();
                foreach (string tones in s.TrimEnd().Split(new char[] { ' ' }))
                    tl.Add(pinyin2tone(tones));

                bool exists = false;
                foreach (List<int> test in output)
                    exists |= Enumerable.SequenceEqual(test, tl);
                if (!exists)
                    output.Add(tl);
            }

            return output;
        }

        public List<Tuple<string, List<string>>> hanziWithPinyin(string strin)
        {
            List<Tuple<string, List<string>>> output = new List<Tuple<string, List<string>>>();

            for (int strptr = 0, numchartest = 0; strptr < strin.Length; strptr += numchartest)
            {
                for (numchartest = Math.Min(longestword, strin.Length - strptr)
                    ; numchartest != 0; numchartest--
                    ) // Find the Longest string in the dictionary then add it to the output with the pinyin
                {
                    string findchar = strin.Substring(strptr, numchartest);
                    List<string> ret;
                    if (map.TryGetValue(findchar, out ret))
                    {
                        output.Add(new Tuple<string, List<string>>(findchar, map[findchar]));
                        break;
                    }
                }

                if (numchartest == 0) // If single char not in dictionary add just the character
                {
                    output.Add(new Tuple<string, List<string>>(strin[strptr].ToString(), new List<string>()));
                    numchartest = 1;
                }
            }
            return output;
        }

        private static int pinyin2tone(string pinyin)
        {
            return Int32.Parse(Regex.Match(pinyin, @"\d+").Value); //Get tone number
        }

        public static string withNone(string str)
        {
            string output = "";
            output += "<w:r><w:t xml:space=\"preserve\">";
            output += str;
            output += "</w:t></w:r>";
            return output;

        }

        public static string withRuby(string bottom, string top, int tone, bool topcolour = false, bool bottomcolour = false, List<string> colors = null)
        {
            string output = "";
            output += "<w:r><w:ruby><w:rubyPr><w:rubyAlign w:val=\"center\"/></w:rubyPr><w:rt><w:r>";
            output += "<w:rPr>";
            output += "<w:rFonts w:ascii=\"Arial Unicode MS\" w:eastAsia=\"Arial Unicode MS\" w:hAnsi=\"Arial Unicode MS\" w:cs=\"Arial Unicode MS\" w:hint=\"eastAsia\"/>";
            if (topcolour && !(colors == null) && tone != -1)
            {
                output += "<w:color w:val=\"" + colors[tone] + "\"/>";
            }
            output += "</w:rPr>";
            output += "<w:t xml:space=\"preserve\">";
            output += gap + top + gap;
            output += "</w:t></w:r></w:rt><w:rubyBase><w:r>";
            output += "<w:rPr>";
            if (bottomcolour && !(colors == null) && tone != -1)
            {
                output += "<w:color w:val=\"" + colors[tone] + "\"/>";
            }
            output += "</w:rPr>";
            output += "<w:t>";
            output += bottom;
            output += "</w:t></w:r></w:rubyBase></w:ruby></w:r>";
            //output += "<w:r><w:t xml:space=\"preserve\"> </w:t></w:r>"; // Space
            return output;
        }

        public static string withRubyTones(string bottom, List<int> tones, bool topcolour = false, bool bottomcolour = false, List<string> colors = null)
        {
            string output = "";
            output += "<w:r><w:ruby><w:rubyPr><w:rubyAlign w:val=\"center\"/><w:hps w:val=\"24\"/><w:hpsRaise w:val=\"10\"/><w:hpsBaseText w:val=\"12\"/></w:rubyPr><w:rt><w:r>";
            output += "<w:rPr>";
            output += "<w:rFonts w:ascii=\"Arial Unicode MS\" w:eastAsia=\"Arial Unicode MS\" w:hAnsi=\"Arial Unicode MS\" w:cs=\"Arial Unicode MS\" w:hint=\"eastAsia\"/>";
            if (topcolour && !(colors ==null) && tones.Count==1)
            {
                output += "<w:color w:val=\"" + colors[tones[0]-1] + "\"/>";
            }
            output += "</w:rPr><w:t>"; // <w:sz w:val=\"11\"/>
            foreach (int t in tones)
                output += "&#" + accent[t - 1].ToString() + ";";
           output += "</w:t></w:r></w:rt><w:rubyBase><w:r>";
            output += "<w:rPr>";
            if (bottomcolour && !(colors == null) && tones.Count == 1)
            {
                output += "<w:color w:val=\"" + colors[tones[0]-1] + "\"/>";
            }
            output += "</w:rPr>";
            output += "<w:t>";
            output += bottom;
            output += "</w:t></w:r></w:rubyBase></w:ruby></w:r>";
            return output;
        }

        private static string tonegraphs2num(string str)
        {
            string output = "";
            string[] words = str.Trim().Split(new char[] { ' ' });
            for (int w = 0; w != words.Count(); w++)
            {
                int i;
                while((i = words[w].IndexOfAny(tones[6].ToCharArray())) != -1){ // look for tones only and convert to chars
                    for (int tn = 0; tn != tones[6].Length; tn++)
                        words[w] = words[w].Replace(tones[6][tn].ToString(), (1 + tn).ToString());
                }

                for (int letter = 0; letter != toneorder.Length; letter++)
                    for (int tn = 0; tn != tones[letter].Length; tn++)
                    {
                        if (words[w].Contains(tones[letter][tn]) && (tn != 4 || letter == 6)) // only do letters with tones unless its not a letter only tone
                            words[w] += (1 + tn).ToString();
                        words[w] = words[w].Replace(tones[letter][tn].ToString(), toneorder[letter].ToString());
                    }
                output += words[w] + " ";
            }

            return output.TrimEnd();
        }

        public static List<Tuple<string, string>> rubyXML2hanzistring(string xml)
        {
            List<Tuple<string, string>> output = new List<Tuple<string, string>>();

            //split into ruby environment
            MatchCollection rubies = new Regex(@"(?<=<w:ruby>)(.*?)(?=<\/w:ruby>)").Matches(xml);

            foreach (Match ruby in rubies)
            {
                MatchCollection tnpyhanzi = new Regex(@"(?<=<w:t>)(.*?)(?=<\/w:t>)").Matches(ruby.Value);
                string tone = tonegraphs2num(tnpyhanzi[0].Value.Trim(new char[] { ' ', gap }));
                string hanzi = tnpyhanzi[1].Value.Trim();
                output.Add(new Tuple<string, string>(hanzi, tone));
            }

            return output;
        }

        public static string XMLhanzistring2XML(string xml, List<Tuple<string, string>> list)
        {
            MatchCollection rubies = new Regex(@"(?<=<w:ruby>)(.*?)(?=<\/w:ruby>)").Matches(xml);
            for (int i = rubies.Count - 1; i >= 0; i--) // Count down so position of matches further in xml are not changed
            {
                string match = rubies[i].Value;
                if (list[i].Item2 != "")
                {
                    MatchCollection tnpyhanzi = new Regex(@"(?<=<w:t>)(.*?)(?=<\/w:t>)").Matches(match);// Find tone/pinyin & characters
                    // Change characters
                    match = match.Remove(tnpyhanzi[1].Index, tnpyhanzi[1].Length);
                    match = match.Insert(tnpyhanzi[1].Index, list[i].Item1);

                    // Change tone/pinyin
                    match = match.Remove(tnpyhanzi[0].Index, tnpyhanzi[0].Length);

                    string tnpy = "";
                    int tmp;
                    if (Int32.TryParse(list[i].Item2, out tmp))
                    {
                        foreach (char num in list[i].Item2.Trim())
                            if (Int32.Parse(num.ToString()) < accent.Length + 1)
                                tnpy += (char)accent[Int32.Parse(num.ToString()) - 1];
                    }
                    else{
                        int tone;
                        tnpy += gap + num2tonegraphs(list[i].Item2, out tone) + gap;
                    }

                    match = match.Insert(tnpyhanzi[0].Index, tnpy);
                } else {
                    match = @"<w:t>" + list[i].Item1 + "</w:t>)";
                }

                //fix xml
                xml = xml.Remove(rubies[i].Index, rubies[i].Length);
                xml = xml.Insert(rubies[i].Index, match);
                
            }


            return xml;
        }


/*
        public static readonly string xmlFooter = @"</w:p></w:body></w:document></pkg:xmlData></pkg:part></pkg:package>";

        public static readonly string xmlHeader = @"
<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<?mso-application progid=""Word.Document""?>
<pkg:package xmlns:pkg=""http://schemas.microsoft.com/office/2006/xmlPackage"">
  <pkg:part pkg:name=""/_rels/.rels"" pkg:contentType=""application/vnd.openxmlformats-package.relationships+xml"">
    <pkg:xmlData>
      <Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships"">
        <Relationship Id=""rId1"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"" Target=""word/document.xml""/>
      </Relationships>
    </pkg:xmlData>
  </pkg:part>
  <pkg:part pkg:name=""/word/_rels/document.xml.rels"" pkg:contentType=""application/vnd.openxmlformats-package.relationships+xml"">
    <pkg:xmlData>
      <Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships"" />
    </pkg:xmlData>
  </pkg:part>
  <pkg:part pkg:name=""/word/document.xml"" pkg:contentType=""application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml"">
    <pkg:xmlData>
      <w:document xmlns:m=""http://schemas.openxmlformats.org/officeDocument/2006/math"" xmlns:w=""http://schemas.openxmlformats.org/wordprocessingml/2006/main"">
        <w:body>
            <w:p>
".Replace(Environment.NewLine, "");

*/
    }
}
