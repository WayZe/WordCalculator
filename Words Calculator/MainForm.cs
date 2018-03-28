using System;
using System.Windows.Forms;
using System.Data;

/// <summary>
/// Осуществляет работу с событиями.
/// </summary>
namespace Words_Calculator
{

    public partial class mainForm : Form
    {
        private DataTable table = new DataTable();
        private bool isSelectedPartOfSpeech = false;
        private bool isInputText = false;

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
            btnSearch.Enabled = false;

            WordCalculator.readSupportFile();

            cmbPartsOfSpeech.Items.Add("Имя существительное");
            cmbPartsOfSpeech.Items.Add("Имя прилагательное");
            cmbPartsOfSpeech.Items.Add("Глагол");
            cmbPartsOfSpeech.Items.Add("Наречие");
            cmbPartsOfSpeech.Items.Add("Причастие");
            cmbPartsOfSpeech.Items.Add("Деепричастие");
            cmbPartsOfSpeech.Items.Add("Остальные части речи");
            cmbPartsOfSpeech.Items.Add("Полный анализ");

            WordCalculator.InitGrid(ref dgrvFoundWords, ref table);
        }

        public void Clear(DataGridView dataGridView)
        {
            while (dataGridView.Rows.Count > 1)
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                    dataGridView.Rows.Remove(dataGridView.Rows[i]);
        }

        /// <summary>
        /// Нажатие кнопки "Анализ".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {

            // Очистка таблицы.
            Clear(dgrvFoundWords);

            WordCalculator.clearData();

            WordCalculator.FileString = tbInputText.Text;

            WordCalculator.divideIntoSentences();
            
            WordCalculator.writeFileWithSentenceNumber();
            
            WordCalculator.divideIntoWords();

            WordCalculator.findDictionary();

            WordCalculator.findDeeprichastie();

            WordCalculator.findVerb();

            WordCalculator.findParticiple();

            WordCalculator.findAdjectivesWithMinFirstKindError();

            WordCalculator.findAdverb();

            WordCalculator.findNoun();

            WordCalculator.countWordAmount();
            
            WordCalculator.correctWordAmount();

            WordCalculator.sortOfWords();

            // Вывод в файл.
            if (FileHandler.IsOpenOutputFile)
            {
                switch (cmbPartsOfSpeech.SelectedIndex)
                {
                    case 0:
                        WordCalculator.writeInFiles("Существительное");
                        break;
                    case 1:
                        WordCalculator.writeInFiles("Прилагательное");
                        break;
                    case 2:
                        WordCalculator.writeInFiles("Глагол");
                        break;
                    case 3:
                        WordCalculator.writeInFiles("Наречие");
                        break;
                    case 4:
                        WordCalculator.writeInFiles("Причастие");
                        break;
                    case 5:
                        WordCalculator.writeInFiles("Деепричастие");
                        break;
                    case 6:
                        WordCalculator.writeInFiles("Остальные части речи");
                        break;
                    case 7:
                        WordCalculator.writeInFiles("Существительное");
                        WordCalculator.writeInFiles("Прилагательное");
                        WordCalculator.writeInFiles("Глагол");
                        WordCalculator.writeInFiles("Наречие");
                        WordCalculator.writeInFiles("Причастие");
                        WordCalculator.writeInFiles("Деепричастие");
                        WordCalculator.writeInFiles("Остальные части речи");
                        break;
                }
            }
            
            // Заполнение таблицы.
            switch (cmbPartsOfSpeech.SelectedIndex)
            {
                case 0:
                    WordCalculator.FillGrid("Существительное", ref dgrvFoundWords, ref table);
                    break;
                case 1:
                    WordCalculator.FillGrid("Прилагательное", ref dgrvFoundWords, ref table);
                    break;
                case 2:
                    WordCalculator.FillGrid("Глагол", ref dgrvFoundWords, ref table);
                    break;
                case 3:
                    WordCalculator.FillGrid("Наречие", ref dgrvFoundWords, ref table);
                    break;
                case 4:
                    WordCalculator.FillGrid("Причастие", ref dgrvFoundWords, ref table);
                    break;
                case 5:
                    WordCalculator.FillGrid("Деепричастие", ref dgrvFoundWords, ref table);
                    break;
                case 6:
                    WordCalculator.FillGrid("Остальные части речи", ref dgrvFoundWords, ref table);
                    break;
                case 7:
                    WordCalculator.FillGrid("Существительное", ref dgrvFoundWords, ref table);
                    WordCalculator.FillGrid("Прилагательное", ref dgrvFoundWords, ref table);
                    WordCalculator.FillGrid("Глагол", ref dgrvFoundWords, ref table);
                    WordCalculator.FillGrid("Наречие", ref dgrvFoundWords, ref table);
                    WordCalculator.FillGrid("Причастие", ref dgrvFoundWords, ref table);
                    WordCalculator.FillGrid("Деепричастие", ref dgrvFoundWords, ref table);
                    WordCalculator.FillGrid("Остальные части речи", ref dgrvFoundWords, ref table);
                    break;
            }

