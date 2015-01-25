using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Hanzi2TGHZRibbon
{
    using Pinyin = List<PinyinChar?>;
    using Chinese = String;

    public struct PinyinChar
    {
        public string pinyin;
        public int tone; // 1 to 5
        public PinyinChar(string py, int t)
        {
            pinyin = py;
            tone = t;
        }

        public string withDiacritic()
        {
            string str = pinyin;
            int t = tone - 1;

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
            return str;
        }

        public string toZhuYin(Dictionary<string, string> zhuyin){
            string zyout = "";
            string py = pinyin.ToLower();

            if (zhuyin.ContainsKey(py))
                zyout = zhuyin[py];
            if (tone >= 1 && tone <= 5)
            {
                zyout += tones[6][tone-1];
            }
            return zyout;
        }

        private static readonly short[] accent = { 713, 714, 711, 715, 729 };
        private static readonly string[] tones = { "āáǎàa", "ōóǒòo", "ēéěèe", "īíǐìi", "ūúǔùu", "ǖǘǚǜü", accent2string() }; // aoeiuv
        private static readonly string[] ctones = { "ĀÁǍÀA", "ŌÓǑÒO", "ĒÉĚÈE", "ĪÍǏÌI", "ŪÚǓÙU", "ǕǗǙǛÜ", accent2string() }; // aoeiuv
        //private static readonly short[] accent = { 772, 769, 711, 768, 775 };

        private static string accent2string()
        {
            string output = "";
            foreach (short c in accent)
                output += (char)c;
            return output;
        }

    }


    public class hanzi2tghz
    {

        private int longestword;
        private Dictionary<Chinese, List<Pinyin>> map; // character, list of pinyin
        public  Dictionary<string, string> zhuyin;
        private readonly string dictpath;
        private readonly string tonepath;
        private readonly string zypath;

        private static readonly char gap = '\u2009';
        private static readonly string[] toneorder = { "a", "o", "e", "i", "u", "v", "" };

// WARNING Duplicated in PinyinChar struct
        private static readonly short[] accent = { 713, 714, 711, 715, 729 };
        private static readonly string[] tones  = { "āáǎàa", "ōóǒòo", "ēéěèe", "īíǐìi", "ūúǔùu", "ǖǘǚǜü", accent2string() }; // aoeiuv
        private static readonly string[] ctones = { "ĀÁǍÀA", "ŌÓǑÒO", "ĒÉĚÈE", "ĪÍǏÌI", "ŪÚǓÙU", "ǕǗǙǛÜ", accent2string() }; // aoeiuv
        
        private static string accent2string()
        {
            string output = "";
            foreach (short c in accent)
                output += (char)c;
            return output;
        }
// End of WARNING

        
        


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
            zhuyin = new Dictionary<string,string>();
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

        private static Tuple<int, Dictionary<Chinese, List<Pinyin>>> LoadDicionary(string dictionarypath)
        {
            Dictionary<Chinese, List<Pinyin>> dictout = new Dictionary<Chinese, List<Pinyin>>();
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
                        Chinese simp = dictline[0];
                        Chinese trad = dictline[1];

                        lenghtout = Math.Max(simp.Length, lenghtout); // Find the Longest word

                        string CEpinyin = ""; // make string of pinyin
                        for (int i = 0; i != simp.Length; i++)
                            CEpinyin += dictline[2 + i] + " ";

                        Pinyin pinyin = CEdictpinyin2pinyin(CEpinyin);
                        foreach (string simptrad in new string[] { simp, trad })
                        { // add it to the Map
                            if (!dictout.ContainsKey(simptrad))
                            {
                                dictout.Add(simptrad, new List<Pinyin>());
                                dictout[simptrad].Add(pinyin);
                            } 
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

            return new Tuple<int, Dictionary<Chinese, List<Pinyin>>>(lenghtout, dictout);

        }

        private static Pinyin CEdictpinyin2pinyin(String CEpinyin)
        {
            Pinyin pinyinout = new Pinyin();
            CEpinyin = CEpinyin.Trim(); //clean off trailing space
            CEpinyin = CEpinyin.Trim(new char[] { '[', ']' }); // remove initial and final []
            
            string[] words = CEpinyin.Split(new char[] { ' ' }); // Split on spaces to get {"ni3", "hao3"}

            foreach (string s in words)
            {
                string tone = Regex.Match(s, @"\d+").Value; //Get tone number
                if (tone != "") 
                    pinyinout.Add(new PinyinChar(s.Replace(tone, ""), Int32.Parse(tone)));
                else
                    pinyinout.Add(null);
            }

            return pinyinout;
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

        Dictionary<Chinese, List<Pinyin>> corrections2dict(List<Tuple<string, bool, string>> corr)
        {
            Dictionary<Chinese, List<Pinyin>> output = new Dictionary<Chinese, List<Pinyin>>();

            foreach (Tuple<string, bool, string> x in corr)
            {
                Chinese chinese = x.Item1;
                Pinyin pinyin = CEdictpinyin2pinyin(x.Item3);
                bool enabled = x.Item2;
                if (enabled)
                    if (output.ContainsKey(chinese))
                        output[chinese].Add(pinyin);
                    else
                        output.Add(chinese, new List<Pinyin>(){pinyin});
            }

            return output;
        }

        public void makeMap(bool usecorrections)
        {
            Tuple<int, Dictionary<Chinese, List<Pinyin>>> dict = LoadDicionary(dictpath);
            map = dict.Item2;
            longestword = dict.Item1;

            if (usecorrections)
            {
                Tuple<int, List<Tuple<string, bool, string>>> corrections = LoadToneCorrections(tonepath);

                longestword = Math.Max(dict.Item1, corrections.Item1);


                Dictionary<Chinese, List<Pinyin>> correctionsmap = corrections2dict(corrections.Item2);

                foreach (KeyValuePair<Chinese, List<Pinyin>> x in correctionsmap)
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

        public List<XElement> withToneXMLRuby(string input, List<XAttribute> tattributes, XNamespace w, bool topcolor = false, bool bottomcolor = false, List<string> colors = null)
        //superflous bools to match withpiyinxml type
        {
            List<XElement> tree = new List<XElement>();
            List<Tuple<Chinese, List<Pinyin>>> hzpi = hanziWithPinyin(input);
            foreach (Tuple<Chinese, List<Pinyin>> c in hzpi)
            {
                if (c.Item2.Count == 0)
                    tree.Add(withNone(c.Item1,tattributes,w));
                else
                {
                    for (int i = 0; i != c.Item1.Length; i++)
                    {
                        char chinesechar = c.Item1[i];
                        HashSet<int> tones = new HashSet<int>();
                        for (int j = 0; j != c.Item2.Count; j++)
                        {
                            Pinyin pinyin = c.Item2[j];
                            if (pinyin[i].HasValue)
                                tones.Add(pinyin[i].Value.tone);
                        }

                        tree.Add(withRubyTones(tattributes, w, chinesechar.ToString(), tones.ToList(), topcolor, bottomcolor, colors));
                    }
                }
            }

            return tree;
        }


        public List<XElement> withPinYinXMLRuby(string input, List<XAttribute> tattributes, XNamespace w, bool topcolor = false, bool bottomcolor = false, List<string> colors = null)
        {
            List<XElement> tree = new List<XElement>();
            List<Tuple<Chinese, List<Pinyin>>> hzpi = hanziWithPinyin(input);

            foreach (Tuple<Chinese, List<Pinyin>> c in hzpi)
                if (c.Item2.Count == 0)
                    tree.Add(withNone(c.Item1,tattributes,w));
                else
                    foreach (Pinyin pinyin in c.Item2)
                       for (int i = 0; i != c.Item1.Length; i++)
                           if (pinyin[i].HasValue)
                               tree.Add(withRuby(tattributes, w,
                                   c.Item1[i].ToString(), pinyin[i].Value.withDiacritic(), pinyin[i].Value.tone,
                                   topcolor, bottomcolor, colors));
                           else
                               tree.Add(withNone(c.Item1[i].ToString(),tattributes,w));

            return tree;
        }

        public List<XElement> withZhuyinXMLRuby(string input, List<XAttribute> tattributes, XNamespace w, bool topcolor = false, bool bottomcolor = false, List<string> colors = null)
        {
            List<XElement> tree = new List<XElement>();
            List<Tuple<Chinese, List<Pinyin>>> hzpi = hanziWithPinyin(input);

            foreach (Tuple<Chinese, List<Pinyin>> c in hzpi)
                if (c.Item2.Count == 0)
                    tree.Add(withNone(c.Item1,tattributes,w));
                else
                {
                    HashSet<string> items = new HashSet<string>();
                    foreach (Pinyin pinyin in c.Item2)
                    {
                        List<string> zhuyin = pinyin2zhuyin(pinyin);
                        string zhuyinstring = zhuyin.Aggregate((i, j) => i + " " + j);

                        if (!items.Contains(zhuyinstring))
                        {
                            items.Add(zhuyinstring);
                            for (int i = 0; i != c.Item1.Length; i++)
                                if (pinyin[i].HasValue)
                                    tree.Add(withRuby(
                                        tattributes, w,
                                        c.Item1[i].ToString(), zhuyin[i], pinyin[i].Value.tone,
                                        topcolor, bottomcolor, colors));
                                else
                                    tree.Add(withNone(c.Item1[i].ToString(),tattributes,w));
                        }
                    }
                }
            return tree;
        }

        private List<String> pinyin2zhuyin(Pinyin pinyin)
        {
            List<String> lsout = new List<String>();

            foreach(PinyinChar? pc in pinyin)
                if (pc.HasValue)
                    lsout.Add(pc.Value.toZhuYin(zhuyin));
                else
                    lsout.Add("");

            return lsout;
        }

        public List<Tuple<Chinese, List<Pinyin>>> hanziWithPinyin(string strin)
        {
            List<Tuple<Chinese, List<Pinyin>>> output = new List<Tuple<Chinese, List<Pinyin>>>();

            for (int strptr = 0, numchartest = 0; strptr < strin.Length; strptr += numchartest)
            {
                for (numchartest = Math.Min(longestword, strin.Length - strptr)
                    ; numchartest != 0; numchartest--
                    ) // Find the Longest string in the dictionary then add it to the output with the pinyin
                {
                    string findchar = strin.Substring(strptr, numchartest);
                    List<Pinyin> ret;
                    if (map.TryGetValue(findchar, out ret))
                    {
                        output.Add(new Tuple<Chinese, List<Pinyin>>(findchar, map[findchar]));
                        break;
                    }
                }

                if (numchartest == 0) // If single char not in dictionary add just the character
                {
                    output.Add(new Tuple<Chinese, List<Pinyin>>(strin[strptr].ToString(), new List<Pinyin>()));
                    numchartest = 1;
                }
            }
            return output;
        }

        public static XElement withNone(string str, List<XAttribute> tattributes, XNamespace w)
        {
            return
                new XElement(w + "r",
                    new XElement(w + "t", str, tattributes)
                );
        }

        public static XElement withRuby(List<XAttribute> tattributes, XNamespace w, string bottom, string topstr, int tone, bool topcolour = false, bool bottomcolour = false, List<string> colors = null)
        {
            XElement rubyPr = new XElement(w + "rubyPr",
                new XElement(w + "rubyAlign", new XAttribute(w + "val", "center"))
                );

            XElement tcolour = new XElement(w + "color");
            if (topcolour && !(colors == null))
            {
                tcolour.SetAttributeValue(w + "val", colors[tone - 1]);
            }

            XElement top = new XElement(w + "rt",
                new XElement(w + "r",
                    new XElement(w + "rPr",
                        new XElement(w + "rFonts",
                            new XAttribute(w + "ascii", "Arial Unicode MS"),
                            new XAttribute(w + "eastAsia", "Arial Unicode MS"),
                            new XAttribute(w + "hAnsi", "Arial Unicode MS"),
                            new XAttribute(w + "cs", "Arial Unicode MS"),
                            new XAttribute(w + "hint", "eastAsia")
                        ),
                        tcolour
                    ),
                    new XElement(w + "t", gap + topstr + gap)
                )
            );

            XElement bcolour = new XElement(w + "color");
            if (bottomcolour && !(colors == null))
            {
                bcolour.SetAttributeValue(w + "val", colors[tone - 1]);
            }

            XElement bot = new XElement(w + "rubyBase",
                new XElement(w + "r",
                    new XElement(w + "rPr",
                        bcolour
                    ),
                    new XElement(w + "t", bottom)
                )
            );

            return new XElement(w + "r",
                new XElement(w + "ruby",
                    rubyPr,
                    top,
                    bot
                )
            );
        }

        public static XElement withRubyTones(List<XAttribute> tattributes, XNamespace w, string bottom, List<int> tones, bool topcolour = false, bool bottomcolour = false, List<string> colors = null)
        {
            XElement rubyPr = new XElement(w + "rubyPr",
                new XElement(w + "rubyAlign", new XAttribute(w + "val", "center")),
                new XElement(w + "hps", new XAttribute(w + "val", "24")),
                new XElement(w + "hpsRaise", new XAttribute(w + "val", "10")),
                new XElement(w + "hpsBaseText", new XAttribute(w + "val", "12"))
                );

            string tonesoutput = "";
            foreach (int t in tones)
                tonesoutput += ctones[6][t - 1].ToString();

            XElement tcolour = new XElement(w + "color");
            if (topcolour && !(colors == null) && tones.Count == 1)
            {
                tcolour.SetAttributeValue(w+"val", colors[tones[0] - 1]);
            }

            XElement top = new XElement(w + "rt",
                new XElement(w + "r",
                    new XElement(w + "rPr",
                        new XElement(w + "rFonts",
                            new XAttribute(w + "ascii", "Arial Unicode MS"),
                            new XAttribute(w + "eastAsia", "Arial Unicode MS"),
                            new XAttribute(w + "hAnsi", "Arial Unicode MS"),
                            new XAttribute(w + "cs", "Arial Unicode MS"),
                            new XAttribute(w + "hint", "eastAsia")
                        ),
                        tcolour
                    ),
                    new XElement(w + "t", tonesoutput)
                )
            );

            XElement bcolour = new XElement(w + "color");
            if (bottomcolour && !(colors == null) && tones.Count == 1)
            {
                bcolour.SetAttributeValue(w + "val", colors[tones[0] - 1]);
            }

            XElement bot = new XElement(w + "rubyBase",
                new XElement(w + "r",
                    new XElement(w + "rPr",
                        bcolour
                    ),
                    new XElement(w + "t", bottom)
                )
            );

            return new XElement(w+"r",
                new XElement(w+"ruby",
                    rubyPr,
                    top,
                    bot
                )
            );
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
                        PinyinChar? pc = CEdictpinyin2pinyin(list[i].Item2)[0];
                        if (pc.HasValue)
                            tnpy += gap + pc.Value.withDiacritic() + gap;
                        else
                            tnpy += gap + gap;
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
    }
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
