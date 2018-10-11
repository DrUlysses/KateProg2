using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KateProg2
{
    public class Document
    {
        public System.Windows.Forms.RichTextBox textBox = new System.Windows.Forms.RichTextBox();
        private uint averageWordsInSentence;
        private int wordsCount;
        private string path;
        private List<WordsPair> wordsPairs;
        private Dictionary<string, MainWord> mainWords;

        public Document(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Document path is null or empty", nameof(path));

            this.path = path;
            this.averageWordsInSentence = 0;
            this.wordsCount = 0;
            this.wordsPairs = new List<WordsPair>();
            this.mainWords = new Dictionary<string, MainWord>();
        }

        public uint GetAverageWordsInSentence()
        {
            if (averageWordsInSentence == 0)
            {
                if (this.wordsCount == 0)
                    averageWordsInSentence = (uint)(this.textBox.Text.Split(' ').Length / this.textBox.Text.Split('.').Length);
                else
                    averageWordsInSentence = (uint)(this.wordsCount / textBox.Text.Split('.').Length);
            }

            return averageWordsInSentence;
        }

        public int GetWordsCount()
        {
            if (wordsCount == 0)
                wordsCount = textBox.Text.Split(' ').Length;
            return wordsCount;
        }

        public void UpdateEntries()
        {
            foreach (WordsPair wordPair in this.wordsPairs)
                if (this.mainWords.ContainsKey(wordPair.GetMain()))
                    this.mainWords[wordPair.GetMain()].AddEntries(wordPair);
        }

        public void AddNegativeWords(List<string> words)
        {
            foreach (MainWord mainWord in this.mainWords.Values)
                foreach (string negativeWord in words)
                {
                    AddWordsPair(new WordsPair(mainWord.GetWord(), negativeWord, true, SecWordType.NEGATIVE));
                    AddWordsPair(new WordsPair(negativeWord, mainWord.GetWord(), false, SecWordType.NEGATIVE));
                }
        }

        public void AddPositiveWords(List<string> words)
        {
            foreach (MainWord mainWord in this.mainWords.Values)
                foreach (string positiveWord in words)
                {
                    AddWordsPair(new WordsPair(mainWord.GetWord(), positiveWord, true, SecWordType.POSITIVE));
                    AddWordsPair(new WordsPair(positiveWord, mainWord.GetWord(), false, SecWordType.POSITIVE));
                }
        }

        public void AddNeutralWords(List<string> words)
        {
            foreach (MainWord mainWord in this.mainWords.Values)
                foreach (string neutralWord in words)
                {
                    AddWordsPair(new WordsPair(mainWord.GetWord(), neutralWord, true, SecWordType.NEUTRAL));
                    AddWordsPair(new WordsPair(neutralWord, mainWord.GetWord(), false, SecWordType.NEUTRAL));
                }
        }

        public async Task ComputeEntries()
        {
            foreach (string line in this.textBox.Text.Split('\r', '\n'))
            {
                string[] lineWords = line.Split(' ');
                if (lineWords.Length != 0 && lineWords[0] != "")
                { //TODO: handle "-" on line endings.
                    foreach (string word in lineWords)
                        Parallel.ForEach(this.wordsPairs, (wordsPair) =>
                        {
                            if (wordsPair != null && !word.Equals(""))
                                wordsPair.CheckWord(word.ToLower(), this.GetAverageWordsInSentence());
                        });
                }
            }
        }

        public string GetPath() => this.path;

        public void AddWordsPair(WordsPair wordsPair)
        {
            if (!wordsPair.GetMain().Equals("") && wordsPair != null)
                this.wordsPairs.Add(wordsPair);
        }

        public List<WordsPair> GetWordsPairs() => this.wordsPairs;

        public void DeleteWords()
        {
            this.wordsPairs = new List<WordsPair>();
            this.mainWords = new Dictionary<string, MainWord>();
        }

        public List<MainWord> GetMainWords() => new List<MainWord>(this.mainWords.Values);

        public void AddMainWord(MainWord mainWord)
        {
            if (mainWord != null)
                this.mainWords.Add(mainWord.GetWord(), mainWord);
        }

        public MainWord GetMainWord(string wordName)
        {
            if (this.mainWords.ContainsKey(wordName))
                return this.mainWords[wordName];
            else
                return null;
        }
    }
}
