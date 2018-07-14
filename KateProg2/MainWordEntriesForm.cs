using System.Threading.Tasks;
using System.Windows.Forms;

namespace KateProg2
{
    public partial class MainWordEntriesForm : Form
    {
        private MainWord mainWord;

        public MainWordEntriesForm(MainWord mainWord)
        {
            InitializeComponent();

            if (mainWord != null)
            {
                this.mainWord = mainWord;

                MainWordLabel.Text = this.mainWord.GetWord();

                Parallel.ForEach(this.mainWord.GetPositiveEntries(), (posEntry) =>
                {
                    PositiveWordsRichTextBox.Text += posEntry + "\n\r";
                });

                Parallel.ForEach(this.mainWord.GetNegativeEntries(), (negEntry) =>
                {
                    NegativeWordsRichTextBox.Text += negEntry + "\n\r";
                });

                Parallel.ForEach(this.mainWord.GetNeutralEntries(), (neutrEntry) =>
                {
                    NeutralWordsRichTextBox.Text += neutrEntry + "\n\r";
                });
            }
        }

    }
}
