using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Hanzi2TGHZRibbon
{
    public partial class toneCorrectionForm : Form
    {
        private class onCharPinyin{
                public bool on{ get; set; }
                public string character{ get; set; }
                public string pinyin{ get; set; }

                public onCharPinyin(bool on, string character, string pinyin){
                     this.on = on; this.character = character; this.pinyin = pinyin;
                }
            }

        private List<onCharPinyin> _datalist;
        private BindingSource bindingSource;
        bool correctionson;

        private hanzi2tghz tghz;
        public toneCorrectionForm(ref hanzi2tghz tghz, bool correctionson)
        {
            this.correctionson = correctionson;
            this.tghz = tghz;
            InitializeComponent();
            _datalist = new List<onCharPinyin>();
            
            foreach(Tuple<string, bool, string> x in tghz.getCorrections())
                _datalist.Add(new onCharPinyin(x.Item2, x.Item1, x.Item3));
            
            bindingSource = new BindingSource();
            bindingSource.DataSource = _datalist;
            dataGridView.DataSource = bindingSource;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            //Validation checks
            pinyinBox.Text = pinyinBox.Text.Trim();
            charBox.Text = charBox.Text.Trim();
            int numchars = charBox.Text.Length;

            string[] splt = pinyinBox.Text.Split(new char[]{' '});

            if (numchars !=splt.Length)
            System.Windows.Forms.MessageBox.Show("There are " + numchars.ToString() + " characters in '" + charBox.Text
                + "', but " + splt.Length.ToString() + " pinyin word in '" + pinyinBox.Text 
                + "'. There should be an equal number of characters and space separated pinyin words.");
            else{
                bool hasnum = true;
                foreach (string s in splt)
                {
                    int tone;
                    if (!Int32.TryParse(s.Last().ToString(), out tone))
                        hasnum = false;
                    else if (tone < 1 || tone > 5)
                        hasnum = false;
                    if (hasnum == false)
                        System.Windows.Forms.MessageBox.Show("The last character of the pinyin word '" + s
                            + "' should be the number for the tone (1, 2, 3 or 4) or 5 for no tone.");
                }
                if (hasnum)
                {
                    bool exists = false;
                    foreach (onCharPinyin ocp in _datalist)
                        exists |= (charBox.Text == ocp.character && pinyinBox.Text == ocp.pinyin);

                    if (exists)
                        System.Windows.Forms.MessageBox.Show("This character pinyin combination already exists in the list.");
                    else
                        bindingSource.Add(new onCharPinyin(onBox.Checked, charBox.Text, pinyinBox.Text));                   
                }
            } 
        }

        private void done_Click(object sender, EventArgs e)
        {
            save();
            this.Close();
        }

        private List<Tuple<string, bool, string>> correctionsAsDict()
        {
            List<Tuple<string, bool, string>> corrections = new List<Tuple<string, bool, string>>();
            foreach (onCharPinyin ocp in _datalist)
                corrections.Add(new Tuple<string, bool, string>(ocp.character, ocp.on, ocp.pinyin));
            return corrections;
        }
        private void save()
        {
            tghz.updatecorrections(correctionsAsDict(), correctionson);
        }

        private void exportDictionaryCorrectionsFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.Desktop);
            saveFileDialog.AddExtension = true;
            saveFileDialog.Title = "Save Dictionary Correction File ...";
            saveFileDialog.FileName = "toneCorrections";
            saveFileDialog.Filter = "UTF8 Text File (*.txt)|*.txt";
            saveFileDialog.FilterIndex = 1;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                hanzi2tghz.saveCorrections(correctionsAsDict(), saveFileDialog.FileName);
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Convert.ToString(Environment.SpecialFolder.Desktop);
            openFileDialog.Title = "Load Dictionary Correction File ...";
            openFileDialog.FileName = "toneCorrections";
            openFileDialog.Filter = "UTF8 Text File (*.txt)|*.txt";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                foreach (Tuple<string, bool, string> x in hanzi2tghz.LoadToneCorrections(openFileDialog.FileName).Item2)
                {
                    bool exists = false;
                    foreach (onCharPinyin ocp in _datalist)
                        exists |= (x.Item1 == ocp.character && x.Item3 == ocp.pinyin);
                    
                    if(!exists) bindingSource.Add(new onCharPinyin(x.Item2, x.Item1, x.Item3));
                }
        }

    }
}
