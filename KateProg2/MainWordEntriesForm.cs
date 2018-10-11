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

                foreach (string posEntry in this.mainWord.GetPositiveEntries())
                    PositiveWordsRichTextBox.Text += posEntry + "\n\r";

                foreach (string negEntry in this.mainWord.GetNegativeEntries())
                    NegativeWordsRichTextBox.Text += negEntry + "\n\r";

                foreach (string neutrEntry in this.mainWord.GetNeutralEntries())
                    NeutralWordsRichTextBox.Text += neutrEntry + "\n\r";
            }
        }

    }
}
