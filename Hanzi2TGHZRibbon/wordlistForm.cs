using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hanzi2TGHZRibbon
{
    public partial class wordlistForm : Form
    {
        public wordlistForm()
        {
            InitializeComponent();
        }

        internal void BringToFront(ref hanzi2tghz tghz, string input)
        {
            this.Show();
            this.BringToFront();
            textbox.Clear();

            List<Tuple<string, List<string>>> hzpi = tghz.hanziWithPinyin(input);
            HashSet<Tuple<string, List<string>>> set = new HashSet<Tuple<string, List<string>>>(hzpi);

            foreach (Tuple<string, List<string>> word in set)
            {
                if (word.Item2.Count != 0)
                {
                    textbox.AppendText(word.Item1);
                    textbox.AppendText("\t");
                    foreach (string str in word.Item2)
                    {
                        textbox.SelectionColor = Color.Red;
                        textbox.SelectedText = (str);
                        
                        textbox.AppendText(" ");
                    }
                    textbox.AppendText("\n");
                }
            }
        }
    }
}
