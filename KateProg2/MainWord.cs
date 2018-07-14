using System;
using System.Collections.Generic;

namespace KateProg2
{
    public class MainWord
    {
        private string word;
        private List<string> positiveEntries;
        private List<string> negativeEntries;
        private List<string> neutralEntries;

        public MainWord(string word)
        {
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
            uint negativeCount = (uint)this.negativeEntries.Count;
            uint positiveCount = (uint)this.positiveEntries.Count;
            uint neutralCount = (uint)this.neutralEntries.Count;
            if (negativeCount > positiveCount && negativeCount >= 2)
                return this.word + " [ positive ( " + positiveCount +
                                    " )  ***negative ( " + negativeCount +
                                    " )***  neutral ( " + neutralCount +
                                    " ) ]";
            else if (positiveCount > negativeCount && positiveCount >= 2)
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

        public List<string> GetPositiveEntries() => this.positiveEntries;
        public List<string> GetNegativeEntries() => this.negativeEntries;
        public List<string> GetNeutralEntries() => this.neutralEntries;
    }
}
