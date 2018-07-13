namespace KateProg2
{
    partial class MainWordEntriesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWordEntriesForm));
            this.MainWordLabel = new System.Windows.Forms.Label();
            this.MainWordEntries = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // MainWordLabel
            // 
            this.MainWordLabel.AutoSize = true;
            this.MainWordLabel.Location = new System.Drawing.Point(12, 9);
            this.MainWordLabel.Name = "MainWordLabel";
            this.MainWordLabel.Size = new System.Drawing.Size(56, 13);
            this.MainWordLabel.TabIndex = 0;
            this.MainWordLabel.Text = "MainWord";
            // 
            // MainWordEntries
            // 
            this.MainWordEntries.Location = new System.Drawing.Point(12, 25);
            this.MainWordEntries.Name = "MainWordEntries";
            this.MainWordEntries.Size = new System.Drawing.Size(718, 463);
            this.MainWordEntries.TabIndex = 1;
            this.MainWordEntries.Text = "";
            // 
            // MainWordEntriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 500);
            this.Controls.Add(this.MainWordEntries);
            this.Controls.Add(this.MainWordLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWordEntriesForm";
            this.Text = "KateWords3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainWordLabel;
        private System.Windows.Forms.RichTextBox MainWordEntries;
    }
}