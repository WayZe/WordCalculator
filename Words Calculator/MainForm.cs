using System;
using System.Windows.Forms;

/// <summary>
/// Осуществляет работу с событиями
/// </summary>
namespace Words_Calculator
{
    public partial class mainForm : Form
    {
        

        #region Actions
        public mainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainForm_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Нажатие кнопки "Искать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchButton_Click(object sender, EventArgs e)
        {
            WordCalculator.readInputTextFile();

            WordCalculator.readInputEndsFile();

            WordCalculator.divideIntoSentences();
            
            WordCalculator.writeFileWithSentenceNumber();
            
            WordCalculator.divideIntoWords();
            
            WordCalculator.findAdjectivesWithMinFirstKindError();
            
            WordCalculator.findAdjectivesWithMinSecondKindError();
            
            WordCalculator.countWordAmount();
            
            WordCalculator.correctWordAmount();

            WordCalculator.sortOfWords();
            
            WordCalculator.writeInFiles();

            WordCalculator.clearData();
        }

        #endregion

        private void chbAll_CheckedChanged(object sender, EventArgs e)
        {
                chbNoun.Checked = chbAll.Checked;
                chbAdjective.Checked = chbAll.Checked;
                chbVerb.Checked = chbAll.Checked;
                chbAdverb.Checked = chbAll.Checked;
                chbParticiple.Checked = chbAll.Checked;
                chbDeeprichastie.Checked = chbAll.Checked;
        }
    }
}
