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
        private Dictionary<string, Document> documents;
        private List<string> negativeWords;
        private List<string> positiveWords;
        private List<string> neutralWords;

        public SearchEngine()
        {
            this.documents = new Dictionary<string, Document>();
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

            this.documents.Add(fileName, document);
            //check counts
            return "Words in File ~ " + document.GetWordsCount() + ",  Average Words in the Sentence: " + document.GetAverageWordsInSentence();
        }

        public void RemoveDocument(string path)
        {
            Parallel.ForEach(this.documents.Values, (document) =>
            {
                if (document.GetPath().Contains(path))
                    this.documents.Remove(path);
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

            if (this.documents.ContainsKey(documentName))
                this.documents[documentName].AddMainWord(new MainWord(word, documentName));
        }

        public void ClearResults()
        {
            foreach (Document tempDoc in this.documents.Values)
                tempDoc.DeleteWords();
        }

        public void GenerateWordsPairs()
        {
            foreach (Document currentDocument in this.documents.Values)
            {
                currentDocument.AddNegativeWords(this.negativeWords);
                currentDocument.AddPositiveWords(this.positiveWords);
                currentDocument.AddNeutralWords(this.neutralWords);
            }
        }

        public async Task ComputeEntries(string documentName)
        {
            if (this.documents.ContainsKey(documentName))
            {
                await this.documents[documentName].ComputeEntries();
                this.documents[documentName].UpdateEntries();
            }
        }

        public List<MainWord> GetMainWords(string documentName)
        {
            if (this.documents.ContainsKey(documentName))
                return this.documents[documentName].GetMainWords();
            else
                return null;
        }

        public MainWord GetMainWord(string documentName, string wordName)
        {
            if (this.documents.ContainsKey(documentName))
                return this.documents[documentName].GetMainWord(wordName);
            else
                return null;
        }
    }
}
