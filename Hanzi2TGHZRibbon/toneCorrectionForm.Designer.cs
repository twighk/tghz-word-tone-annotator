namespace Hanzi2TGHZRibbon
{
    partial class toneCorrectionForm
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.on = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.character = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pinyin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportDictionaryCorrectionsFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.charBox = new System.Windows.Forms.TextBox();
            this.onBox = new System.Windows.Forms.CheckBox();
            this.pinyinBox = new System.Windows.Forms.TextBox();
            this.Add = new System.Windows.Forms.Button();
            this.done = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.on,
            this.character,
            this.pinyin});
            this.dataGridView.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView.Location = new System.Drawing.Point(12, 60);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 40;
            this.dataGridView.Size = new System.Drawing.Size(352, 365);
            this.dataGridView.TabIndex = 4;
            // 
            // on
            // 
            this.on.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.on.DataPropertyName = "on";
            this.on.HeaderText = "";
            this.on.MinimumWidth = 21;
            this.on.Name = "on";
            this.on.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.on.ToolTipText = "Enable or disable a character correction.";
            this.on.Width = 21;
            // 
            // character
            // 
            this.character.DataPropertyName = "character";
            this.character.HeaderText = "Character";
            this.character.Name = "character";
            this.character.ReadOnly = true;
            this.character.ToolTipText = "Chinese characters for correction.";
            // 
            // pinyin
            // 
            this.pinyin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pinyin.DataPropertyName = "pinyin";
            this.pinyin.HeaderText = "Pin1 yin1";
            this.pinyin.Name = "pinyin";
            this.pinyin.ReadOnly = true;
            this.pinyin.ToolTipText = "Space separated pinyin with numbers for tones.";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(45, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importToolStripMenuItem,
            this.exportDictionaryCorrectionsFileToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            this.importToolStripMenuItem.Name = "importToolStripMenuItem";
            this.importToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.importToolStripMenuItem.Text = "Import Dictionary Corrections File";
            this.importToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.importToolStripMenuItem.Click += new System.EventHandler(this.importToolStripMenuItem_Click);
            // 
            // exportDictionaryCorrectionsFileToolStripMenuItem
            // 
            this.exportDictionaryCorrectionsFileToolStripMenuItem.Name = "exportDictionaryCorrectionsFileToolStripMenuItem";
            this.exportDictionaryCorrectionsFileToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
            this.exportDictionaryCorrectionsFileToolStripMenuItem.Text = "Export Dictionary Corrections File";
            this.exportDictionaryCorrectionsFileToolStripMenuItem.Click += new System.EventHandler(this.exportDictionaryCorrectionsFileToolStripMenuItem_Click);
            // 
            // charBox
            // 
            this.charBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.charBox.Font = new System.Drawing.Font("SimSun", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.charBox.Location = new System.Drawing.Point(75, 30);
            this.charBox.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this.charBox.Name = "charBox";
            this.charBox.Size = new System.Drawing.Size(94, 23);
            this.charBox.TabIndex = 6;
            this.charBox.Text = "汉字";
            // 
            // onBox
            // 
            this.onBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.onBox.AutoSize = true;
            this.onBox.Checked = true;
            this.onBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.onBox.Location = new System.Drawing.Point(54, 33);
            this.onBox.Name = "onBox";
            this.onBox.Size = new System.Drawing.Size(15, 14);
            this.onBox.TabIndex = 7;
            this.onBox.UseVisualStyleBackColor = true;
            // 
            // pinyinBox
            // 
            this.pinyinBox.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pinyinBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pinyinBox.Location = new System.Drawing.Point(176, 30);
            this.pinyinBox.Name = "pinyinBox";
            this.pinyinBox.Size = new System.Drawing.Size(188, 23);
            this.pinyinBox.TabIndex = 8;
            this.pinyinBox.Text = "han4 zi4";
            // 
            // Add
            // 
            this.Add.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Add.Location = new System.Drawing.Point(13, 24);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(36, 30);
            this.Add.TabIndex = 9;
            this.Add.Text = "Add";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // done
            // 
            this.done.Location = new System.Drawing.Point(12, 431);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(352, 39);
            this.done.TabIndex = 10;
            this.done.Text = "Done";
            this.done.UseVisualStyleBackColor = true;
            this.done.Click += new System.EventHandler(this.done_Click);
            // 
            // toneCorrectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(376, 482);
            this.Controls.Add(this.done);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.pinyinBox);
            this.Controls.Add(this.onBox);
            this.Controls.Add(this.charBox);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimizeBox = false;
            this.Name = "toneCorrectionForm";
            this.Text = "Dictionary Corrections";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.TextBox charBox;
        private System.Windows.Forms.CheckBox onBox;
        private System.Windows.Forms.TextBox pinyinBox;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.Button done;
        private System.Windows.Forms.ToolStripMenuItem exportDictionaryCorrectionsFileToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn on;
        private System.Windows.Forms.DataGridViewTextBoxColumn character;
        private System.Windows.Forms.DataGridViewTextBoxColumn pinyin;
    }
}