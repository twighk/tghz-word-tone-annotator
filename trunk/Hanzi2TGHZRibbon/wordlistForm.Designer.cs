namespace Hanzi2TGHZRibbon
{
    partial class wordlistForm
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
            this.textbox = new System.Windows.Forms.RichTextBox();
            this.insTblButton = new System.Windows.Forms.Button();
            this.pinyinradio = new System.Windows.Forms.RadioButton();
            this.Zhuyinradio = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // textbox
            // 
            this.textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textbox.Location = new System.Drawing.Point(12, 12);
            this.textbox.Margin = new System.Windows.Forms.Padding(12);
            this.textbox.Name = "textbox";
            this.textbox.Size = new System.Drawing.Size(260, 238);
            this.textbox.TabIndex = 0;
            this.textbox.Text = "";
            // 
            // insTblButton
            // 
            this.insTblButton.Location = new System.Drawing.Point(12, 265);
            this.insTblButton.Name = "insTblButton";
            this.insTblButton.Size = new System.Drawing.Size(260, 23);
            this.insTblButton.TabIndex = 1;
            this.insTblButton.Text = "Insert as table into Word.";
            this.insTblButton.UseVisualStyleBackColor = true;
            this.insTblButton.Click += new System.EventHandler(this.insTblButton_Click);
            // 
            // pinyinradio
            // 
            this.pinyinradio.AutoSize = true;
            this.pinyinradio.Checked = true;
            this.pinyinradio.Location = new System.Drawing.Point(12, 295);
            this.pinyinradio.Name = "pinyinradio";
            this.pinyinradio.Size = new System.Drawing.Size(53, 17);
            this.pinyinradio.TabIndex = 2;
            this.pinyinradio.TabStop = true;
            this.pinyinradio.Text = "Pinyin";
            this.pinyinradio.UseVisualStyleBackColor = true;
            this.pinyinradio.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // Zhuyinradio
            // 
            this.Zhuyinradio.AutoSize = true;
            this.Zhuyinradio.Location = new System.Drawing.Point(138, 295);
            this.Zhuyinradio.Name = "Zhuyinradio";
            this.Zhuyinradio.Size = new System.Drawing.Size(55, 17);
            this.Zhuyinradio.TabIndex = 3;
            this.Zhuyinradio.Text = "Zhuyn";
            this.Zhuyinradio.UseVisualStyleBackColor = true;
            this.Zhuyinradio.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // wordlistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 324);
            this.Controls.Add(this.Zhuyinradio);
            this.Controls.Add(this.pinyinradio);
            this.Controls.Add(this.insTblButton);
            this.Controls.Add(this.textbox);
            this.Name = "wordlistForm";
            this.Text = "WordList";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox textbox;
        private System.Windows.Forms.Button insTblButton;
        private System.Windows.Forms.RadioButton pinyinradio;
        private System.Windows.Forms.RadioButton Zhuyinradio;


    }
}