namespace KateProg2
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.firstWordsInputBox = new System.Windows.Forms.RichTextBox();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.addDocumentButton = new System.Windows.Forms.Button();
            this.runButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pathToOpenedFilesLLabel = new System.Windows.Forms.Label();
            this.averageWordsInSentanceLabel = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.dragNDropImageBox = new System.Windows.Forms.PictureBox();
            this.loadSecWordsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragNDropImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // firstWordsInputBox
            // 
            this.firstWordsInputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.firstWordsInputBox.Location = new System.Drawing.Point(12, 23);
            this.firstWordsInputBox.Name = "firstWordsInputBox";
            this.firstWordsInputBox.Size = new System.Drawing.Size(270, 451);
            this.firstWordsInputBox.TabIndex = 0;
            this.firstWordsInputBox.Text = "Main Words";
            // 
            // outputBox
            // 
            this.outputBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.outputBox.Location = new System.Drawing.Point(288, 23);
            this.outputBox.Name = "outputBox";
            this.outputBox.ReadOnly = true;
            this.outputBox.Size = new System.Drawing.Size(326, 451);
            this.outputBox.TabIndex = 3;
            this.outputBox.Text = "Output";
            // 
            // addDocumentButton
            // 
            this.addDocumentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addDocumentButton.Location = new System.Drawing.Point(620, 344);
            this.addDocumentButton.Name = "addDocumentButton";
            this.addDocumentButton.Size = new System.Drawing.Size(110, 62);
            this.addDocumentButton.TabIndex = 4;
            this.addDocumentButton.Text = "Add Document";
            this.addDocumentButton.UseVisualStyleBackColor = true;
            this.addDocumentButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // runButton
            // 
            this.runButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.runButton.Location = new System.Drawing.Point(620, 278);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(110, 62);
            this.runButton.TabIndex = 4;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::KateProg2.Properties.Resources.Picture;
            this.pictureBox1.Location = new System.Drawing.Point(620, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(110, 249);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pathToOpenedFilesLLabel
            // 
            this.pathToOpenedFilesLLabel.AutoSize = true;
            this.pathToOpenedFilesLLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pathToOpenedFilesLLabel.Location = new System.Drawing.Point(12, 4);
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
            // dragNDropImageBox
            // 
            this.dragNDropImageBox.Image = ((System.Drawing.Image)(resources.GetObject("dragNDropImageBox.Image")));
            this.dragNDropImageBox.Location = new System.Drawing.Point(2, 4);
            this.dragNDropImageBox.Name = "dragNDropImageBox";
            this.dragNDropImageBox.Size = new System.Drawing.Size(738, 502);
            this.dragNDropImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dragNDropImageBox.TabIndex = 9;
            this.dragNDropImageBox.TabStop = false;
            this.dragNDropImageBox.Visible = false;
            // 
            // loadSecWordsButton
            // 
            this.loadSecWordsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loadSecWordsButton.Location = new System.Drawing.Point(620, 412);
            this.loadSecWordsButton.Name = "loadSecWordsButton";
            this.loadSecWordsButton.Size = new System.Drawing.Size(110, 62);
            this.loadSecWordsButton.TabIndex = 4;
            this.loadSecWordsButton.Text = "Load Secondary Words";
            this.loadSecWordsButton.UseVisualStyleBackColor = true;
            this.loadSecWordsButton.Click += new System.EventHandler(this.loadSecWordsButton_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 500);
            this.Controls.Add(this.dragNDropImageBox);
            this.Controls.Add(this.averageWordsInSentanceLabel);
            this.Controls.Add(this.pathToOpenedFilesLLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.addDocumentButton);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.firstWordsInputBox);
            this.Controls.Add(this.loadSecWordsButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "KateWords2";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_onDragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_onDragEnter);
            this.DragLeave += new System.EventHandler(this.Form1_onDragLeave);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dragNDropImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox firstWordsInputBox;
        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.Button addDocumentButton;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label pathToOpenedFilesLLabel;
        private System.Windows.Forms.Label averageWordsInSentanceLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox dragNDropImageBox;
        private System.Windows.Forms.Button loadSecWordsButton;
    }
}

