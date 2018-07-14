using System;
using System.Collections.Generic;

namespace KateProg2
{
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
            {
                findFirst = true;
                this.entry += word;
            }
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
