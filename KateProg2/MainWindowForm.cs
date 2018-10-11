using System;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Threading.Tasks;

namespace KateProg2 {
    public partial class MainWindowForm : Form {
        private PrivateFontCollection font;
        private SearchEngine searchEngine = new SearchEngine();

        public MainWindowForm() {
            InitializeComponent();
            LoadFonts();
        }

        private void LoadFonts() {
            // Try to load fonts and do nothing on fail
            this.font = new PrivateFontCollection();
            try {
                this.font.AddFontFile("font/Ubuntu.ttf");
                this.font.AddFontFile("font/Ubuntu Light.ttf");
            }
            catch { }
        }

        private void Button1_Click(object sender, EventArgs e) {
            //open the file
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Filter = "Text (*.txt; *.doc; *.docx; *.odt; *.rtf; *.pdf; *.chm)|*.txt; *.doc; *.docx; *.odt; *.rtf; *.pdf; *.chm ";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                StatusBar.Text = searchEngine.AddDocument(openFile.FileName);
                pathToOpenedFilesLLabel.Text = openFile.FileName;
                SelectedFilesPictureBox.Visible = false;
                OpenedFilesBox.Items.Add(openFile.FileName);
                if (searchEngine.GetDocumentsCount() == 1 && OpenedFilesBox.Items.Count > 1)
                    OpenedFilesBox.Items.RemoveAt(0);
            }
        }

        // Drag and drop
        private void Form1_onDragEnter(object sender, DragEventArgs e) {
            dragNDropImageBox.Visible = true;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_onDragDrop(object sender, DragEventArgs e) {
            dragNDropImageBox.Visible = false;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                StatusBar.Text = searchEngine.AddDocument(file);
                pathToOpenedFilesLLabel.Text = file;
                SelectedFilesPictureBox.Visible = false;
                OpenedFilesBox.Items.Add(file);
                if (searchEngine.GetDocumentsCount() == 1 && OpenedFilesBox.Items.Count > 1)
                    OpenedFilesBox.Items.RemoveAt(0);
            }
        }

        private void Form1_onDragLeave(object sender, EventArgs e) {
            dragNDropImageBox.Visible = false;
        }

        private void LoadSecWordsButton_Click(object sender, EventArgs e)
        {
            //open the file
            OpenFileDialog openFile = new OpenFileDialog
            {
                Filter = "Text (*.txt)|*.txt"
            };

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                uint posCount = 0;
                uint negCount = 0;
                uint neutrCount = 0;
                using (StreamReader str = new StreamReader(openFile.FileName, Encoding.Default))
                {
                    SecWordType current = SecWordType.POSITIVE;
                    while (!str.EndOfStream)
                    {
                        string temp = str.ReadLine().ToLower();
                        if (temp.Contains("#positive"))
                        {
                            current = SecWordType.POSITIVE;
                            temp = str.ReadLine().ToLower();
                        }
                        else if (temp.Contains("#negative"))
                        {
                            current = SecWordType.NEGATIVE;
                            temp = str.ReadLine().ToLower();
                        }
                        else if (temp.Contains("#neutral"))
                        {
                            current = SecWordType.NEUTRAL;
                            temp = str.ReadLine().ToLower();
                        }
                        switch (current)
                        {
                            case SecWordType.POSITIVE:
                                searchEngine.AddPositiveWord(temp);
                                posCount++;
                                break;
                            case SecWordType.NEGATIVE:
                                searchEngine.AddNegativeWord(temp);
                                negCount++;
                                break;
                            case SecWordType.NEUTRAL:
                                searchEngine.AddNeutralWord(temp);
                                neutrCount++;
                                break;
                            default:
                                break;
                        }
                    }
                }
                pathToOpenedFilesLLabel.Text = openFile.FileName;
                StatusBar.Text = "Loaded Positive: " + posCount + " Negative: " + negCount + " Neutral: " + neutrCount + " .";
            }
        }

        private void OpenedFilesBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            searchEngine.RemoveDocument(OpenedFilesBox.SelectedItem.ToString());
            pathToOpenedFilesLLabel.Text = "";
            StatusBar.Text = "";
            if (OpenedFilesBox.Items.Count > 1)
                OpenedFilesBox.Items.RemoveAt(OpenedFilesBox.SelectedIndex);
            else
                SelectedFilesPictureBox.Visible = true;
        }

        private void OutputListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                string tempWordName = OutputListBox.SelectedItem.ToString();
                int startIndex = tempWordName.IndexOf("\r") + 1;
                int wordLength = tempWordName.IndexOf(" [ ") - startIndex;

                int docNameStartIndex = tempWordName.IndexOf("}");
                string tempDocumentName = tempWordName.Substring(2, docNameStartIndex - 3);

                tempWordName = tempWordName.Substring(startIndex, wordLength);

                MainWord tempWord = searchEngine.GetMainWord(tempDocumentName, tempWordName);

                if (tempWord != null)
                {
                    MainWordEntriesForm form = new MainWordEntriesForm(tempWord);

                    form.Show();
                }
            }
            catch (System.NullReferenceException)
            {
                return;
            }
        }

        private async void RunButton_ClickAsync(object sender, EventArgs e)
        {
            // Clear previous output computation
            OutputListBox.Items.Clear();
            searchEngine.ClearResults();
            // Read dictionary words
            foreach (object tempDocument in OpenedFilesBox.Items)
                foreach (string tempWordName in firstWordsInputBox.Text.Split('\r', '\n'))
                    searchEngine.AddMainWord(tempWordName.ToLower(), tempDocument.ToString());
            // Generate words pairs
            searchEngine.GenerateWordsPairs();
            // Clear Status bar
            int doneDocsNum = 0;
            StatusBar.Text = doneDocsNum + " / " + OpenedFilesBox.Items.Count;

            // Run calculation
            foreach (object tempDocument in OpenedFilesBox.Items)
            {
                var calcTask = CalculateOutput(tempDocument);
                await calcTask;
                doneDocsNum++;
                StatusBar.Text = doneDocsNum + " / " + OpenedFilesBox.Items.Count;
            }

        }

        private async Task CalculateOutput(object tempDocument)
        {
            await searchEngine.ComputeEntries(tempDocument.ToString());
            // Output
            foreach (MainWord mainWord in searchEngine.GetMainWords(tempDocument.ToString()))
                OutputListBox.Items.Add(mainWord.ToString());
        }
    }
}
