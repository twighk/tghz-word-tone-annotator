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
    using Chinese = String;
    using Pinyin = List<PinyinChar?>;

    public partial class wordlistForm : Form
    {
        public wordlistForm()
        {
            InitializeComponent();
        }



        internal void BringToFront(ref hanzi2tghz tghz, string input, List<string> colors)
        {
            this.Show();
            this.BringToFront();
            textbox.Clear();

            List<Tuple<Chinese, List<Pinyin>>> hzpi = tghz.hanziWithPinyin(input);
            HashSet<Tuple<Chinese, List<Pinyin>>> set = new HashSet<Tuple<Chinese, List<Pinyin>>>(hzpi);

            foreach (Tuple<Chinese, List<Pinyin>> word in set)
            {
                if (word.Item2.Count != 0)
                {
                    foreach (Pinyin pinyin in word.Item2)
                    {
                        textbox.AppendText(word.Item1);
                        textbox.AppendText("\t");
                        foreach (PinyinChar pychar in pinyin)
                        {
                            Color colour = System.Drawing.ColorTranslator.FromHtml("#" + colors[pychar.tone - 1]);
                            textbox.SelectionColor = colour;
                            textbox.SelectedText = pychar.withDiacritic();
                            textbox.AppendText(" ");
                        }
                        textbox.AppendText("\n");
                    }
                }
            }
        }
    }
}
