using System;
using System.Collections.Generic;

namespace KateProg2
{
    public class MainWord
    {
        private string word;
        private string documentName;
        private List<WordsPair> wordsPairs;
        private List<string> positiveEntries;
        private List<string> negativeEntries;
        private List<string> neutralEntries;

        public MainWord(string word, string documentName)
        {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentException("First word is null or empty", nameof(word));

            if (string.IsNullOrEmpty(documentName))
                throw new ArgumentException("documentName is null or empty", nameof(documentName));

            this.word = word;
            this.documentName = documentName;
            this.positiveEntries = new List<string>();
            this.negativeEntries = new List<string>();
            this.neutralEntries = new List<string>();
            this.wordsPairs = new List<WordsPair>();
        }

        public string GetWord() => this.word;

        public void AddEntries(WordsPair wordsPair)
        {
            lock (this)
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
        }

        public override string ToString()
        {
            uint negativeCount = (uint)this.negativeEntries.Count;
            uint positiveCount = (uint)this.positiveEntries.Count;
            uint neutralCount = (uint)this.neutralEntries.Count;

            string result = "{ " + this.documentName + " } \n\r" + this.word;

            if (negativeCount > positiveCount && negativeCount >= 2)
                return result + " [ positive ( " + positiveCount +
                                    " )  ***negative ( " + negativeCount +
                                    " )***  neutral ( " + neutralCount +
                                    " ) ]";
            else if (positiveCount > negativeCount && positiveCount >= 2)
                return result + " [ ***positive ( " + positiveCount +
                                    " )***  negative ( " + negativeCount +
                                    " )  neutral ( " + neutralCount +
                                    " ) ]";
            else
                return result + " [ positive ( " + positiveCount +
                                    " )  negative ( " + negativeCount +
                                    " )  ***neutral ( " + neutralCount +
                                    " )*** ]";
        }

        public List<string> GetPositiveEntries() => this.positiveEntries;
        public List<string> GetNegativeEntries() => this.negativeEntries;
        public List<string> GetNeutralEntries() => this.neutralEntries;

        public void DeleteAllEntries()
        {
            this.positiveEntries = new List<string>();
            this.negativeEntries = new List<string>();
            this.neutralEntries = new List<string>();
        }
    }
}
