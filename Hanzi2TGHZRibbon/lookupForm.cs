using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Hanzi2TGHZRibbon
{
    public partial class lookupForm : Form
    {
        private Dictionary<string, HashSet<string>> dict = new Dictionary<string, HashSet<string>>();
        private BindingSource bindingSource = new BindingSource();
        private List<dictline> output = new List<dictline>();
        private int longest = 0;

        public lookupForm(string dictpath)
        {
            InitializeComponent();

            // Read the dictionary into dict
            if (dict.Count == 0)
            {
                try
                {
                    FileStream fin = new FileStream(dictpath, FileMode.Open);
                    StreamReader stream = new StreamReader(fin, Encoding.UTF8);
                    string line;
                    while ((line = stream.ReadLine()) != null) // Read through the Text file
                    {
                        if (line.Length > 0 && line[0] != '#') //ignore commented lines and off lines
                        {
                            string[] dictline = line.Split(new char[] { ' ' });// split line on spaces
                            string simp = dictline[0];
                            string trad = dictline[1];
                            longest = Math.Max(longest, Math.Max(simp.Length, trad.Length));

                            foreach (string simptrad in new string[] { simp, trad })
                            { // add it to the Map
                                if (!dict.ContainsKey(simptrad))
                                    dict.Add(simptrad, new HashSet<string>(new string[] { line }));
                                else
                                    dict[simptrad].Add(line);
                            }
                        }
                    }
                    fin.Close();
                }
                catch (FileNotFoundException e)
                {
                    System.Windows.Forms.MessageBox.Show("Dictionary could not be found at '" + Path.GetFullPath(dictpath)
                        + "'. FileNotFoundException (" + e.Message + ") Thrown.");
                }
            }
            //setup the datagridview
            bindingSource.DataSource = output;
            dataGridView.DataSource = bindingSource;
        }

        internal void BringToFront(string strin)
        {
            this.Show();
            this.BringToFront();

            //output.Clear();
            //bindingSource.Add(new dictline("Words", dict.Count.ToString()));
            bindingSource.Clear();
            for (int strptr = 0; strptr < strin.Length; strptr++)
            {
                bool found = false;

                for (int numchartest = Math.Min(longest, strin.Length - strptr)
                    ; numchartest != 0; numchartest--
                    ) // Find the Longest string in the dictionary then add it to the output with the pinyin
                {
                    string findchar = strin.Substring(strptr, numchartest);
                    HashSet<string> ret;
                    if (dict.TryGetValue(findchar, out ret))
                    {
                        foreach(string str in ret)
                            bindingSource.Add(new dictline(findchar, str));
                        found = true;
                    }
                }

                if (!found && 
                    !( Char.IsSymbol(strin[strptr]) 
                    || Char.IsSeparator(strin[strptr])
                    || Char.IsPunctuation(strin[strptr])
                    )
                   ) // If single char not in dictionary add just the character
                {
                    bindingSource.Add(new dictline(strin[strptr].ToString(), "Character not found in dictionary."));
                }
            }
            // Update Datagridview
            dataGridView.Refresh();
        }

        private void lookupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true; // this cancels the close event.
        }

    }

    public class dictline
    {
        public string cchar { get; set; }
        public string line { get; set; }

        public dictline(string cchar, string line)
        {
            this.cchar = cchar; this.line = line;
        }
    }
}
