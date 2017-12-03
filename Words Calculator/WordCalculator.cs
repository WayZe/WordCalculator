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

public class WordCalculator
{
    #region Переменные
    // Части речи для слов из текста
    private static List<String> listOfSpeechPartsFromText = new List<String>();
    // Списоstatic к передложений из текста
    private static List<String> listOfSentencesFromFile = new List<String>();
    // Списоstatic к слов из текста
    private static List<String> listOfWordsFromFile = new List<String>();
    // Текст файла
    private static String fileString;
    // Путь к входному файла
    private const String inputFilePath = @"D:\Langs\C#\PPO\WordCalculator\InputFile.txt";
    // Путь к выходному файла c ошибкой первого рода
    private const String firstKindErrorFilePath = @"D:\Langs\C#\PPO\WordCalculator\FirstKindErrorOutputFile.txt";
    // Путь к выходному файла с ошибкой второго рода
    private const String secondKindErrorFilePath = @"D:\Langs\C#\PPO\WordCalculator\SecondKindErrorOutputFile.txt";
    // Путь к выходному файла с пронумерованными предложениями
    private const String sentencesWithNumberFilePath = @"D:\Langs\C#\PPO\WordCalculator\SentencesWithNumberOutputFile.txt";
    // Массив окончаний прилагательных
    private static String[] arrayOfAdjectiveEnds = { "ая",  "яя",  "ой",  "ей",
                                                     "ую",  "юю",  "ый",  "ий",
                                                     "ого", "его", "ому", "ему",
                                                     "ым",  "им",  "ом",  "ем",
                                                     "ое",  "ее",  "ых",  "ые"};
    // Массив суффиксов прилагательных
    private static String[] arrayOfAdjectiveSuffixes = { "ал",   "ел",   "ан",    "ян",
                                                  "аст",  "ат",   "ев",    "ов",
                                                  "еват", "оват", "ен",    "енн",
                                                  "онн",  "енск", "инск",  "ив",
                                                  "лив",  "чив",  "ин",    "ист",
                                                  "ит",   "овит", "к",     "л",
                                                  "н",    "шн",   "тельн", "уч",
                                                  "юч",   "яч",   "чат" };
    // Список найденных прилагательных с ошибкой первого рода
    private static List<String> listOfAdjectivesWithFirstTypeError = new List<String>();
    // Списоstatic к найденных прилагательных с ошибкой второго рода
    private static List<String> listOfAdjectivesWithSecondTypeError = new List<String>();
    // Номерstatic  предложения для соответствующего слова
    private static List<String> listOfSentenceNumberForWordsFromText = new List<String>();
    // Списоstatic к количества слов
    private static List<int> listOfEveryWordAmount = new List<int>();
    #endregion

