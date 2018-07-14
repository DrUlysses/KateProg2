using System;

namespace KateProg2
{
    public class Document
    {
        public System.Windows.Forms.RichTextBox textBox = new System.Windows.Forms.RichTextBox();
        private uint averageWordsInSentence;
        private int wordsCount;
        private string path;

        public Document(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Document path is null or empty", nameof(path));

            this.path = path;
            this.averageWordsInSentence = 0;
            this.wordsCount = 0;
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

        public string GetPath() => this.path;
    }
}
