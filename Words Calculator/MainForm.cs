using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Words_Calculator
{
    public partial class mainForm : Form
    {
        #region Data
        // Части речи для слов из текста
        private List<String> listOfSpeechPartsFromText = new List<String>();
        // Список передложений из текста
        private List<String> listOfSentencesFromFile = new List<String>();
        // Список слов из текста
        private List<String> listOfWordsFromFile = new List<String>();
        // Текст файла
        private String fileString;
        // Путь к входному файла
        private const String inputFilePath = "D:\\Langs\\C#\\WordsCalculator\\InputFile.txt";
        // Путь к выходному файла
        private const String outputFilePath = "D:\\Langs\\C#\\WordsCalculator\\OutputFile.txt";
        // Массив окончаний прилагательных
        private String[] adjectiveEndsList = { "ая",  "яя",  "ой",  "ей",
                                               "ую",  "юю",  "ый",  "ий",
                                               "ого", "его", "ому", "ему",
                                               "ым",  "им",  "ом",  "ем",
                                               "ое",  "ее",  "ых",  "ые"};
        // Прилагательные из текста
        private List<String> listOfAdjectivesFromText = new List<String>();
        // Номер предложения для соответствующего слова
        private List<String> listOfSentenceNumberForWordsFromText = new List<String>();
        // Список количества слов
        private List<int> listOfEveryWordAmount = new List<int>();
        #endregion

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
            readText();

            fileString = fileString.ToLower();

            divisionBySentences();

            divisionByWords();

            adjectiveDetermining();
            
            wordAmountCalculation();

            writeFile();
        }
        #endregion

        #region Чтение из файла
        /// <summary>
        /// Чтение текста из файла
        /// </summary>
        private void readText()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(inputFilePath, Encoding.GetEncoding(1251)))
                {
                    fileString = streamReader.ReadToEnd();
                    Console.WriteLine(fileString);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Деление строки на предложения
        private void divisionBySentences()
        {
            // Массив знаков-разделителей предложений
            char[] sentenceSeparatorsArray = { '!', '?', '.'};

            String[] sentenceArray = fileString.Split(sentenceSeparatorsArray);

            foreach (String sentence in sentenceArray)
                if (sentence != "")
                    listOfSentencesFromFile.Add(sentence);
        }
        #endregion

        #region Деление предложений на слова
        private void divisionByWords()
        {
            // Массив знаков-разделителей предложений
            char[] wordSeparatorsArray = { ',', ' ', '\n' };

            for (int sentenceNumber = 0; sentenceNumber < listOfSentencesFromFile.Count; sentenceNumber++)
            {
                String[] wordArray = listOfSentencesFromFile[sentenceNumber].Split(wordSeparatorsArray);

                foreach (String word in wordArray)
                {
                    if (word != "")
                    {
                        listOfWordsFromFile.Add(word);
                        listOfSentenceNumberForWordsFromText.Add((sentenceNumber+1).ToString());
                        listOfEveryWordAmount.Add(1);
                    }
                }
            }
        }
        #endregion

        #region Поиск прилагательных
        /// <summary>
        /// Поиск прилагательных
        /// </summary>
        private void adjectiveDetermining()
        {
            for (int elementNumber = 0; elementNumber < listOfWordsFromFile.Count; elementNumber++)
                listOfSpeechPartsFromText.Add("");
            for (int elementNumber = 0; elementNumber < listOfWordsFromFile.Count; elementNumber++)
            {
                String currentWord = listOfWordsFromFile.ElementAt(elementNumber);
        
                bool isAdjective = false;
        
                // Проверка на то является ли currentWord прилагательным
                for (int endNumber = 0; endNumber < adjectiveEndsList.Length; endNumber++)
                { 
                    if (currentWord.Length - adjectiveEndsList[endNumber].Length > 0)
                        if (currentWord.Substring(currentWord.Length - adjectiveEndsList[endNumber].Length) 
                            == adjectiveEndsList[endNumber])
                            isAdjective = true;
                }
        
                // Если currentWord - прилагательное, то добавляем его в список прилагательных
                if (isAdjective)
                {
                    Console.WriteLine(elementNumber);
                    listOfSpeechPartsFromText[elementNumber] = "Прилагательное";
                }
        
            }
        }
        #endregion

        #region Подсчёт количества слов
        private void wordAmountCalculation()
        {
            for (int currentElementNumber = 0; currentElementNumber < listOfWordsFromFile.Count; currentElementNumber++)
            {
                for (int anotherElementNumber = currentElementNumber + 1; anotherElementNumber < listOfWordsFromFile.Count; anotherElementNumber++)
                {
                    if (listOfWordsFromFile.ElementAt(currentElementNumber) == listOfWordsFromFile.ElementAt(anotherElementNumber))
                    {
                        listOfWordsFromFile.RemoveAt(anotherElementNumber);
                        listOfSpeechPartsFromText.RemoveAt(anotherElementNumber);
                        listOfEveryWordAmount[currentElementNumber]++;
                        listOfSentenceNumberForWordsFromText[currentElementNumber] =
                            listOfSentenceNumberForWordsFromText[currentElementNumber] + "," +
                            listOfSentenceNumberForWordsFromText[anotherElementNumber];
                        listOfSentenceNumberForWordsFromText.RemoveAt(anotherElementNumber);
                    }
                }
            }
        }
        #endregion

        #region Запись данных в файл
        private void writeFile()
        {
            using (StreamWriter outputFile = new StreamWriter(outputFilePath))
            {
                outputFile.WriteLine("{0,-20} {1,5:N0} {2,5:N0}", "Слово", "Количество", "Номера предложений");
                outputFile.WriteLine("      ПРИЛАГАТЕЛЬНЫЕ");
                for (int elementNumber = 0; elementNumber < listOfSpeechPartsFromText.Count; elementNumber++)
                {
                    if (listOfSpeechPartsFromText[elementNumber] == "Прилагательное")
                    {
                        outputFile.WriteLine("{0,-20} {1,5:N0}             {2,-1:N0}", 
                            listOfWordsFromFile[elementNumber],
                            listOfEveryWordAmount[elementNumber],
                            listOfSentenceNumberForWordsFromText[elementNumber]);
                    }
                }
            }
        }
        #endregion
    }
}
