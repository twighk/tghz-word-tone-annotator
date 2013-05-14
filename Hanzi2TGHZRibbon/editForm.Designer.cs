namespace Hanzi2TGHZRibbon
{
    partial class editForm
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
            this.hanzi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pinyintones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.done = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hanzi,
            this.pinyintones});
            this.dataGridView.Location = new System.Drawing.Point(12, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.ShowEditingIcon = false;
            this.dataGridView.Size = new System.Drawing.Size(383, 452);
            this.dataGridView.TabIndex = 0;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            this.dataGridView.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // hanzi
            // 
            this.hanzi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hanzi.DataPropertyName = "hanzi";
            this.hanzi.HeaderText = "Hanzi:";
            this.hanzi.Name = "hanzi";
            this.hanzi.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pinyintones
            // 
            this.pinyintones.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pinyintones.DataPropertyName = "pytn";
            this.pinyintones.HeaderText = "Pinyin or Tones:";
            this.pinyintones.Name = "pinyintones";
            this.pinyintones.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // done
            // 
            this.done.Location = new System.Drawing.Point(12, 470);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(100, 23);
            this.done.TabIndex = 1;
            this.done.Text = "Done";
            this.done.UseVisualStyleBackColor = true;
            this.done.Click += new System.EventHandler(this.done_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(295, 470);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(100, 23);
            this.cancel.TabIndex = 2;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // editForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 505);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.done);
            this.Controls.Add(this.dataGridView);
            this.MinimizeBox = false;
            this.Name = "editForm";
            this.Text = "Edit Text or Pinyin";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button done;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn hanzi;
        private System.Windows.Forms.DataGridViewTextBoxColumn pinyintones;
    }
}