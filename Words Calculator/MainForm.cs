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
            searchComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            searchComboBox.Items.Add("Прилагательные");
            searchComboBox.SelectedIndex = 0;
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

            WordCalculator.countAllFoundWords();

            WordCalculator.sortOfWords();
            
            WordCalculator.writeInFiles();

            WordCalculator.clearData();
        }
        #endregion

        
    }
}