            // Вывод статистики.
            switch (cmbPartsOfSpeech.SelectedIndex)
            {
                case 0:
                    WordCalculator.DisplayStatistics("Существительное");
                    tbStatistics.Text = "Существительных " + WordCalculator.CountForOne;
                    tbStatistics.Text += "\r\nВсего слов " + WordCalculator.CountForMany;
                    break;
                case 1:
                    WordCalculator.DisplayStatistics("Прилагательное");
                    tbStatistics.Text = "Прилагательных " + WordCalculator.CountForOne;
                    tbStatistics.Text += "\r\nВсего слов " + WordCalculator.CountForMany;
                    break;
                case 2:
                    WordCalculator.DisplayStatistics("Глагол");
                    tbStatistics.Text = "Глаголов " + WordCalculator.CountForOne;
                    tbStatistics.Text += "\r\nВсего слов " + WordCalculator.CountForMany;
                    break;
                case 3:
                    WordCalculator.DisplayStatistics("Наречие");
                    tbStatistics.Text = "Наречий " + WordCalculator.CountForOne;
                    tbStatistics.Text += "\r\nВсего слов " + WordCalculator.CountForMany;
                    break;
                case 4:
                    WordCalculator.DisplayStatistics("Причастие");
                    tbStatistics.Text = "Причастий " + WordCalculator.CountForOne;
                    tbStatistics.Text += "\r\nВсего слов " + WordCalculator.CountForMany;
                    break;
                case 5:
                    WordCalculator.DisplayStatistics("Деепричастие");
                    tbStatistics.Text = "Деепричастий " + WordCalculator.CountForOne;
                    tbStatistics.Text += "\r\nВсего слов " + WordCalculator.CountForMany;
                    break;
                case 6:
                    WordCalculator.DisplayStatistics("Остальные части речи");
                    tbStatistics.Text = "Остальные части " + WordCalculator.CountForOne;
                    tbStatistics.Text += "\r\nВсего слов " + WordCalculator.CountForMany;
                    break;
                case 7:
                    WordCalculator.DisplayStatistics("Существительное");
                    tbStatistics.Text = "Существительных " + WordCalculator.CountForOne;
                    WordCalculator.DisplayStatistics("Прилагательное");
                    tbStatistics.Text += "\r\nПрилагательных " + WordCalculator.CountForOne;
                    WordCalculator.DisplayStatistics("Глагол");
                    tbStatistics.Text += "\r\nГлаголов " + WordCalculator.CountForOne;
                    WordCalculator.DisplayStatistics("Наречие");
                    tbStatistics.Text += "\r\nНаречий " + WordCalculator.CountForOne;
                    WordCalculator.DisplayStatistics("Причастие");
                    tbStatistics.Text += "\r\nПричастий " + WordCalculator.CountForOne;
                    WordCalculator.DisplayStatistics("Деепричастие");
                    tbStatistics.Text += "\r\nДеепричастий " + WordCalculator.CountForOne;
                    tbStatistics.Text += "\r\nВсего слов " + WordCalculator.CountForMany;
                    break;
            }
            // СОРРЕ ЗА КОСТЫЛИ.
            if (this.Width < 700)
                this.Width += 550;

            FileHandler.IsEmptyOutputFile = true;
            //FileHandler.IsOpenInputFile = false;

        }

        /// <summary>
        /// Обработчик события клика по кнопке "Выбрать входной файл".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseInputFile_Click(object sender, EventArgs e)
        {
            // Получение пути к входному файлу.
            FileHandler.InputTextFilePath = FileHandler.PutFilePath();
            // Вывод пути к входному файлу на экран в TextBox.
            tbInputFilePath.Text = FileHandler.InputTextFilePath;
            // Чтение входного файла.
            WordCalculator.readInputTextFile(ref tbInputText);
        }

        /// <summary>
        /// Обработчик события клика по кнопке "Выбрать выходной файл".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseOutputFile_Click(object sender, EventArgs e)
        {
            // Получение пути к входному файлу.
            FileHandler.OutputFilePath = FileHandler.PutFilePath();
            // Вывод пути к выходному файлу в TextBox.
            tbOutputFilePath.Text = FileHandler.OutputFilePath;
            // Поднятия флага о том, что есть открытый выходной файл.
            FileHandler.IsOpenOutputFile = true;
        }

        /// <summary>
        /// Обработчик события изменения Textbox с входным текстом.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbInputText_TextChanged(object sender, EventArgs e)
        {
            // Если в Textbox отсутствует текст, то кнопка "Анализ" блокируется, иначе - нет.
            if (tbInputText.Text == "")
            {
                isInputText = false;
            }
            else
            {
                isInputText = true;
            }

            btnSearch.Enabled = isSelectedPartOfSpeech && isInputText;
        }

        /// <summary>
        /// Обработчик события клика по ячейке таблицы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drwvFoundWords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String selectedCellText = dgrvFoundWords.CurrentRow.Cells[0].Value.ToString();
            WordCalculator.PutSentencesForWord(selectedCellText, ref tbSentences);
        }

        /// <summary>
        /// Обработчик события клика по кнопке "Очистить".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearInputTextBox_Click(object sender, EventArgs e)
        {
            // Вывод окна предупреждения об очистке данных.
            DialogResult result = MessageBox.Show("Вы уверены, что хотите очистить ВСЁ?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //Если нажал "Да".
            if (result == DialogResult.Yes) 
            {
                tbInputText.Text = "";
                FileHandler.InputTextFilePath = "";
                tbInputFilePath.Text = FileHandler.InputTextFilePath;
                Clear(dgrvFoundWords);
                WordCalculator.FileString = "";
                WordCalculator.clearData();
                if (this.Width > 700)
                    this.Width -= 550;
            }
        }

        private void cmbPartsOfSpeech_SelectedIndexChanged(object sender, EventArgs e)
        {

            isSelectedPartOfSpeech  = true;

            btnSearch.Enabled = isSelectedPartOfSpeech && isInputText;
        }
    }
}