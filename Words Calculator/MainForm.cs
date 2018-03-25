using System;
using System.Windows.Forms;

/// <summary>
/// Осуществляет работу с событиями.
/// </summary>
namespace Words_Calculator
{

    public partial class mainForm : Form
    {
        // Переменная, показывающая откуда идет чтение, может иметь три значения: "file", "screen" и "".
        String readingFrom;

        public mainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Загрузка формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mainForm_Load(object sender, EventArgs e)
        {
            grbPartsOfSpeech.Enabled = FileHandler.IsOpenInputFile;
            btnSearch.Enabled = FileHandler.IsOpenInputFile;
        }

        /// <summary>
        /// Нажатие кнопки "Анализ".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (FileHandler.IsOpenInputFile)
                WordCalculator.readInputTextFile();
            else if (tbInputText.Text != "")
                WordCalculator.FileString = tbInputText.Text;

            WordCalculator.readSupportFile();

            WordCalculator.divideIntoSentences();
            
            WordCalculator.writeFileWithSentenceNumber();
            
            WordCalculator.divideIntoWords();

            WordCalculator.findDictionary();

            WordCalculator.findDeeprichastie();

            WordCalculator.findAdverb();    

            WordCalculator.findParticiple();

            WordCalculator.findAdjectivesWithMinFirstKindError();

            WordCalculator.findVerb();

            WordCalculator.findNoun();

            WordCalculator.countWordAmount();
            
            WordCalculator.correctWordAmount();

            WordCalculator.sortOfWords();

            if (FileHandler.IsOpenOutputFile)
            {
                if (chbAdjective.Checked == true)
                    WordCalculator.writeInFiles("Прилагательное", ref tbInputText);

                if (chbVerb.Checked == true)
                    WordCalculator.writeInFiles("Глагол", ref tbInputText);

                if (chbAdverb.Checked == true)
                    WordCalculator.writeInFiles("Наречие", ref tbInputText);

                if (chbParticiple.Checked == true)
                    WordCalculator.writeInFiles("Причастие", ref tbInputText);

                if (chbDeeprichastie.Checked == true)
                    WordCalculator.writeInFiles("Деепричастие", ref tbInputText);

                if (chbAnotherParts.Checked == true)
                    WordCalculator.writeInFiles("Слова из словаря", ref tbInputText);

                if (chbNoun.Checked == true)
                    WordCalculator.writeInFiles("Существительное", ref tbInputText);
            }

            WordCalculator.clearData();
        }

        private void chbAll_CheckedChanged(object sender, EventArgs e)
        {
                chbNoun.Checked = chbAll.Checked;
                chbAdjective.Checked = chbAll.Checked;
                chbVerb.Checked = chbAll.Checked;
                chbAdverb.Checked = chbAll.Checked;
                chbParticiple.Checked = chbAll.Checked;
                chbDeeprichastie.Checked = chbAll.Checked;
        }

        private void btnChooseInputFile_Click(object sender, EventArgs e)
        {
            FileHandler.InputTextFilePath = FileHandler.PutFilePath();
            tbInputFilePath.Text = FileHandler.InputTextFilePath;
            grbPartsOfSpeech.Enabled = FileHandler.IsOpenInputFile;
            btnSearch.Enabled = FileHandler.IsOpenInputFile;
        }

        private void btnClearTextBox_Click(object sender, EventArgs e)
        {
            tbInputText.Text = "";
        }

        private void btnChooseOutputFile_Click(object sender, EventArgs e)
        {
            FileHandler.OutputFilePath = FileHandler.PutFilePath();
            tbOutputFilePath.Text = FileHandler.OutputFilePath;
            FileHandler.IsOpenOutputFile = true;
        }

        private void tbInputText_TextChanged(object sender, EventArgs e)
        {
            if (tbInputText.Text == "")
                readingFrom = "";
            else
                readingFrom = "screen";

            SelectInputMethod();
        }

        private void SelectInputMethod()
        {
            if (readingFrom == "")
            {
                tbInputText.Enabled = true;
                btnChooseInputFile.Enabled = true;
            }
            else if (readingFrom == "file")
            {
                tbInputText.Enabled = false;
                btnChooseInputFile.Enabled = true;
            }
            else if (readingFrom == "screen")
            {
                tbInputText.Enabled = false;
                btnChooseInputFile.Enabled = true;
            }


        }
    }
}
