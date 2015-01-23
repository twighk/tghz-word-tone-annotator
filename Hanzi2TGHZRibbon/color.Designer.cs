namespace Hanzi2TGHZRibbon
{
    partial class colorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.colortop = new System.Windows.Forms.CheckBox();
            this.colorchar = new System.Windows.Forms.CheckBox();
            this.colortone1 = new System.Windows.Forms.ColorDialog();
            this.colortone2 = new System.Windows.Forms.ColorDialog();
            this.colortone3 = new System.Windows.Forms.ColorDialog();
            this.colortone4 = new System.Windows.Forms.ColorDialog();
            this.colortone5 = new System.Windows.Forms.ColorDialog();
            this.tone1 = new System.Windows.Forms.Button();
            this.tone2 = new System.Windows.Forms.Button();
            this.tone4 = new System.Windows.Forms.Button();
            this.tone5 = new System.Windows.Forms.Button();
            this.tone3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.apply1 = new System.Windows.Forms.Button();
            this.apply2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.apply3 = new System.Windows.Forms.Button();
            this.apply4 = new System.Windows.Forms.Button();
            this.apply5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // colortop
            // 
            this.colortop.AutoSize = true;
            this.colortop.Location = new System.Drawing.Point(13, 13);
            this.colortop.Name = "colortop";
            this.colortop.Size = new System.Drawing.Size(117, 17);
            this.colortop.TabIndex = 0;
            this.colortop.Text = "Colour Tone/Pinyin";
            this.colortop.UseVisualStyleBackColor = true;
            // 
            // colorchar
            // 
            this.colorchar.AutoSize = true;
            this.colorchar.Location = new System.Drawing.Point(13, 37);
            this.colorchar.Name = "colorchar";
            this.colorchar.Size = new System.Drawing.Size(105, 17);
            this.colorchar.TabIndex = 1;
            this.colorchar.Text = "Colour Character";
            this.colorchar.UseVisualStyleBackColor = true;
            // 
            // colortone1
            // 
            this.colortone1.AnyColor = true;
            this.colortone1.Color = System.Drawing.Color.Red;
            this.colortone1.SolidColorOnly = true;
            // 
            // colortone2
            // 
            this.colortone2.AnyColor = true;
            this.colortone2.Color = System.Drawing.Color.Orange;
            this.colortone2.SolidColorOnly = true;
            // 
            // colortone3
            // 
            this.colortone3.AnyColor = true;
            this.colortone3.Color = System.Drawing.Color.Green;
            this.colortone3.SolidColorOnly = true;
            // 
            // colortone4
            // 
            this.colortone4.AnyColor = true;
            this.colortone4.Color = System.Drawing.Color.Blue;
            this.colortone4.SolidColorOnly = true;
            // 
            // colortone5
            // 
            this.colortone5.AnyColor = true;
            this.colortone5.Color = System.Drawing.Color.Gray;
            this.colortone5.SolidColorOnly = true;
            // 
            // tone1
            // 
            this.tone1.Location = new System.Drawing.Point(12, 83);
            this.tone1.Name = "tone1";
            this.tone1.Size = new System.Drawing.Size(75, 23);
            this.tone1.TabIndex = 2;
            this.tone1.Text = "Tone 1";
            this.tone1.UseVisualStyleBackColor = true;
            this.tone1.Click += new System.EventHandler(this.tone1_Click);
            // 
            // tone2
            // 
            this.tone2.Location = new System.Drawing.Point(12, 113);
            this.tone2.Name = "tone2";
            this.tone2.Size = new System.Drawing.Size(75, 23);
            this.tone2.TabIndex = 3;
            this.tone2.Text = "Tone 2";
            this.tone2.UseVisualStyleBackColor = true;
            this.tone2.Click += new System.EventHandler(this.tone2_Click);
            // 
            // tone4
            // 
            this.tone4.Location = new System.Drawing.Point(93, 83);
            this.tone4.Name = "tone4";
            this.tone4.Size = new System.Drawing.Size(75, 23);
            this.tone4.TabIndex = 4;
            this.tone4.Text = "Tone 4";
            this.tone4.UseVisualStyleBackColor = true;
            this.tone4.Click += new System.EventHandler(this.tone4_Click);
            // 
            // tone5
            // 
            this.tone5.Location = new System.Drawing.Point(93, 113);
            this.tone5.Name = "tone5";
            this.tone5.Size = new System.Drawing.Size(75, 23);
            this.tone5.TabIndex = 5;
            this.tone5.Text = "Tone 5";
            this.tone5.UseVisualStyleBackColor = true;
            this.tone5.Click += new System.EventHandler(this.tone5_Click);
            // 
            // tone3
            // 
            this.tone3.Location = new System.Drawing.Point(12, 142);
            this.tone3.Name = "tone3";
            this.tone3.Size = new System.Drawing.Size(75, 23);
            this.tone3.TabIndex = 6;
            this.tone3.Text = "Tone 3";
            this.tone3.UseVisualStyleBackColor = true;
            this.tone3.Click += new System.EventHandler(this.tone3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Manually Apply Colour:";
            // 
            // apply1
            // 
            this.apply1.Location = new System.Drawing.Point(13, 194);
            this.apply1.Name = "apply1";
            this.apply1.Size = new System.Drawing.Size(33, 33);
            this.apply1.TabIndex = 8;
            this.apply1.Text = "1";
            this.apply1.UseVisualStyleBackColor = true;
            this.apply1.Click += new System.EventHandler(this.apply1_Click);
            // 
            // apply2
            // 
            this.apply2.Location = new System.Drawing.Point(52, 194);
            this.apply2.Name = "apply2";
            this.apply2.Size = new System.Drawing.Size(34, 33);
            this.apply2.TabIndex = 9;
            this.apply2.Text = "2";
            this.apply2.UseVisualStyleBackColor = true;
            this.apply2.Click += new System.EventHandler(this.apply2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Edit Colours:";
            // 
            // apply3
            // 
            this.apply3.Location = new System.Drawing.Point(90, 194);
            this.apply3.Name = "apply3";
            this.apply3.Size = new System.Drawing.Size(34, 33);
            this.apply3.TabIndex = 11;
            this.apply3.Text = "3";
            this.apply3.UseVisualStyleBackColor = true;
            this.apply3.Click += new System.EventHandler(this.apply3_Click);
            // 
            // apply4
            // 
            this.apply4.Location = new System.Drawing.Point(130, 194);
            this.apply4.Name = "apply4";
            this.apply4.Size = new System.Drawing.Size(34, 33);
            this.apply4.TabIndex = 12;
            this.apply4.Text = "4";
            this.apply4.UseVisualStyleBackColor = true;
            this.apply4.Click += new System.EventHandler(this.apply4_Click);
            // 
            // apply5
            // 
            this.apply5.Location = new System.Drawing.Point(13, 233);
            this.apply5.Name = "apply5";
            this.apply5.Size = new System.Drawing.Size(34, 33);
            this.apply5.TabIndex = 13;
            this.apply5.Text = "5";
            this.apply5.UseVisualStyleBackColor = true;
            this.apply5.Click += new System.EventHandler(this.apply5_Click);
            // 
            // colorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(179, 278);
            this.Controls.Add(this.apply5);
            this.Controls.Add(this.apply4);
            this.Controls.Add(this.apply3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.apply2);
            this.Controls.Add(this.apply1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tone3);
            this.Controls.Add(this.tone5);
            this.Controls.Add(this.tone4);
            this.Controls.Add(this.tone2);
            this.Controls.Add(this.tone1);
            this.Controls.Add(this.colorchar);
            this.Controls.Add(this.colortop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "colorForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Colour";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.colorForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox colortop;
        private System.Windows.Forms.CheckBox colorchar;
        private System.Windows.Forms.ColorDialog colortone1;
        private System.Windows.Forms.ColorDialog colortone2;
        private System.Windows.Forms.ColorDialog colortone3;
        private System.Windows.Forms.ColorDialog colortone4;
        private System.Windows.Forms.ColorDialog colortone5;
        private System.Windows.Forms.Button tone1;
        private System.Windows.Forms.Button tone2;
        private System.Windows.Forms.Button tone4;
        private System.Windows.Forms.Button tone5;
        private System.Windows.Forms.Button tone3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button apply1;
        private System.Windows.Forms.Button apply2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button apply3;
        private System.Windows.Forms.Button apply4;
        private System.Windows.Forms.Button apply5;
    }
}