    #region Чтение из файла
    /// <summary>
    /// Чтение текста из файла
    /// </summary>
    public static void readText()
    {
        try
        {
            using (StreamReader streamReader = new StreamReader(inputFilePath, Encoding.GetEncoding(1251)))
            {
                fileString = streamReader.ReadToEnd();
                fileString = fileString.ToLower();
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
    public static void divideIntoSentences()
    {
        // Массив знаков-разделителей предложений
        char[] sentenceSeparatorsArray = { '!', '?', '.' };

        String[] sentenceArray = fileString.Split(sentenceSeparatorsArray);

        foreach (String sentence in sentenceArray)
            if (sentence != "")
                listOfSentencesFromFile.Add(sentence);
    }
    #endregion

    #region Запись данных в файл
    public static void writeFileWithSentenceNumber()
    {
        using (StreamWriter outputFile = new StreamWriter(sentencesWithNumberFilePath))
        {
            for (int elementNumber = 0; elementNumber < listOfSentencesFromFile.Count; elementNumber++)
            {
                outputFile.WriteLine(elementNumber + 1 + ". " + listOfSentencesFromFile[elementNumber]);
            }
        }
    }
    #endregion

    #region Деление предложений на слова
    public static void divideIntoWords()
    {
        // Массив знаков-разделителей предложений
        char[] wordSeparatorsArray = { ',', ' ', '\n'};

        for (int sentenceNumber = 0; sentenceNumber < listOfSentencesFromFile.Count; sentenceNumber++)
        {
            String[] wordArray = listOfSentencesFromFile[sentenceNumber].Split(wordSeparatorsArray);

            foreach (String word in wordArray)
            {
                if (word != "")
                {
                    listOfWordsFromFile.Add(word);
                    listOfSentenceNumberForWordsFromText.Add((sentenceNumber + 1).ToString());
                    listOfEveryWordAmount.Add(1);
                }
            }
        }
    }
    #endregion

    #region Поиск прилагательных с минимальной ошибкой первого рода
    /// <summary>
    /// Поиск прилагательных с минимальной ошибкой первого рода
    /// </summary>
    public static void findAdjectivesWithMinFirstKindError()
    {
        for (int elementNumber = 0; elementNumber < listOfWordsFromFile.Count; elementNumber++)
            listOfSpeechPartsFromText.Add("");
        for (int elementNumber = 0; elementNumber < listOfWordsFromFile.Count; elementNumber++)
        {
            String currentWord = listOfWordsFromFile.ElementAt(elementNumber);

            bool isAdjective = false;

            // Проверка на то является ли currentWord прилагательным
            for (int endNumber = 0; endNumber < arrayOfAdjectiveEnds.Length; endNumber++)
            {
                int wordLengthWithoutEnd = currentWord.Length - arrayOfAdjectiveEnds[endNumber].Length;
                if (wordLengthWithoutEnd > 0)
                    if (currentWord.Substring(wordLengthWithoutEnd) == arrayOfAdjectiveEnds[endNumber])
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

    #region Поиск прилагательных с минимальной ошибкой второго рода
    /// <summary>
    /// Поиск прилагательных с минимальной ошибкой второго рода
    /// </summary>
    public static void findAdjectivesWithMinSecondKindError()
    {
        for (int elementNumber = 0; elementNumber < listOfWordsFromFile.Count; elementNumber++)
        {
            if (listOfSpeechPartsFromText[elementNumber] == "Прилагательное")
            {
                String currentWord = listOfWordsFromFile.ElementAt(elementNumber);

                bool isAdjective = false;

                // Проверка на то является ли currentWord прилагательным
                for (int endNumber = 0; endNumber < arrayOfAdjectiveEnds.Length; endNumber++)
                {
                    for (int suffixNumber = 0; suffixNumber < arrayOfAdjectiveEnds.Length; suffixNumber++)
                    {
                        int wordLengthWitoutEndandSuffix =
                            currentWord.Length - arrayOfAdjectiveEnds[endNumber].Length
                                               - arrayOfAdjectiveSuffixes[suffixNumber].Length;

                        if (wordLengthWitoutEndandSuffix > 0)
                            if (currentWord.Substring(wordLengthWitoutEndandSuffix, 
                                arrayOfAdjectiveSuffixes[suffixNumber].Length) 
                                == arrayOfAdjectiveSuffixes[suffixNumber])
                                isAdjective = true;
                    }
                }

                // Если currentWord - прилагательное, то добавляем его в список прилагательных
                if (isAdjective)
                {
                    Console.WriteLine(elementNumber);
                    listOfAdjectivesWithSecondTypeError.Add(currentWord);
                }
            }
        }
    }
    #endregion

    #region Подсчёт количества слов
    public static void countWordAmount()
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
                    anotherElementNumber--;
                }
            }
        }
    }
    #endregion

    #region Корректировка номеров предложений для каждого слова
    public static void correctWordAmount()
    {
        for (int wordNumber = 0; wordNumber < listOfSentenceNumberForWordsFromText.Count; wordNumber++)
        {
            String[] arrayOfSentenceNumbersForWord = listOfSentenceNumberForWordsFromText[wordNumber].Split(',');

            List<String> listOfSentenceNumbersForWord = new List <String>();

            for (int elementNumber = 0; elementNumber < arrayOfSentenceNumbersForWord.Length; elementNumber++)
            {
                listOfSentenceNumbersForWord.Add(arrayOfSentenceNumbersForWord[elementNumber]);
            }

            for (int currentElementNumber = 0; currentElementNumber < listOfSentenceNumbersForWord.Count; currentElementNumber++)
            {
                for (int anotherElementNumber = currentElementNumber + 1; anotherElementNumber < listOfSentenceNumbersForWord.Count; anotherElementNumber++)
                {
                    if (listOfSentenceNumbersForWord[currentElementNumber] == listOfSentenceNumbersForWord[anotherElementNumber])
                    {
                        listOfSentenceNumbersForWord.RemoveAt(anotherElementNumber);
                        anotherElementNumber--;
                    }
                }
            }

            listOfSentenceNumberForWordsFromText[wordNumber] = listOfSentenceNumbersForWord[0];
            for (int elementNumber = 1; elementNumber < listOfSentenceNumbersForWord.Count; elementNumber++)
            {
                listOfSentenceNumberForWordsFromText[wordNumber] +=
                    "," + listOfSentenceNumbersForWord[elementNumber];
            }
        }
    }
    #endregion

    #region Запись данных в файл
    public static void writeFiles()
    {
        using (StreamWriter outputFile = new StreamWriter(firstKindErrorFilePath))
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

        using (StreamWriter outputFile = new StreamWriter(secondKindErrorFilePath))
        {
            outputFile.WriteLine("{0,-20} {1,5:N0} {2,5:N0}", "Слово", "Количество", "Номера предложений");
            outputFile.WriteLine("      ПРИЛАГАТЕЛЬНЫЕ");
            for (int listOfAdjectivesWithSecondTypeErrorElement = 0; listOfAdjectivesWithSecondTypeErrorElement < listOfAdjectivesWithSecondTypeError.Count; listOfAdjectivesWithSecondTypeErrorElement++)
            {
                for (int listOfWordsFromFileElement = 0; listOfWordsFromFileElement < listOfWordsFromFile.Count; listOfWordsFromFileElement++)
                {
                    if (listOfAdjectivesWithSecondTypeError[listOfAdjectivesWithSecondTypeErrorElement]
                        == listOfWordsFromFile[listOfWordsFromFileElement])
                        outputFile.WriteLine("{0,-20} {1,5:N0}             {2,-1:N0}",
                            listOfWordsFromFile[listOfWordsFromFileElement],
                            listOfEveryWordAmount[listOfWordsFromFileElement],
                            listOfSentenceNumberForWordsFromText[listOfWordsFromFileElement]);
                }
            }
        }
    }
    #endregion
}