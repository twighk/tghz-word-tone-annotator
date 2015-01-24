using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

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

        HashSet<Tuple<Chinese, List<Pinyin>>> set;
        List<string> colours;
        private Dictionary<string, string> zhuyindict;

        private void makeTable()
        {
            textbox.Clear();
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
                            Color colour = System.Drawing.ColorTranslator.FromHtml("#" + colours[pychar.tone - 1]);
                            textbox.SelectionColor = colour;
                            if (pinyinradio.Checked)
                                textbox.SelectedText = pychar.withDiacritic();
                            else
                                textbox.SelectedText = pychar.toZhuYin(zhuyindict);
                            textbox.AppendText(" ");
                        }
                        textbox.AppendText("\n");
                    }
                }
            }
        }

        internal void BringToFront(ref hanzi2tghz tghz, string input, List<string> colors, Dictionary <string,string> zydict)
        {
            this.Show();
            this.BringToFront();
            this.TopMost = true;
            colours = colors;

            List<Tuple<Chinese, List<Pinyin>>> hzpi = tghz.hanziWithPinyin(input);
            set = new HashSet<Tuple<Chinese, List<Pinyin>>>(hzpi);
            zhuyindict = zydict;

            makeTable();
        }

        private void insTblButton_Click(object sender, EventArgs e)
        {
            Word.UndoRecord undorecord = Globals.ThisAddIn.Application.UndoRecord;
            undorecord.StartCustomRecord("Add WordList as Table");
            {

                Word.Range currentRange = Globals.ThisAddIn.Application.Selection.Range;
                Word.Table tbl = currentRange.Tables.Add(currentRange, 1, 2);

                int i = 0;
                foreach (Tuple<Chinese, List<Pinyin>> word in set)
                {
                    i++; tbl.Rows.Add(); // Add a second Empty extra row
                    foreach (Pinyin pinyin in word.Item2)
                    {
                        tbl.Cell(i, 1).Range.Text = word.Item1;
                        tbl.Cell(i, 1).PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto;
                        Word.Range rng = tbl.Cell(i, 2).Range;
                        foreach (PinyinChar pychar in pinyin)
                        {
                            if (pinyinradio.Checked)
                                rng.Text = pychar.withDiacritic() + " ";
                            else
                                rng.Text = pychar.toZhuYin(zhuyindict) + " ";
                            Color colour = System.Drawing.ColorTranslator.FromHtml("#" + colours[pychar.tone - 1]);
                            rng.Font.TextColor.RGB = colour.B * 0x010000 + colour.G * 0x0100 + colour.R;
                            rng.Start = rng.End - 1;
                        }
                    }
                }

                tbl.Rows[i + 1].Delete(); // Delete Extra Last row
                tbl.Columns.DistributeWidth();
            }
            undorecord.EndCustomRecord();
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            makeTable();
        }
    }
}