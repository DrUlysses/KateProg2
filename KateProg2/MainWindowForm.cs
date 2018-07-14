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
                averageWordsInSentanceLabel.Text = searchEngine.AddDocument(openFile.FileName);
                pathToOpenedFilesLLabel.Text = openFile.FileName;
                SelectedFilesPictureBox.Visible = false;
                OpenedFilesBox.Items.Add(openFile.SafeFileName);
                if (searchEngine.GetDocumentsCount() == 1 && OpenedFilesBox.Items.Count > 1)
                    OpenedFilesBox.Items.RemoveAt(0);
            }
        }

        private void Button2_Click(object sender, EventArgs e) {
            // Clear previous output computation
            OutputListBox.Items.Clear();
            searchEngine.ClearResults();
            // Read dictionary words
            foreach (string temp in firstWordsInputBox.Text.Split('\r', '\n'))
                searchEngine.AddMainWord(temp.ToLower());
            // Run calculation
            searchEngine.ComputeEntries();
            // Output
            Parallel.ForEach(searchEngine.GetMainWords(), (mainWord) =>
            {
                OutputListBox.Items.Add(mainWord.ToString());
            });
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

            searchEngine.AddDocument(files[0]);
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
                averageWordsInSentanceLabel.Text = "Loaded Positive: " + posCount + " Negative: " + negCount + " Neutral: " + neutrCount + " .";
            }
        }

        private void OpenedFilesBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            searchEngine.RemoveDocument(OpenedFilesBox.SelectedItem.ToString());
            pathToOpenedFilesLLabel.Text = "";
            averageWordsInSentanceLabel.Text = "";
            if (OpenedFilesBox.Items.Count > 1)
                OpenedFilesBox.Items.RemoveAt(OpenedFilesBox.SelectedIndex);
            else
            {
                SelectedFilesPictureBox.Visible = true;
            }
        }

        private void OutputListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            string tempWordName = OutputListBox.SelectedItem.ToString().Split('[')[0];

            MainWord tempWord = searchEngine.GetMainWord(tempWordName.Substring(0, tempWordName.Length - 1));

            MainWordEntriesForm form = new MainWordEntriesForm(tempWord);
            
            form.Show();
        }
    }
}
