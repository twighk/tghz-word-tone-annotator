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
    public partial class colorForm : Form
    {
        public colorForm()
        {
            InitializeComponent();
            tone1.ForeColor = colortone1.Color;
            tone2.ForeColor = colortone2.Color;
            tone3.ForeColor = colortone3.Color;
            tone4.ForeColor = colortone4.Color;
            tone5.ForeColor = colortone5.Color;
        }
        public bool getTop()
        {
            return colortop.Checked;
        }

        public bool getBottom()
        {
            return colorchar.Checked;
        }

        public List<string> getColors()
        {
            List<string> output = new List<string>();
            output.Add(color2rgb(colortone1.Color));
            output.Add(color2rgb(colortone2.Color));
            output.Add(color2rgb(colortone3.Color));
            output.Add(color2rgb(colortone4.Color));
            output.Add(color2rgb(colortone5.Color));
            return output;
        }
        private string color2rgb(Color col)
        {
            return col.R.ToString("X2") + col.G.ToString("X2") + col.B.ToString("X2");
        }

        private void colorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void tone1_Click(object sender, EventArgs e)
        {
            colortone1.ShowDialog();
            tone1.ForeColor = colortone1.Color;
        }

        private void tone2_Click(object sender, EventArgs e)
        {
            colortone2.ShowDialog();
            tone2.ForeColor = colortone2.Color;
        }

        private void tone3_Click(object sender, EventArgs e)
        {
            colortone3.ShowDialog();
            tone3.ForeColor = colortone3.Color;
        }

        private void tone4_Click(object sender, EventArgs e)
        {
            colortone4.ShowDialog();
            tone4.ForeColor = colortone4.Color;
        }

        private void tone5_Click(object sender, EventArgs e)
        {
            colortone5.ShowDialog();
            tone5.ForeColor = colortone5.Color;
        }
    }
}
