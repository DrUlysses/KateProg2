using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Text;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using Independentsoft.Office.Odf;

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

        Document document = new Document();

        private void readText(string fileName) {
            label1.Text = fileName;

            //Read file
            //if .rtf
            if (fileName.Substring(fileName.Length - 5, 5).Contains("rtf"))
                document.textBox.Rtf = File.ReadAllText(fileName);
            //if .pdf
            else if (fileName.Substring(fileName.Length - 5, 5).Contains("pdf")) {
                PDDocument doc = null;
                try {
                    doc = PDDocument.load(fileName);
                    PDFTextStripper stripper = new PDFTextStripper();
                    document.textBox.Text = stripper.getText(doc);
                }
                finally {
                    if (document != null)
                        doc.close();
                }
            }
            //if .odt
            else if (fileName.Substring(fileName.Length - 5, 5).Contains("odt")) {
                TextDocument doc = new TextDocument(fileName);
                document.textBox.Text = doc.ToText();
            }
            //if all else
            else
                using (StreamReader str = new StreamReader(fileName, Encoding.Default)) 
                    while (!str.EndOfStream)
                        document.textBox.AppendText(str.ReadLine().ToLower() + "\r\n");
                    
            //check counts
            label2.Text = "Words in File ~ " + document.getWordsCount() + ",  Average Words in the Sentence: " + document.getAverageWordsInSentence();
        }

        private void button1_Click(object sender, EventArgs e) {
            //open the file
            OpenFileDialog openFile = new OpenFileDialog();

            openFile.Filter = "Text (*.txt; *.doc; *.docx; *.odt; *.rtf; *.pdf; *.chm)|*.txt; *.doc; *.docx; *.odt; *.rtf; *.pdf; *.chm ";

            if (openFile.ShowDialog() == DialogResult.OK)
                readText(openFile.FileName);
        }

        private void button2_Click(object sender, EventArgs e) {
            // Read dictionary words
            WordsPair words = new WordsPair();

            words.setWords(richTextBox1.Text.Split('\r', '\n'), richTextBox2.Text.Split('\r', '\n'));

            // Count average words in the sentance
            int wordsInSentance = document.getAverageWordsInSentence();

            // Check all the lines in the text
            foreach (string line in document.textBox.Text.Split('\r', '\n'))
                if (line.Split(' ').Length != 0 && line.Split(' ')[0] != "")
                    words.checkWords(line.Split(' '), wordsInSentance);
            // Output
            richTextBox3.Text = words.getResults();
        }
        // Drag and drop
        private void Form1_onDragEnter(object sender, DragEventArgs e) {
            pictureBox2.Visible = true;

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_onDragDrop(object sender, DragEventArgs e) {
            pictureBox2.Visible = false;

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            readText(files[0]);
        }

        private void Form1_onDragLeave(object sender, EventArgs e) {
            pictureBox2.Visible = false;
        }
    }

    public class Document {
        public RichTextBox textBox = new RichTextBox();
        int averageWordsInSentence;
        int wordsCount;

        public Document() {
            averageWordsInSentence = 0;
            wordsCount = 0;
        }

        public int getAverageWordsInSentence() {
            if(averageWordsInSentence == 0)
                averageWordsInSentence = textBox.Text.Split(' ').Length / textBox.Text.Split('.').Length;
            return averageWordsInSentence;
        }

        public int getWordsCount() {
            if(wordsCount == 0)
                wordsCount = textBox.Text.Split(' ').Length;
            return wordsCount;
        }

    }

    public class WordsPair
    {
        int[] foundCount;
        bool[] foundFirst;
        int[] currentBetween;
        int[] firstWordsCount;
        int[] secondWordsCount;
        string[] currentWord;
        Dictionary<string, int> words = new Dictionary<string, int>();

        public WordsPair() { }

        public void setWords(string[] firstWords, string[] secondWords) {
            int i = 0;
            foundCount = new int[2 * firstWords.Length * secondWords.Length];
            foundFirst = new bool[2 * firstWords.Length * secondWords.Length];
            currentBetween = new int[2 * firstWords.Length * secondWords.Length];
            firstWordsCount = new int[2 * firstWords.Length * secondWords.Length];
            secondWordsCount = new int[2 * firstWords.Length * secondWords.Length];
            currentWord = new string[2 * firstWords.Length * secondWords.Length];

            // Add First : Second to the search list
            foreach (string first in firstWords)
                foreach (string second in secondWords)
                    if (first != "" && second != "") {
                        foundCount[i] = 0;
                        foundFirst[i] = false;
                        currentBetween[i] = 0;
                        firstWordsCount[i] = first.Split(' ').Length;
                        secondWordsCount[i] = second.Split(' ').Length;
                        currentWord[i] = "";
                        words.Add(first.ToLower() + " : " + second.ToLower(), i++);
                    }

            // Add Second : First to the search list
            foreach (string second in secondWords)
                foreach (string first in firstWords)
                    if (first != "" && second != "") {
                        foundCount[i] = 0;
                        foundFirst[i] = false;
                        currentBetween[i] = 0;
                        firstWordsCount[i] = second.Split(' ').Length;
                        secondWordsCount[i] = first.Split(' ').Length;
                        currentWord[i] = "";
                        words.Add(second.ToLower() + " : " + first.ToLower(), i++);
                    }
        }

        public void checkWords(string[] line, int averageWordsInSentence) {
            string firstWord;
            string secondWord;
            string nextWord;
            int countWordsSearching;
            int spacePos;
            int secondWordLength;

            foreach (KeyValuePair<string, int> word in words) {
                spacePos = word.Key.IndexOf(" : ");
                if (spacePos - 3 > 0)
                    firstWord = word.Key.Substring(0, spacePos - 3);
                else
                    firstWord = word.Key.Substring(0, spacePos);
                secondWordLength = word.Key.Length - spacePos - 3;
                if (secondWordLength - 3 > 0)
                    secondWord = word.Key.Substring(spacePos + 3, secondWordLength - 3);
                else
                    secondWord = word.Key.Substring(spacePos + 3, secondWordLength);

                countWordsSearching = 0;

                for (int i = 0; i < line.Length; i++)
                    if (line[i] != "") {
                        nextWord = line[i].ToLower();
                        if (!foundFirst[word.Value]) {
                            if (nextWord.Contains(firstWord) && countWordsSearching < firstWordsCount[word.Value]) {
                                countWordsSearching++;
                                currentWord[word.Value] += nextWord + ' ';
                            } else if (currentWord[word.Value].Contains(firstWord) && countWordsSearching >= firstWordsCount[word.Value]) {
                                foundFirst[word.Value] = true;
                                countWordsSearching = 0;
                                currentBetween[word.Value] = 0;
                                currentWord[word.Value] = "";
                            }
                        } else {
                            if (nextWord.Contains(secondWord) && currentBetween[word.Value] <= averageWordsInSentence && countWordsSearching < secondWordsCount[word.Value]) {
                                countWordsSearching++;
                                currentWord[word.Value] += nextWord + ' ';
                            } else if (currentWord[word.Value].Contains(secondWord)) {
                                currentWord[word.Value] = "";
                                foundFirst[word.Value] = false;
                                currentBetween[word.Value] = 0;
                                foundCount[word.Value]++;
                            } else if (currentBetween[word.Value] != averageWordsInSentence) 
                                currentBetween[word.Value]++;
                        }
                    }
            }
        }

        public string getResults() {
            RichTextBox results = new RichTextBox();
            foreach (KeyValuePair<string, int> word in words)
                results.AppendText(word.Key + ' ' + '(' + foundCount[word.Value] +')' + '\r' + '\n');
            return results.Text;
        }

    }

}
