using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// Осуществляет работу с частями речи(прилагательными)
/// </summary>
public class WordCalculator
{
    #region Данные

    // Текст файла
    private static String fileString;

    ///ПУТИ К ФАЙЛАМ
    // Путь к входному файлу с текстом
    private static String inputTextFilePath = @"";
    // Путь к входному вспомогательному файлу
    private const String inputSupportFilePath = @"D:\Langs\C#\PPO\WordCalculator\InputSupportFile.txt";
    // Путь к выходному файлу c ошибкой второго рода
    private const String secondKindErrorFilePath = @"D:\Langs\C#\PPO\WordCalculator\SecondKindErrorOutputFile.txt";
    // Путь к выходному файлу с ошибкой первого рода
    private const String firstKindErrorFilePath = @"D:\Langs\C#\PPO\WordCalculator\FirstKindErrorOutputFile.txt";
    // Путь к выходному файлу с пронумерованными предложениями
    private const String sentencesWithNumberFilePath = @"D:\Langs\C#\PPO\WordCalculator\SentencesWithNumberOutputFile.txt";
    
    ///РАЗДЕЛИТЕЛИ
    // Разделитель в вспомогательном файле
    private const char supportSeparator = ' ';
    // Разделитель для номеров предложений
    private const char sentenceNumberSeparator = ',';
    // Массив знаков-разделителей для предложений
    private static readonly char[] sentenceSeparatorsArray = { '!', '?', '.' };
    // Массив знаков-разделителей на слова
    private static char[] wordSeparatorsArray = { ' ',  ';',  ',',  ':',
                                                  '(',  ')',  '\\', '\"',
                                                  '\'', '\n', '\t', '\v', '\r' };

    ///ОСНОВНЫЕ СПИСКИ
    // Части речи для слов из текста
    private static List<String> listOfSpeechParts = new List<String>();
    // Список слов из текста
    private static List<String> listOfWords = new List<String>();
    // Номер предложения для соответствующего слова
    private static List<String> listOfSentenceNumbers = new List<String>();
    // Список количества слов
    private static List<int> listOfWordAmount = new List<int>();

    ///ВСПОМОГАТЕЛЬНЫЕ СПИСКИ
    // Список найденных прилагательных с ошибкой первого рода
    private static List<String> listOfAdjectivesWithFirstTypeError = new List<String>();
    // Список предложений из текста
    private static List<String> listOfSentences = new List<String>();

    ///ВСПОМОГАТЕЛЬНЫЕ МАССИВЫ
    // Массив окончаний прилагательных
    private static String[] arrayOfAdjectiveEnds;
    // Массив суффиксов прилагательных
    private static String[] arrayOfAdjectiveSuffixes;


    // Наличие открытого файла
    private static bool isOpenFile = false;
    public static bool IsOpenFile
    {
        get
        {
            if (inputTextFilePath != "")
            {
                isOpenFile = true;
            }
            else
            {
                isOpenFile = false;
            }

            return isOpenFile;
        }
    }

    #endregion

