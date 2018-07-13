using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Text;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using Independentsoft.Office.Odf;
using System.Threading.Tasks;

namespace KateProg2 {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
            loadFonts();
        }

        PrivateFontCollection font;
        
        private void loadFonts() {
            // Try to load fonts and do nothing on fail
            this.font = new PrivateFontCollection();
            try {
                this.font.AddFontFile("font/Ubuntu.ttf");
                this.font.AddFontFile("font/Ubuntu Light.ttf");
            }
            catch { }
        }

        SearchEngine searchEngine = new SearchEngine();

        private void button1_Click(object sender, EventArgs e) {
            //open the file
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Filter = "Text (*.txt; *.doc; *.docx; *.odt; *.rtf; *.pdf; *.chm)|*.txt; *.doc; *.docx; *.odt; *.rtf; *.pdf; *.chm ";

            if (openFile.ShowDialog() == DialogResult.OK)
                searchEngine.AddDocument(openFile.FileName);
        }

        private void button2_Click(object sender, EventArgs e) {
            // Read dictionary words
            foreach (string temp in firstWordsInputBox.Text.Split('\r', '\n'))
                searchEngine.AddMainWord(temp);
            // Output
            outputBox.Text = searchEngine.ComputeEntries();
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

        private void loadSecWordsButton_Click(object sender, EventArgs e)
        {
            //open the file
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Filter = "Text (*.txt)|*.txt";

            if (openFile.ShowDialog() == DialogResult.OK)
                using (StreamReader str = new StreamReader(openFile.FileName, Encoding.Default))
                {
                    SecWordType current = SecWordType.POSITIVE;
                    while (!str.EndOfStream)
                    {
                        string temp = str.ReadLine().ToLower();
                        if (temp.Contains("#positive")) {
                            current = SecWordType.POSITIVE;
                            temp = str.ReadLine().ToLower();
                        }
                        else if (temp.Contains("#negative")) {
                            current = SecWordType.NEGATIVE;
                            temp = str.ReadLine().ToLower();
                        }
                        else if (temp.Contains("#neutral")) {
                            current = SecWordType.NEUTRAL;
                            temp = str.ReadLine().ToLower();
                        }
                        switch (current)
                        {
                            case SecWordType.POSITIVE:
                                searchEngine.AddPositiveWord(temp);
                                break;
                            case SecWordType.NEGATIVE:
                                searchEngine.AddNegativeWord(temp);
                                break;
                            case SecWordType.NEUTRAL:
                                searchEngine.AddNeutralWord(temp);
                                break;
                            default:
                                break;
                        }
                    }
                }
        }
    }

    public enum SecWordType
    {
        POSITIVE,
        NEGATIVE,
        NEUTRAL
    }

    public class MainWord
    {
        private string word;
        private List<string> positiveEntries;
        private List<string> negativeEntries;
        private List<string> neutralEntries;

        public MainWord(string word) {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentException("First word is null or empty", nameof(word));
            this.word = word;
            this.positiveEntries = new List<string>();
            this.negativeEntries = new List<string>();
            this.neutralEntries = new List<string>();
        }

        public string GetWord() => this.word;

        public void AddEntries(WordsPair wordsPair)
        {
            SecWordType secWordType = wordsPair.GetSecWordType();
            switch (secWordType)
            {
                case SecWordType.POSITIVE:
                    this.positiveEntries.AddRange(wordsPair.GetEntries());
                    break;
                case SecWordType.NEGATIVE:
                    this.negativeEntries.AddRange(wordsPair.GetEntries());
                    break;
                case SecWordType.NEUTRAL:
                    this.neutralEntries.AddRange(wordsPair.GetEntries());
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            uint negativeCount = (uint)this.negativeEntries.Capacity;
            uint positiveCount = (uint)this.positiveEntries.Capacity;
            uint neutralCount = (uint)this.neutralEntries.Capacity;
            if (negativeCount > positiveCount && negativeCount >= 2)
                return this.word + " [ positive ( " + positiveCount +
                                    " )  ***negative ( " + negativeCount +
                                    " )***  neutral ( " + neutralCount +
                                    " ) ]";
            else if (positiveCount > negativeCount && neutralCount >= 2)
                return this.word + " [ ***positive ( " + positiveCount +
                                    " )***  negative ( " + negativeCount +
                                    " )  neutral ( " + neutralCount +
                                    " ) ]";
            else
                return this.word + " [ positive ( " + positiveCount +
                                    " )  negative ( " + negativeCount +
                                    " )  ***neutral ( " + neutralCount +
                                    " )*** ]";
        }
    }

    public class Document {
        public RichTextBox textBox = new RichTextBox();
        private uint averageWordsInSentence;
        private int wordsCount;
        private string path;

        public Document(string path) {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Document path is null or empty", nameof(path));

            this.path = path;
            this.averageWordsInSentence = 0;
            this.wordsCount = 0;
        }

        public uint GetAverageWordsInSentence() {
            if(averageWordsInSentence == 0)
            {
                if (this.wordsCount == 0)
                    averageWordsInSentence = (uint)(this.textBox.Text.Split(' ').Length / this.textBox.Text.Split('.').Length);
                else
                    averageWordsInSentence = (uint)(this.wordsCount / textBox.Text.Split('.').Length);
            }

            return averageWordsInSentence;
        }

        public int GetWordsCount() {
            if(wordsCount == 0)
                wordsCount = textBox.Text.Split(' ').Length;
            return wordsCount;
        }

    }

    public class SearchEngine
    {
        private List<Document> documents;
        private Dictionary<string, MainWord> mainWords;
        private List<WordsPair> wordsPairs;
        private List<string> negativeWords;
        private List<string> positiveWords;
        private List<string> neutralWords;

        public SearchEngine() { }

        public string AddDocument(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentException("Document path is null or empty", nameof(fileName));

            Document document = new Document(fileName);

            //Read file
            //if .rtf
            if (fileName.Substring(fileName.Length - 5, 5).Contains("rtf"))
                document.textBox.Rtf = File.ReadAllText(fileName);
            //if .pdf
            else if (fileName.Substring(fileName.Length - 5, 5).Contains("pdf"))
            {
                PDDocument doc = null;
                try
                {
                    doc = PDDocument.load(fileName);
                    PDFTextStripper stripper = new PDFTextStripper();
                    document.textBox.Text = stripper.getText(doc);
                }
                finally
                {
                    if (document != null)
                        doc.close();
                }
            }
            //if .odt
            else if (fileName.Substring(fileName.Length - 5, 5).Contains("odt"))
            {
                TextDocument doc = new TextDocument(fileName);
                document.textBox.Text = doc.ToText();
            }
            //if all else
            else
                using (StreamReader str = new StreamReader(fileName, Encoding.Default))
                    while (!str.EndOfStream)
                        document.textBox.AppendText(str.ReadLine().ToLower() + "\r\n");

            this.documents.Add(document);
            //check counts
            return "Words in File ~ " + document.GetWordsCount() + ",  Average Words in the Sentence: " + document.GetAverageWordsInSentence();
        }

        public void AddNegativeWord(string word)
        {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentException("Negative word to add is empty or null", nameof(word));

            negativeWords.Add(word);
        }

        public void AddPositiveWord(string word)
        {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentException("Positive word to add is empty or null", nameof(word));

            positiveWords.Add(word);
        }

        public void AddNeutralWord(string word)
        {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentException("Neutral word to add is empty or null", nameof(word));

            neutralWords.Add(word);
        }

        public void AddMainWord(string word)
        {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentException("Main word to add is null or empty", nameof(word));

            this.mainWords.Add(word, new MainWord(word));
        }

        public string ComputeEntries()
        {
            Parallel.ForEach(this.mainWords.Values, (mainWord) =>
            {
                Parallel.ForEach(this.negativeWords, (negativeWord) =>
                {
                    this.wordsPairs.Add(new WordsPair(mainWord.GetWord(), negativeWord, true, SecWordType.NEGATIVE));
                    this.wordsPairs.Add(new WordsPair(negativeWord, mainWord.GetWord(), false, SecWordType.NEGATIVE));
                });
                Parallel.ForEach(this.positiveWords, (positiveWord) =>
                {
                    this.wordsPairs.Add(new WordsPair(mainWord.GetWord(), positiveWord, true, SecWordType.POSITIVE));
                    this.wordsPairs.Add(new WordsPair(positiveWord, mainWord.GetWord(), false, SecWordType.POSITIVE));
                });
                Parallel.ForEach(this.neutralWords, (neutralWord) =>
                {
                    this.wordsPairs.Add(new WordsPair(mainWord.GetWord(), neutralWord, true, SecWordType.NEUTRAL));
                    this.wordsPairs.Add(new WordsPair(neutralWord, mainWord.GetWord(), false, SecWordType.NEUTRAL));
                });
            });

            Parallel.ForEach(this.documents, (currentDocument) =>
            {
                foreach (string line in currentDocument.textBox.Text.Split('\r', '\n'))
                {
                    string[] lineWords = line.Split(' ');
                    if (lineWords.Length != 0 && lineWords[0] != "")
                    { //TODO: handle "-" on line endings.
                        foreach (string word in lineWords)
                            Parallel.ForEach(this.wordsPairs, (wordsPair) =>
                            {
                                wordsPair.CheckWord(word, currentDocument.GetAverageWordsInSentence());
                            });
                    }
                } 
            });

            Parallel.ForEach(this.wordsPairs, (wordPair) => 
            {
                this.mainWords[wordPair.GetMain()].AddEntries(wordPair);
            });

            string result = "";
            Parallel.ForEach(this.mainWords, (mainWord) =>
            {
                result += mainWord.ToString() + "\r\n";
            });
            return result;
        }
    }
    
    public class WordsPair
    {
        private string firstWord;
        private string firstWordCutted;
        private string secondWord;
        private string secondWordCutted;
        private uint distance;
        private bool findFirst;
        private List<string> entries;
        private string entry;
        private bool isFirstWordMain;
        private SecWordType secWordType;

        public WordsPair(string firstWord, string secondWord, bool isFirstWordMain, SecWordType secWordType)
        {
            if (string.IsNullOrEmpty(firstWord))
                throw new ArgumentException("firstWord is null or empty", nameof(firstWord));

            if (string.IsNullOrEmpty(secondWord))
                throw new ArgumentException("secondWord is null or empty", nameof(secondWord));

            this.firstWord = firstWord;
            this.secondWord = secondWord;
            this.isFirstWordMain = isFirstWordMain;
            this.secWordType = secWordType;

            int tempLength = firstWord.Length;
            if (tempLength > 3)
                this.firstWordCutted = firstWord.Substring(0, tempLength - 3);
            else
                this.firstWordCutted = firstWord.Substring(0, tempLength);

            tempLength = secondWord.Length;
            if (tempLength > 3)
                this.secondWordCutted = secondWord.Substring(0, tempLength - 3);
            else
                this.secondWordCutted = secondWord.Substring(0, tempLength);

            this.distance = 0;
            this.findFirst = false;
            this.entries = new List<string>();
            this.entry = "";
        }

        public void CheckWord(string word, uint distance)
        {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentException("Word to check is empty or null", nameof(word));

            if (!findFirst && word.Contains(firstWordCutted))
                findFirst = true;
            else if (findFirst && word.Contains(secondWordCutted) && this.distance <= distance)
            {
                this.distance = 0;
                this.findFirst = false;
                this.entries.Add(entry + ' ' + word);
                this.entry = "";
            }
            else if (findFirst)
            {
                this.distance++;
                this.entry += ' ' + word;
            }

            if (findFirst && this.distance > distance)
            {
                this.distance = 0;
                this.findFirst = false;
                this.entry = "";
            }
        }

        public string GetMain() => this.isFirstWordMain ? this.firstWord : this.secondWord;

        public SecWordType GetSecWordType() => this.secWordType;

        public List<string> GetEntries() => this.entries;
    }
}
