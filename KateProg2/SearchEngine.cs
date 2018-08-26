using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using Independentsoft.Office.Odf;
using System.IO;

namespace KateProg2
{
    public class SearchEngine
    {
        private List<Document> documents;
        private Dictionary<string, MainWord> mainWords;
        private List<WordsPair> wordsPairs;
        private List<string> negativeWords;
        private List<string> positiveWords;
        private List<string> neutralWords;

        public SearchEngine()
        {
            this.documents = new List<Document>();
            this.mainWords = new Dictionary<string, MainWord>();
            this.wordsPairs = new List<WordsPair>();
            this.negativeWords = new List<string>();
            this.positiveWords = new List<string>();
            this.neutralWords = new List<string>();
        }

        public uint GetDocumentsCount() => (uint)this.documents.Count;

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

        public void RemoveDocument(string path)
        {
            Parallel.ForEach(this.documents, (document) =>
            {
                if (document.GetPath().Contains(path))
                    this.documents.Remove(document);
            });
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

        public void AddMainWord(string word, string documentName)
        {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentException("Main word to add is null or empty", nameof(word));

            if (string.IsNullOrEmpty(documentName))
                throw new ArgumentException("documentName is null or empty", nameof(documentName));

            this.mainWords.Add(word, new MainWord(word, documentName));
        }

        public void ClearResults()
        {
            this.wordsPairs = new List<WordsPair>();
            this.mainWords = new Dictionary<string, MainWord>();
        }

        public void ComputeEntries()
        {
            Parallel.ForEach(this.documents, (currentDocument) =>
            {
                Parallel.ForEach(this.mainWords.Values, (mainWord) =>
                {
                    Parallel.ForEach(this.negativeWords, (negativeWord) =>
                    {
                        this.wordsPairs.Add(new WordsPair(mainWord.GetWord(), negativeWord, true, SecWordType.NEGATIVE, currentDocument.GetPath()));
                        this.wordsPairs.Add(new WordsPair(negativeWord, mainWord.GetWord(), false, SecWordType.NEGATIVE, currentDocument.GetPath()));
                    });
                    Parallel.ForEach(this.positiveWords, (positiveWord) =>
                    {
                        this.wordsPairs.Add(new WordsPair(mainWord.GetWord(), positiveWord, true, SecWordType.POSITIVE, currentDocument.GetPath()));
                        this.wordsPairs.Add(new WordsPair(positiveWord, mainWord.GetWord(), false, SecWordType.POSITIVE, currentDocument.GetPath()));
                    });
                    Parallel.ForEach(this.neutralWords, (neutralWord) =>
                    {
                        this.wordsPairs.Add(new WordsPair(mainWord.GetWord(), neutralWord, true, SecWordType.NEUTRAL, currentDocument.GetPath()));
                        this.wordsPairs.Add(new WordsPair(neutralWord, mainWord.GetWord(), false, SecWordType.NEUTRAL, currentDocument.GetPath()));
                    });
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
                                if (wordsPair != null)
                                    wordsPair.CheckWord(word.ToLower(), currentDocument.GetAverageWordsInSentence());
                            });
                    }
                }
            });

            Parallel.ForEach(this.wordsPairs, (wordPair) =>
            {
                if (wordPair != null)
                    this.mainWords[wordPair.GetMain()].AddEntries(wordPair);
            });
        }

        public List<MainWord> GetMainWords() => new List<MainWord>(this.mainWords.Values);

        public MainWord GetMainWord(string word) => this.mainWords[word];
    }
}
