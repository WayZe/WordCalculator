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
        // Части речи для слов из текста
        private List<String> partsOfSpeechFromTextList = new List<String>();
        // Список слов из текста
        private List<String> wordsFromFileList = new List<String>();
        // Текст файла
        private String fileString;
        // Путь к входному файла
        private const String inputFilePath = "D:\\Langs\\C#\\WordsCalculator\\InputFile.txt";
        // Путь к выходному файла
        private const String outputFilePath = "D:\\Langs\\C#\\WordsCalculator\\OutputFile.txt";
        // Массив окончаний прилагательных
        private String[] adjectiveEndsList = { "ая", "яя", "ой", "ей", "ую", "юю", "ый", "ий", "ого", "его", "ому", "ему", "ым", "им", "ом", "ем", "ое", "ее", "ых", "ые"};
        // Массив существующих частей речи
        private String[] allPartsOfSpeechArray = {"Прилагательное"};
        //
        private List<String> adjectiveFromTextList = new List<String>();

        List<int> amountOfEveryWords = new List<int>();

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

            stringListCreating();

            partsOfSpeechDetermining();

            wordAmountCalculation();

            writeFile();
        }

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

        /// <summary>
        /// Создание списка строк
        /// </summary>
        private void stringListCreating()
        {
            char[] separatorArray = {',', ' ', '.', '\n'};
            String[] wordArray = fileString.Split(separatorArray);

            foreach (String word in wordArray)
            {
                if(word != "")
                    wordsFromFileList.Add(word);
            }
        }

        /// <summary>
        /// Определение частей речи для всех слов
        /// </summary>
        private void partsOfSpeechDetermining()
        {
            for (int elementNumber = 0; elementNumber < wordsFromFileList.Count; elementNumber++)
                partsOfSpeechFromTextList.Add("");

            for (int elementNumber = 0; elementNumber < wordsFromFileList.Count; elementNumber++)
            {
                String currentWord = wordsFromFileList.ElementAt(elementNumber);

                bool isAdjective = false;

                for (int endNumber = 0; endNumber < adjectiveEndsList.Length; endNumber++)
                { 
                    if (currentWord.Length - adjectiveEndsList[endNumber].Length > 0)
                        if (currentWord.Substring(currentWord.Length - adjectiveEndsList[endNumber].Length) == adjectiveEndsList[endNumber])
                            isAdjective = true;
                }

                if (isAdjective)
                {
                    partsOfSpeechFromTextList[elementNumber] = allPartsOfSpeechArray[0];
                }
            }
        }

        /// <summary>
        /// Подсчёт количества слов
        /// </summary>
        private void wordAmountCalculation()
        {
            for (int elementNumber = 0; elementNumber < wordsFromFileList.Count; elementNumber++)
                amountOfEveryWords.Add(1);

            for (int currentElementNumber = 0; currentElementNumber < wordsFromFileList.Count; currentElementNumber++)
            {
                for (int anotherElementNumber = currentElementNumber + 1; anotherElementNumber < wordsFromFileList.Count; anotherElementNumber++)
                {
                    if (wordsFromFileList.ElementAt(currentElementNumber) == wordsFromFileList.ElementAt(anotherElementNumber))
                    {
                        wordsFromFileList.RemoveAt(anotherElementNumber);
                        partsOfSpeechFromTextList.RemoveAt(anotherElementNumber);
                        amountOfEveryWords[currentElementNumber]++;
                    }
                }
            }
        }

        private void writeFile()
        {
            using (StreamWriter outputFile = new StreamWriter(outputFilePath))
            {
                outputFile.WriteLine("{0,-20} {1,5:N0}", "Слово", "Количество");
                outputFile.WriteLine("      ПРИЛАГАТЕЛЬНЫЕ");
                for (int elementNumber = 0; elementNumber < partsOfSpeechFromTextList.Count; elementNumber++)
                {
                    if (partsOfSpeechFromTextList[elementNumber] == allPartsOfSpeechArray[0])
                        outputFile.WriteLine("{0,-20} {1,5:N0}", wordsFromFileList[elementNumber], amountOfEveryWords[elementNumber]);
                }
            }
        }
    }
}
