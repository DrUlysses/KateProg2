namespace KateProg2
{
    partial class MainWindowForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindowForm));
            this.firstWordsInputBox = new System.Windows.Forms.RichTextBox();
            this.addDocumentButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.pathToOpenedFilesLLabel = new System.Windows.Forms.Label();
            this.averageWordsInSentanceLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.loadSecWordsButton = new System.Windows.Forms.Button();
            this.dragNDropImageBox = new System.Windows.Forms.PictureBox();
            this.SelectedFilesPictureBox = new System.Windows.Forms.PictureBox();
            this.OpenedFilesBox = new System.Windows.Forms.CheckedListBox();
            this.OutputListBox = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dragNDropImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedFilesPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // firstWordsInputBox
            // 
            this.firstWordsInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstWordsInputBox.Location = new System.Drawing.Point(12, 23);
            this.firstWordsInputBox.Name = "firstWordsInputBox";
            this.firstWordsInputBox.Size = new System.Drawing.Size(272, 446);
            this.firstWordsInputBox.TabIndex = 0;
            this.firstWordsInputBox.Text = "Main Words";
            // 
            // addDocumentButton
            // 
            this.addDocumentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addDocumentButton.Location = new System.Drawing.Point(813, 341);
            this.addDocumentButton.Name = "addDocumentButton";
            this.addDocumentButton.Size = new System.Drawing.Size(151, 62);
            this.addDocumentButton.TabIndex = 4;
            this.addDocumentButton.Text = "Add Document";
            this.addDocumentButton.UseVisualStyleBackColor = true;
            this.addDocumentButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // runButton
            // 
            this.runButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.runButton.Location = new System.Drawing.Point(813, 273);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(151, 62);
            this.runButton.TabIndex = 4;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.Button2_Click);
            // 
            // pathToOpenedFilesLLabel
            // 
            this.pathToOpenedFilesLLabel.AutoSize = true;
            this.pathToOpenedFilesLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pathToOpenedFilesLLabel.Location = new System.Drawing.Point(9, 7);
            this.pathToOpenedFilesLLabel.Name = "pathToOpenedFilesLLabel";
            this.pathToOpenedFilesLLabel.Size = new System.Drawing.Size(85, 13);
            this.pathToOpenedFilesLLabel.TabIndex = 7;
            this.pathToOpenedFilesLLabel.Text = "No File Selected";
            // 
            // averageWordsInSentanceLabel
            // 
            this.averageWordsInSentanceLabel.AutoSize = true;
            this.averageWordsInSentanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.averageWordsInSentanceLabel.Location = new System.Drawing.Point(12, 477);
            this.averageWordsInSentanceLabel.Name = "averageWordsInSentanceLabel";
            this.averageWordsInSentanceLabel.Size = new System.Drawing.Size(85, 13);
            this.averageWordsInSentanceLabel.TabIndex = 8;
            this.averageWordsInSentanceLabel.Text = "No File Selected";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // loadSecWordsButton
            // 
            this.loadSecWordsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadSecWordsButton.Location = new System.Drawing.Point(813, 407);
            this.loadSecWordsButton.Name = "loadSecWordsButton";
            this.loadSecWordsButton.Size = new System.Drawing.Size(151, 62);
            this.loadSecWordsButton.TabIndex = 4;
            this.loadSecWordsButton.Text = "Load Secondary Words";
            this.loadSecWordsButton.UseVisualStyleBackColor = true;
            this.loadSecWordsButton.Click += new System.EventHandler(this.LoadSecWordsButton_Click);
            // 
            // dragNDropImageBox
            // 
            this.dragNDropImageBox.Image = ((System.Drawing.Image)(resources.GetObject("dragNDropImageBox.Image")));
            this.dragNDropImageBox.Location = new System.Drawing.Point(119, -3);
            this.dragNDropImageBox.Name = "dragNDropImageBox";
            this.dragNDropImageBox.Size = new System.Drawing.Size(744, 504);
            this.dragNDropImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dragNDropImageBox.TabIndex = 9;
            this.dragNDropImageBox.TabStop = false;
            this.dragNDropImageBox.Visible = false;
            // 
            // SelectedFilesPictureBox
            // 
            this.SelectedFilesPictureBox.Image = global::KateProg2.Properties.Resources.Picture;
            this.SelectedFilesPictureBox.Location = new System.Drawing.Point(813, 23);
            this.SelectedFilesPictureBox.Name = "SelectedFilesPictureBox";
            this.SelectedFilesPictureBox.Size = new System.Drawing.Size(151, 244);
            this.SelectedFilesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SelectedFilesPictureBox.TabIndex = 6;
            this.SelectedFilesPictureBox.TabStop = false;
            // 
            // OpenedFilesBox
            // 
            this.OpenedFilesBox.CheckOnClick = true;
            this.OpenedFilesBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OpenedFilesBox.FormattingEnabled = true;
            this.OpenedFilesBox.HorizontalScrollbar = true;
            this.OpenedFilesBox.Location = new System.Drawing.Point(813, 23);
            this.OpenedFilesBox.Name = "OpenedFilesBox";
            this.OpenedFilesBox.Size = new System.Drawing.Size(151, 244);
            this.OpenedFilesBox.TabIndex = 10;
            this.OpenedFilesBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.OpenedFilesBox_ItemCheck);
            // 
            // OutputListBox
            // 
            this.OutputListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OutputListBox.FormattingEnabled = true;
            this.OutputListBox.Location = new System.Drawing.Point(290, 23);
            this.OutputListBox.Name = "OutputListBox";
            this.OutputListBox.Size = new System.Drawing.Size(517, 446);
            this.OutputListBox.TabIndex = 11;
            this.OutputListBox.SelectedValueChanged += new System.EventHandler(this.OutputListBox_SelectedValueChanged);
            // 
            // MainWindowForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 500);
            this.Controls.Add(this.dragNDropImageBox);
            this.Controls.Add(this.averageWordsInSentanceLabel);
            this.Controls.Add(this.pathToOpenedFilesLLabel);
            this.Controls.Add(this.SelectedFilesPictureBox);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.addDocumentButton);
            this.Controls.Add(this.firstWordsInputBox);
            this.Controls.Add(this.loadSecWordsButton);
            this.Controls.Add(this.OpenedFilesBox);
            this.Controls.Add(this.OutputListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindowForm";
            this.Text = "KateWords3";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_onDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_onDragEnter);
            this.DragLeave += new System.EventHandler(this.Form1_onDragLeave);
            ((System.ComponentModel.ISupportInitialize)(this.dragNDropImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedFilesPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox firstWordsInputBox;
        private System.Windows.Forms.Button addDocumentButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.PictureBox SelectedFilesPictureBox;
        private System.Windows.Forms.Label pathToOpenedFilesLLabel;
        private System.Windows.Forms.Label averageWordsInSentanceLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox dragNDropImageBox;
        private System.Windows.Forms.Button loadSecWordsButton;
        private System.Windows.Forms.CheckedListBox OpenedFilesBox;
        private System.Windows.Forms.ListBox OutputListBox;
    }
}

