using System;
using System.Collections.Generic;

namespace KateProg2
{
    public class WordsPair
    {
        private string firstWord;
        private List<string> firstWordSliced;
        private string secondWord;
        private List<string> secondWordSliced;
        private List<string> entries;
        private bool isFirstWordMain;
        private SecWordType secWordType;

        private int currentFirstWordSlicedPos; // Can be an iterator, but I want so.
        private int currentSecondWordSlicedPos;
        private uint distance;
        private bool findFirst;
        private string entry;
        private string tempEntry;

        public WordsPair(string firstWord, string secondWord, bool isFirstWordMain, SecWordType secWordType)
        {
            if (string.IsNullOrEmpty(firstWord))
                throw new ArgumentException("firstWord is null or empty", nameof(firstWord));

            if (string.IsNullOrEmpty(secondWord))
                throw new ArgumentException("secondWord is null or empty", nameof(secondWord));

            this.firstWord = firstWord;
            this.firstWordSliced = new List<string>(firstWord.Split(' '));
            if (this.firstWordSliced.Contains(""))
                this.firstWordSliced.Remove("");
            this.secondWord = secondWord;
            this.secondWordSliced = new List<string>(secondWord.Split(' '));
            if (this.secondWordSliced.Contains(""))
                this.secondWordSliced.Remove("");
            this.isFirstWordMain = isFirstWordMain;
            this.secWordType = secWordType;

            this.currentFirstWordSlicedPos = 0;
            this.currentSecondWordSlicedPos = 0;
            this.distance = 0;
            this.findFirst = false;
            this.entries = new List<string>();
            this.entry = "";
        }

        public void CheckWord(string word, uint distance)
        {
            lock (this)
            {
                if (string.IsNullOrEmpty(word))
                    throw new ArgumentException("Word to check is empty or null", nameof(word));

                if (!this.findFirst && AreWordsSame(this.firstWordSliced[this.currentFirstWordSlicedPos], word))
                {
                    this.currentFirstWordSlicedPos++;
                    this.tempEntry += word + ' ';
                    if (this.currentFirstWordSlicedPos >= this.firstWordSliced.ToArray().Length)
                    {
                        this.findFirst = true;
                        this.entry = tempEntry.Substring(0, tempEntry.Length - 1);
                        this.tempEntry = "";
                        this.currentFirstWordSlicedPos = 0;
                    }
                }
                else if (this.findFirst && AreWordsSame(this.secondWordSliced[this.currentSecondWordSlicedPos], word) && this.distance <= distance)
                {
                    this.currentSecondWordSlicedPos++;
                    this.tempEntry += ' ' + word;
                    if (this.currentSecondWordSlicedPos >= this.secondWordSliced.ToArray().Length)
                    {
                        this.distance = 0;
                        this.findFirst = false;
                        this.entries.Add(this.entry + this.tempEntry);
                        this.entry = "";
                        this.tempEntry = "";
                        this.currentSecondWordSlicedPos = 0;
                    }
                }
                else if (this.findFirst && this.distance <= distance)
                {
                    this.distance++;
                    this.entry += ' ' + word;
                }
                else if ((this.findFirst && this.distance > distance) ||
                    (this.currentSecondWordSlicedPos > 0 && !AreWordsSame(this.secondWordSliced[this.currentSecondWordSlicedPos], word)) ||
                    this.currentFirstWordSlicedPos > 0 && !AreWordsSame(this.firstWordSliced[this.currentFirstWordSlicedPos], word))
                {
                    this.distance = 0;
                    this.findFirst = false;
                    this.entry = "";
                    this.tempEntry = "";
                    this.currentFirstWordSlicedPos = 0;
                    this.currentSecondWordSlicedPos = 0;
                }
            }
        }

        private bool AreWordsSame(string first, string second)
        {
            return first.Substring(0, first.Length * 2 / 3).Equals(second.Substring(0, second.Length * 2 / 3));
        }

        public string GetMain() => this.isFirstWordMain ? this.firstWord : this.secondWord;

        public SecWordType GetSecWordType() => this.secWordType;

        public List<string> GetEntries() => this.entries;
    }
}
