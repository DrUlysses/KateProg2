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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.PositiveWordsTab = new System.Windows.Forms.TabPage();
            this.NegativeWordsTab = new System.Windows.Forms.TabPage();
            this.NeutralWordsTab = new System.Windows.Forms.TabPage();
            this.NegativeWordsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.PositiveWordsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.NeutralWordsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.tabControl.SuspendLayout();
            this.PositiveWordsTab.SuspendLayout();
            this.NegativeWordsTab.SuspendLayout();
            this.NeutralWordsTab.SuspendLayout();
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
            // tabControl
            // 
            this.tabControl.Controls.Add(this.NegativeWordsTab);
            this.tabControl.Controls.Add(this.PositiveWordsTab);
            this.tabControl.Controls.Add(this.NeutralWordsTab);
            this.tabControl.Location = new System.Drawing.Point(15, 26);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(715, 462);
            this.tabControl.TabIndex = 1;
            // 
            // PositiveWordsTab
            // 
            this.PositiveWordsTab.Controls.Add(this.PositiveWordsRichTextBox);
            this.PositiveWordsTab.Location = new System.Drawing.Point(4, 22);
            this.PositiveWordsTab.Name = "PositiveWordsTab";
            this.PositiveWordsTab.Padding = new System.Windows.Forms.Padding(3);
            this.PositiveWordsTab.Size = new System.Drawing.Size(707, 436);
            this.PositiveWordsTab.TabIndex = 0;
            this.PositiveWordsTab.Text = "Positive";
            this.PositiveWordsTab.UseVisualStyleBackColor = true;
            // 
            // NegativeWordsTab
            // 
            this.NegativeWordsTab.Controls.Add(this.NegativeWordsRichTextBox);
            this.NegativeWordsTab.Location = new System.Drawing.Point(4, 22);
            this.NegativeWordsTab.Name = "NegativeWordsTab";
            this.NegativeWordsTab.Padding = new System.Windows.Forms.Padding(3);
            this.NegativeWordsTab.Size = new System.Drawing.Size(707, 436);
            this.NegativeWordsTab.TabIndex = 1;
            this.NegativeWordsTab.Text = "Negative";
            this.NegativeWordsTab.UseVisualStyleBackColor = true;
            // 
            // NeutralWordsTab
            // 
            this.NeutralWordsTab.Controls.Add(this.NeutralWordsRichTextBox);
            this.NeutralWordsTab.Location = new System.Drawing.Point(4, 22);
            this.NeutralWordsTab.Name = "NeutralWordsTab";
            this.NeutralWordsTab.Size = new System.Drawing.Size(707, 436);
            this.NeutralWordsTab.TabIndex = 2;
            this.NeutralWordsTab.Text = "Neutral";
            this.NeutralWordsTab.UseVisualStyleBackColor = true;
            // 
            // NegativeWordsRichTextBox
            // 
            this.NegativeWordsRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.NegativeWordsRichTextBox.Name = "NegativeWordsRichTextBox";
            this.NegativeWordsRichTextBox.Size = new System.Drawing.Size(707, 436);
            this.NegativeWordsRichTextBox.TabIndex = 0;
            this.NegativeWordsRichTextBox.Text = "";
            // 
            // PositiveWordsRichTextBox
            // 
            this.PositiveWordsRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.PositiveWordsRichTextBox.Name = "PositiveWordsRichTextBox";
            this.PositiveWordsRichTextBox.Size = new System.Drawing.Size(707, 436);
            this.PositiveWordsRichTextBox.TabIndex = 0;
            this.PositiveWordsRichTextBox.Text = "";
            // 
            // NeutralWordsRichTextBox
            // 
            this.NeutralWordsRichTextBox.Location = new System.Drawing.Point(0, 0);
            this.NeutralWordsRichTextBox.Name = "NeutralWordsRichTextBox";
            this.NeutralWordsRichTextBox.Size = new System.Drawing.Size(707, 436);
            this.NeutralWordsRichTextBox.TabIndex = 0;
            this.NeutralWordsRichTextBox.Text = "";
            // 
            // MainWordEntriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 500);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.MainWordLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWordEntriesForm";
            this.Text = "KateWords3";
            this.tabControl.ResumeLayout(false);
            this.PositiveWordsTab.ResumeLayout(false);
            this.NegativeWordsTab.ResumeLayout(false);
            this.NeutralWordsTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MainWordLabel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage NegativeWordsTab;
        private System.Windows.Forms.TabPage PositiveWordsTab;
        private System.Windows.Forms.TabPage NeutralWordsTab;
        private System.Windows.Forms.RichTextBox NegativeWordsRichTextBox;
        private System.Windows.Forms.RichTextBox PositiveWordsRichTextBox;
        private System.Windows.Forms.RichTextBox NeutralWordsRichTextBox;
    }
}