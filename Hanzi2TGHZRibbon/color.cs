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
    public partial class colorForm : Form
    {
        private void setFormColors()
        {
            tone1.ForeColor = colortone1.Color;
            tone2.ForeColor = colortone2.Color;
            tone3.ForeColor = colortone3.Color;
            tone4.ForeColor = colortone4.Color;
            tone5.ForeColor = colortone5.Color;
            apply1.ForeColor = colortone1.Color;
            apply2.ForeColor = colortone2.Color;
            apply3.ForeColor = colortone3.Color;
            apply4.ForeColor = colortone4.Color;
            apply5.ForeColor = colortone5.Color;
        }

        public colorForm()
        {
            InitializeComponent();
            setFormColors();
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
            setFormColors();
        }

        private void tone2_Click(object sender, EventArgs e)
        {
            colortone2.ShowDialog();
            setFormColors();
        }

        private void tone3_Click(object sender, EventArgs e)
        {
            colortone3.ShowDialog();
            setFormColors();
        }

        private void tone4_Click(object sender, EventArgs e)
        {
            colortone4.ShowDialog();
            setFormColors();
        }

        private void tone5_Click(object sender, EventArgs e)
        {
            colortone5.ShowDialog();
            setFormColors();
        }

        private void colorText(ColorDialog colortone)
        {
            Word.Selection currentSelection = Globals.ThisAddIn.Application.Selection;
            if (currentSelection.Start == currentSelection.End)
                currentSelection.MoveRight(Word.WdUnits.wdCharacter, 1, Word.WdMovementType.wdExtend);

            currentSelection.Range.Font.TextColor.RGB = colortone.Color.R << 0 | colortone.Color.G << 8 | colortone.Color.B << 16 ; // BGR
        }

        private void apply1_Click(object sender, EventArgs e)
        {
            colorText(colortone1);
        }

        private void apply2_Click(object sender, EventArgs e)
        {
            colorText(colortone2);
        }

        private void apply3_Click(object sender, EventArgs e)
        {
            colorText(colortone3);
        }

        private void apply4_Click(object sender, EventArgs e)
        {
            colorText(colortone4);
        }

        private void apply5_Click(object sender, EventArgs e)
        {
            colorText(colortone5);
        }


    }
}