    #region Чтение из файла с текстом
    /// <summary>
    /// Чтение текста из файла в строку
    /// </summary>
    public static void readInputTextFile()
    {

        OpenFileDialog openFileDialog = new OpenFileDialog();


        openFileDialog.InitialDirectory = @"D:\Langs\C#\WordsCalculator\WordCalculator";
        openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        openFileDialog.FilterIndex = 0;
        openFileDialog.RestoreDirectory = true;

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
                inputTextFilePath = openFileDialog.FileName;
                StreamReader streamReader = new StreamReader(File.OpenRead(inputTextFilePath));
                using (streamReader)
                {
                    fileString = streamReader.ReadToEnd();
                    Console.WriteLine(fileString);
                }
        }
    }
    #endregion

    #region Чтение из вспомогательного файла
    public static void readInputEndsFile()
    {
        try
        {
            using (StreamReader streamReader = new StreamReader(inputSupportFilePath, Encoding.GetEncoding(1251)))
            {
                // Инициализация списка окончаний прилагательных
                String tmpString = streamReader.ReadLine();
                arrayOfAdjectiveEnds = tmpString.Split(supportSeparator);

                // Инициализация списка суффиксов прилагательных
                tmpString = streamReader.ReadLine();
                arrayOfAdjectiveSuffixes = tmpString.Split(supportSeparator);
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
        String[] sentenceArray = fileString.Split(sentenceSeparatorsArray);

        foreach (String sentence in sentenceArray)
        {
            if (sentence != "")
            {
                listOfSentences.Add(sentence);
            }
        }
    }
    #endregion

    #region Нумерация предложений и запись пронумерованных предложений в файл
    public static void writeFileWithSentenceNumber()
    {
        using (StreamWriter outputFile = new StreamWriter(sentencesWithNumberFilePath))
        {
            for (int sentenceNumber = 0; sentenceNumber < listOfSentences.Count; sentenceNumber++)
            {
                outputFile.WriteLine(sentenceNumber + 1 + ". " + listOfSentences[sentenceNumber]);
            }
        }
    }
    #endregion

    #region Деление предложений на слова
    /// <summary>
    /// Деление текста на предложения по массиву знаков-разделителей
    /// Слова заносятся в список слов
    /// Номер предложения, из которого взято слова, 
    /// заносится по соответствующему  индексу в список номеров предложений
    /// Список количества слов заполняется единицами
    /// </summary>
    public static void divideIntoWords()
    {
        for (int sentenceNumber = 0; sentenceNumber < listOfSentences.Count; sentenceNumber++)
        {
            String[] wordArray = listOfSentences[sentenceNumber].Split(wordSeparatorsArray);

            foreach (String word in wordArray)
            {
                if (word != "")
                {
                    String lowerWord = word.ToLower();
                    listOfWords.Add(lowerWord);
                    listOfSentenceNumbers.Add((sentenceNumber + 1).ToString());
                    listOfWordAmount.Add(1);
                }
            }
        }
    }
    #endregion

    #region Поиск прилагательных с минимальной ошибкой второго рода
    /// <summary>
    /// Минимальной ошибкой второго рода будем называть ситуацию, 
    /// когда найдено максимально возможное количество прилагательных из текста.
    /// Это объясняется тем, что прилагательные имеют конечное количество окончаний, и, 
    /// осуществляя поиск по этим окончаниям, мы можем сказать, что нашли все прилагательные из текста.
    /// Для слова определенного как прилагательное в список частей речи 
    /// по соответствующему индексу заносится слово "Прилагательное"
    /// </summary>
    public static void findAdjectivesWithMinFirstKindError()
    {
        // Инициализация списка частей речи пустыми строками
        for (int elementNumber = 0; elementNumber < listOfWords.Count; elementNumber++)
            listOfSpeechParts.Add("");

        for (int elementNumber = 0; elementNumber < listOfWords.Count; elementNumber++)
        {
            String currentWord = listOfWords.ElementAt(elementNumber);

            bool isAdjective = false;

            // Проверка на то является ли currentWord прилагательным
            for (int endNumber = 0; endNumber < arrayOfAdjectiveEnds.Length; endNumber++)
            {
                int wordLengthWithoutEnd = currentWord.Length - arrayOfAdjectiveEnds[endNumber].Length;
                if (wordLengthWithoutEnd > 0)
                    if (currentWord.Substring(wordLengthWithoutEnd) == arrayOfAdjectiveEnds[endNumber])
                    {
                        isAdjective = true;
                        break;
                    }
            }

            // Если currentWord - прилагательное, то добавляем его в список прилагательных
            if (isAdjective)
            {
                listOfSpeechParts[elementNumber] = "Прилагательное";
            }
        }
    }
    #endregion

    #region Поиск прилагательных с минимальной ошибкой первого рода
    /// <summary> 
    /// Минимальной ошибкой первого рода будем называть ситуацию, 
    /// когда найдено минимальное количество слов, не являющихся прилагательными.
    /// Поиск прилагательных осуществляется сначала сравнением окончаний прилагательных 
    /// с элементами массива окончаний прилагательных, 
    /// после сравнением суффиксов с элементами массива суффиксов прилагательных
    /// Для слова определенного как прилагательное в список частей речи 
    /// по соответствующему индексу заносится слово "Прилагательное"
    /// </summary>
    public static void findAdjectivesWithMinSecondKindError()
    {
        for (int elementNumber = 0; elementNumber < listOfWords.Count; elementNumber++)
        {
            if (listOfSpeechParts[elementNumber] == "Прилагательное")
            {
                String currentWord = listOfWords.ElementAt(elementNumber);

                bool isAdjective = false;

                // Проверка на то является ли currentWord прилагательным
                for (int endNumber = 0; endNumber < arrayOfAdjectiveEnds.Length; endNumber++)
                {
                    for (int suffixNumber = 0; suffixNumber < arrayOfAdjectiveEnds.Length; suffixNumber++)
                    {
                        int wordLengthWitoutEndAndSuffix =
                            currentWord.Length - arrayOfAdjectiveEnds[endNumber].Length
                                               - arrayOfAdjectiveSuffixes[suffixNumber].Length;

                        if (wordLengthWitoutEndAndSuffix > 0)
                            if (currentWord.Substring(wordLengthWitoutEndAndSuffix,
                                arrayOfAdjectiveSuffixes[suffixNumber].Length)
                                == arrayOfAdjectiveSuffixes[suffixNumber])
                            {
                                isAdjective = true;
                                break;
                            }
                    }
                    if (isAdjective) break;
                }

                // Если currentWord - прилагательное, то добавляем его в список прилагательных
                if (isAdjective)
                {
                    listOfAdjectivesWithFirstTypeError.Add(currentWord);
                }
            }
        }
    }
    #endregion

    #region Подсчёт количества слов
    /// <summary>
    /// Сравниваются два слова первое с индексом currentNumber, второе - anotherNumber
    /// Если они посимвольно равны, то элемент с индексом anotherNumber удаляется из 
    /// списков слов, частей речи, количества слов, номеров предложений
    /// В массиве количества слов элемент по индексу currentNumber увеличивается на 1
    /// А к элементу массива номеров предложений по индексу currentNumber 
    /// добавляется строка из этого же массива, которая была по индексу anotherNumber
    /// Пример для массива номеров предложений: было "1", стало "1,2"
    /// в случае если одинаковые слова находились в первом и втором передложениях
    /// </summary>
    public static void countWordAmount()
    {
        for (int currentNumber = 0; currentNumber < listOfWords.Count; currentNumber++)
        {
            for (int anotherNumber = currentNumber + 1; anotherNumber < listOfWords.Count; anotherNumber++)
            {
                if (listOfWords.ElementAt(currentNumber) == listOfWords.ElementAt(anotherNumber))
                {
                    listOfWords.RemoveAt(anotherNumber);
                    listOfSpeechParts.RemoveAt(anotherNumber);
                    listOfWordAmount.RemoveAt(anotherNumber);
                    listOfWordAmount[currentNumber]++;
                    listOfSentenceNumbers[currentNumber] =
                        listOfSentenceNumbers[currentNumber] + "," +
                        listOfSentenceNumbers[anotherNumber];
                    listOfSentenceNumbers.RemoveAt(anotherNumber);
                    anotherNumber--;
                }
            }
        }
    }
    #endregion

    #region Корректировка номеров предложений для каждого слова
    /// <summary>
    /// Корректировка номеров предложений
    /// Пример: было "1,1,1,2,2,3", стало "1,2,3"
    /// </summary>
    public static void correctWordAmount()
    {
        // Берём слово из списка слов
        for (int wordNumber = 0; wordNumber < listOfSentenceNumbers.Count; wordNumber++)
        {
            // Делим номера предложений для этого слова по запятым в массив
            // Пример: было "1,2,3", стало "1","2","3"
            String[] arrayOfSentenceNumbersForWord = listOfSentenceNumbers[wordNumber].Split(sentenceNumberSeparator);

            // Копируем массив в список
            List<String> listOfSentenceNumbersForWord = new List <String>();
            for (int elementNumber = 0; elementNumber < arrayOfSentenceNumbersForWord.Length; elementNumber++)
            {
                listOfSentenceNumbersForWord.Add(arrayOfSentenceNumbersForWord[elementNumber]);
            }

            // Удаляем одинаковые номера предложений
            for (int currentNumber = 0; currentNumber < listOfSentenceNumbersForWord.Count; currentNumber++)
            {
                for (int anotherNumber = currentNumber + 1; anotherNumber < listOfSentenceNumbersForWord.Count; anotherNumber++)
                {
                    if (listOfSentenceNumbersForWord[currentNumber] == listOfSentenceNumbersForWord[anotherNumber])
                    {
                        listOfSentenceNumbersForWord.RemoveAt(anotherNumber);
                        anotherNumber--;
                    }
                }
            }

            // Заменяем текущее значение элемента списка номеров предложений на скорректированное
            listOfSentenceNumbers[wordNumber] = listOfSentenceNumbersForWord[0];
            for (int elementNumber = 1; elementNumber < listOfSentenceNumbersForWord.Count; elementNumber++)
            {
                listOfSentenceNumbers[wordNumber] +=
                    "," + listOfSentenceNumbersForWord[elementNumber];
            }
        }
    }
    #endregion

    #region Сортировка
    /// <summary>
    /// Сортировка пузырьком по возрастанию
    /// Сортируется список количества слов, 
    /// в соответствии с ним соортируются и остальные основные списки
    /// </summary>
    public static void sortOfWords()
    {
        for (int currentIndex = 0; currentIndex < listOfWordAmount.Count; currentIndex++)
        {
            for (int anotherIndex = 0; anotherIndex < listOfWordAmount.Count - currentIndex - 1; anotherIndex++)
            {
                if (listOfWordAmount[anotherIndex] > listOfWordAmount[anotherIndex + 1])
                {
                    int tmp = listOfWordAmount[anotherIndex];
                    listOfWordAmount[anotherIndex] = listOfWordAmount[anotherIndex + 1];
                    listOfWordAmount[anotherIndex + 1] = tmp;

                    String tmpString = listOfWords[anotherIndex];
                    listOfWords[anotherIndex] = listOfWords[anotherIndex + 1];
                    listOfWords[anotherIndex + 1] = tmpString;

                    tmpString = listOfSentenceNumbers[anotherIndex];
                    listOfSentenceNumbers[anotherIndex] = listOfSentenceNumbers[anotherIndex + 1];
                    listOfSentenceNumbers[anotherIndex + 1] = tmpString;

                    tmpString = listOfSpeechParts[anotherIndex];
                    listOfSpeechParts[anotherIndex] = listOfSpeechParts[anotherIndex + 1];
                    listOfSpeechParts[anotherIndex + 1] = tmpString;
                }
            }
        }
    }
    #endregion

    #region Форматированная запись данных в файлы
    /// <summary>
    /// Запись осуществляется с помощью прохода по массиву частей речи,
    /// в нём находятся элементы "Прилагательное"
    /// и по их индексу выводятся элементы из массива слов
    /// </summary>
    public static void writeInFiles()
    {
        // Запись в файл с минимальной ошибкой второго рода
        using (StreamWriter outputFile = new StreamWriter(secondKindErrorFilePath))
        {
            outputFile.WriteLine("{0,-30} {1,5:N0}        {2,5:N0}", "Слово", "Количество", "Номера предложений");
            outputFile.WriteLine("      ПРИЛАГАТЕЛЬНЫЕ");
            for (int elementNumber = 0; elementNumber < listOfSpeechParts.Count; elementNumber++)
            {
                if (listOfSpeechParts[elementNumber] == "Прилагательное")
                {
                    outputFile.WriteLine("{0,-30} {1,5:N0}             {2,-1:N0}",
                        listOfWords[elementNumber],
                        listOfWordAmount[elementNumber],
                        listOfSentenceNumbers[elementNumber]);
                }
            }
        }

        // Запись в файл с минимальной ошибкой первого рода
        using (StreamWriter outputFile = new StreamWriter(firstKindErrorFilePath))
        {
            outputFile.WriteLine("{0,-30} {1,5:N0}        {2,5:N0}", "Слово", "Количество", "Номера предложений");
            outputFile.WriteLine("      ПРИЛАГАТЕЛЬНЫЕ");
            for (int listOfWordsFromFileElement = 0; listOfWordsFromFileElement < listOfWords.Count; listOfWordsFromFileElement++)
            {
                for (int listOfAdjectivesWithFirstTypeErrorElement = 0; listOfAdjectivesWithFirstTypeErrorElement < listOfAdjectivesWithFirstTypeError.Count; listOfAdjectivesWithFirstTypeErrorElement++)
                {
                    if (listOfAdjectivesWithFirstTypeError[listOfAdjectivesWithFirstTypeErrorElement]
                        == listOfWords[listOfWordsFromFileElement])
                    {
                        outputFile.WriteLine("{0,-30} {1,5:N0}             {2,-10:N0}",
                            listOfWords[listOfWordsFromFileElement],
                            listOfWordAmount[listOfWordsFromFileElement],
                            listOfSentenceNumbers[listOfWordsFromFileElement]);
                        break;
                    }
                }
            }
        }
    }
    #endregion

    #region Обнуление исходных данных
    public static void clearData()
    {
        listOfWordAmount.RemoveRange(0, listOfWordAmount.Count);
        listOfSpeechParts.RemoveRange(0, listOfSpeechParts.Count);
        listOfWords.RemoveRange(0, listOfWords.Count);
        listOfSentenceNumbers.RemoveRange(0, listOfSentenceNumbers.Count);
        listOfSentences.RemoveRange(0, listOfSentences.Count);
        listOfAdjectivesWithFirstTypeError.RemoveRange(0, listOfAdjectivesWithFirstTypeError.Count);
    }
    #endregion
}