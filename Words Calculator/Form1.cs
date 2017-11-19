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
        List<String> partsOfSpeechFromTextList = new List<String>();
        private List<String> stringList = new List<String>();
        private String fileString;
        private const String filePath = "D:\\Langs\\C#\\WordsCalculator\\InputFile.txt";
        private String[] adjectiveEndsList = { "ая", "яя", "ой", "ей", "ую", "юю", "ый", "ий", "ого", "его", "ому", "ему", "ым", "им", "ом", "ем", "ое", "ее", "ых", "ые"};
        private String[] allPartsOfSpeechArray = {"Прилагательное"};

        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            searchComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            searchComboBox.Items.Add(allPartsOfSpeechArray.ElementAt(0));
            searchComboBox.SelectedIndex = 0;

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            readText();

            listCreating();

            List<String> partsOfSpeechFromTextList = partsOfSpeechDetermining();

            int[] amountOfEveryWords = partsOfSpeechCalculation();

            for (int elementNumber = 0; elementNumber < partsOfSpeechFromTextList.Count; elementNumber++)
            {
                if (partsOfSpeechFromTextList[elementNumber] == allPartsOfSpeechArray[0])
                    Console.WriteLine(stringList[elementNumber] + " " + amountOfEveryWords[elementNumber]);
            }

        }

        private void readText()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader streamReader = new StreamReader(filePath, Encoding.GetEncoding(1251)))
                {
                    // Read the stream to a string, and write the string to the console.
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

        private void listCreating()
        {
            char[] separatorArray = {',', ' ', '.', '\n'};
            String[] separatorArrayt = fileString.Split(separatorArray);

            foreach (String element in separatorArrayt)
            {
                if(element != "")
                    stringList.Add(element);
            }
        }

        /// <summary>
        /// Определение частей речи для всех слов
        /// </summary>
        /// <returns> Возвращает список partsOfSpeechFromTextList, 
        /// каждый элемент partsOfSpeechFromTextList является частью речи 
        /// для элемента с таким же индексом из массива списка всех слов текста </returns>
        private List<String> partsOfSpeechDetermining()
        {
            for (int elementNumber = 0; elementNumber < stringList.Count; elementNumber++)
                partsOfSpeechFromTextList.Add("");

            for (int elementNumber = 0; elementNumber < stringList.Count; elementNumber++)
            {
                String currentWord = stringList.ElementAt(elementNumber);

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

            return partsOfSpeechFromTextList;
        }

        private int[] partsOfSpeechCalculation()
        {
            int[] amountOfEveryWords = new int[stringList.Count];
            for (int wordNumber = 0; wordNumber < stringList.Count; wordNumber++) amountOfEveryWords[wordNumber] = 1;

            for (int currentElementNumber = 0; currentElementNumber < stringList.Count; currentElementNumber++)
            {
                for (int anotherElementNumber = currentElementNumber + 1; anotherElementNumber < stringList.Count; anotherElementNumber++)
                {
                    if (stringList.ElementAt(currentElementNumber) == stringList.ElementAt(anotherElementNumber))
                    {
                        stringList.RemoveAt(anotherElementNumber);
                        partsOfSpeechFromTextList.RemoveAt(anotherElementNumber);
                        amountOfEveryWords[currentElementNumber]++;
                    }
                }
            }

            return amountOfEveryWords;
        }
    }
}
