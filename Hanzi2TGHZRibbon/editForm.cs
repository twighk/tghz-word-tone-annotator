using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace Hanzi2TGHZRibbon
{
    public partial class editForm : Form
    {
        private List<hanzipytn> _datalist;
        private BindingSource bindingSource;
        private Word.Range currentRange;
        private string xml;

        public static List<hanzipytn> convert (List<Tuple<string,string>> input){
            List<hanzipytn> output = new List<hanzipytn>();
            foreach(Tuple<string,string> a in input)
                output.Add(new hanzipytn(a.Item1, a.Item2));
            return output;
        }

        public static List<Tuple<string, string>> unconvert(List<hanzipytn> input)
        {
            List<Tuple<string, string>> output = new List<Tuple<string, string>>();
            foreach (hanzipytn a in input)
                output.Add(new Tuple<string,string> (a.hanzi, a.pytn));
            return output;
        }

        public editForm()
        {
            InitializeComponent();
            currentRange = Globals.ThisAddIn.Application.Selection.Range.Duplicate;
            xml = currentRange.WordOpenXML;
            _datalist = convert(hanzi2tghz.rubyXML2hanzistring(xml));

            bindingSource = new BindingSource();
            bindingSource.DataSource = _datalist;
            dataGridView.DataSource = bindingSource;
        }

        private void done_Click(object sender, EventArgs e)
        {
            currentRange.InsertXML(hanzi2tghz.XMLhanzistring2XML(xml, unconvert(_datalist)));
            this.Close();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }

    public class hanzipytn
    {
        public string hanzi { get; set; }
        public string pytn { get; set; }

        public hanzipytn(string hanzi, string pytn)
        {
            this.hanzi = hanzi; this.pytn = pytn;
        }
    }

}
