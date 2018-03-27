using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace Words_Calculator
{
    /// <summary>
    /// Осуществляет работу с частями речи.
    /// </summary>
    public class WordCalculator
    {

        #region Данные

        // Текст файла.
        private static String fileString;
        public static string FileString { get => fileString; set => fileString = value; }

        // Счетчик одной части речи.
        private static int count = 0;
        public static int Count { get => count; set => count = value; }

        ///РАЗДЕЛИТЕЛИ
        // Разделитель в вспомогательном файле.
        private const char supportSeparator = ' ';
        // Разделитель для номеров предложений.
        private const char sentenceNumberSeparator = ',';
        // Массив знаков-разделителей для предложений.
        private static readonly char[] sentenceSeparatorsArray = { '!', '?', '.' };
        // Массив знаков-разделителей на слова.
        private static char[] wordSeparatorsArray = { ' ',  ';',  ',',  ':',
                                                  '(',  ')',  '\\', '\"',
                                                  '\'', '\n', '\t', '\v', '\r' };

        ///ОСНОВНЫЕ СПИСКИ

        struct Word
        {
            // Слово.
            public String word;
            // Часть речи.
            public String partOfSpeech;
            // Номера предложений, в которых встречалось слово.
            public String sentenceNumber;
            // Сколько раз слово встречается в тексте.
            public int wordAmount;

            public Word(String _word, String _partOfSpeech, String _sentenceNumber, int _wordAmount)
            {
                word = _word;
                partOfSpeech = _partOfSpeech;
                sentenceNumber = _sentenceNumber;
                wordAmount = _wordAmount;
            }

        };

        // Список слов.
        private static List<Word> wordList = new List<Word>();

        ///ВСПОМОГАТЕЛЬНЫЕ СПИСКИ
        // Список найденных прилагательных с ошибкой первого рода.
        private static List<String> listOfAdjectivesWithFirstTypeError = new List<String>();
        // Список предложений из текста.
        private static List<String> listOfSentences = new List<String>();

        ///ВСПОМОГАТЕЛЬНЫЕ МАССИВЫ
        // Массив окончаний ПРИЛАГАТЕЛЬНЫХ.
        private static String[] arrayOfAdjectiveEnds;
        // Массив суффиксов ПРИЛАГАТЕЛЬНЫХ.
        private static String[] arrayOfAdjectiveSuffixes;
        // Массив суффиксов ГЛАГОЛОВ.
        private static String[] arrayOfVerbSuffixes;
        // Массив окончаний ГЛАГОЛОВ.
        private static String[] arrayOfVerbEnds;
        // Массив окончаний НАРЕЧИЙ.
        private static String[] arrayOfAdverbEnds;
        // Массив начал НАРЕЧИЙ.
        private static String[] arrayOfAdverbStarts;
        // Массив словарных НАРЕЧИЙ.
        private static String[] arrayOfDictionaryAdverbs;
        //Массив суффиксов ПРИЧАСТИЙ.
        private static String[] arrayOfParticipleSuffixes;
        //Массив окончаний ПРИЧАСТИЙ.
        private static String[] arrayOfParticipleEndings;
        //Массив постфиксов ПРИЧАСТИЙ.
        private static String[] arrayOfParticiplePostfixes;
        //Массив суффиксов ДЕЕПРИЧАСТИЙ.
        private static String[] arrayOfDeeprSuffixes;
        // Массив начал ЧИСЛИТЕЛЬНЫХ.
        private static String[] arrayOfNumeralStarts;
        // Массив окончаний ЧИСЛИТЕЛЬНЫХ.
        private static String[] arrayOfNumeralEnds;
        // Массив словарных ЧИСЛИТЕЛЬНЫХ.
        private static String[] arrayOfDictionaryNumerals;
        // Массив словарных МЕСТОИМЕНИЙ.
        private static String[] arrayOfDictionaryPronouns;
        // Массив словарных СОЮЗОВ.
        private static String[] arrayOfDictionaryUnions;
        // Массив словарных ПРЕДЛОГОВ.
        private static String[] arrayOfDictionaryPrepositions;
        // Массив словарных ЧАСТИЦ.
        private static String[] arrayOfDictionaryParticles;
        // Массив словарных МЕЖДОМЕТИЙ.
        private static String[] arrayOfDictionaryInterjections;

        #endregion

        #region Чтение из файла с текстом
        /// <summary>
        /// Чтение текста из файла в строку
        /// </summary>
        public static void readInputTextFile(ref TextBox tbInputText)
        {
            StreamReader streamReader = new StreamReader(File.OpenRead(FileHandler.InputTextFilePath), Encoding.GetEncoding(1251));
            using (streamReader)
            {
                tbInputText.Text = streamReader.ReadToEnd();
            }
        }
        #endregion

        #region Чтение из вспомогательного файла
        public static void readSupportFile()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(FileHandler.InputSupportFilePath, Encoding.GetEncoding(1251)))
                {
                    String tmpString = streamReader.ReadLine();

                    // Инициализация списка окончаний ПРИЛАГАТЕЛЬНЫХ
                    tmpString = streamReader.ReadLine();
                    arrayOfAdjectiveEnds = tmpString.Split(supportSeparator);

                    // Инициализация списка суффиксов ПРИЛАГАТЕЛЬНЫХ
                    tmpString = streamReader.ReadLine();
                    arrayOfAdjectiveSuffixes = tmpString.Split(supportSeparator);


                    tmpString = streamReader.ReadLine();

                    // Инициализация списка суффиксов ГЛАГОЛОВ 
                    tmpString = streamReader.ReadLine();
                    arrayOfVerbSuffixes = tmpString.Split(supportSeparator);

                    // Инициализация списка окончаний ГЛАГОЛОВ 
                    tmpString = streamReader.ReadLine();
                    arrayOfVerbEnds = tmpString.Split(supportSeparator);


                    tmpString = streamReader.ReadLine();

                    // Инициализация списка окончаний НАРЕЧИЙ
                    tmpString = streamReader.ReadLine();
                    arrayOfAdverbEnds = tmpString.Split(supportSeparator);

                    // Инициализация списка начал НАРЕЧИЙ
                    tmpString = streamReader.ReadLine();
                    arrayOfAdverbStarts = tmpString.Split(supportSeparator);

                    // Инициализация списка словарных НАРЕЧИЙ
                    tmpString = streamReader.ReadLine();
                    arrayOfDictionaryAdverbs = tmpString.Split(supportSeparator);


                    tmpString = streamReader.ReadLine();

                    // Инициализация списка суффиксов ПРИЧАСТИЙ
                    tmpString = streamReader.ReadLine();
                    arrayOfParticipleSuffixes = tmpString.Split(supportSeparator);

                    // Инициализация списка окончаний ПРИЧАСТИЙ
                    tmpString = streamReader.ReadLine();
                    arrayOfParticipleEndings = tmpString.Split(supportSeparator);

                    // Инициализация списка постфиксов ПРИЧАСТИЙ
                    tmpString = streamReader.ReadLine();
                    arrayOfParticiplePostfixes = tmpString.Split(supportSeparator);


                    tmpString = streamReader.ReadLine();

                    // Инициализация списка суффиксов ДЕЕПРИЧАСТИЙ 
                    tmpString = streamReader.ReadLine();
                    arrayOfDeeprSuffixes = tmpString.Split(supportSeparator);

                    // Инициализация списка начал ЧИСЛИТЕЛЬНЫХ
                    tmpString = streamReader.ReadLine();
                    arrayOfNumeralStarts = tmpString.Split(supportSeparator);

                    // Инициализация списка окончаний ЧИСЛИТЕЛЬНЫХ
                    tmpString = streamReader.ReadLine();
                    arrayOfNumeralEnds = tmpString.Split(supportSeparator);

                    // Инициализация списка словарных ЧИСЛИТЕЛЬНЫХ
                    tmpString = streamReader.ReadLine();
                    arrayOfDictionaryNumerals = tmpString.Split(supportSeparator);
                    tmpString = streamReader.ReadLine();

                    // Инициализация списка словарных МЕСТОИМЕНИЙ
                    tmpString = streamReader.ReadLine();
                    arrayOfDictionaryPronouns = tmpString.Split(supportSeparator);
                    tmpString = streamReader.ReadLine();

                    // Инициализация списка словарных СОЮЗОВ
                    tmpString = streamReader.ReadLine();
                    arrayOfDictionaryUnions = tmpString.Split(supportSeparator);
                    tmpString = streamReader.ReadLine();

                    // Инициализация списка словарных ПРЕДЛОГОВ
                    tmpString = streamReader.ReadLine();
                    arrayOfDictionaryPrepositions = tmpString.Split(supportSeparator);
                    tmpString = streamReader.ReadLine();

                    // Инициализация списка словарных ЧАСТИЦ
                    tmpString = streamReader.ReadLine();
                    arrayOfDictionaryParticles = tmpString.Split(supportSeparator);
                    tmpString = streamReader.ReadLine();

                    // Инициализация списка словарных МЕЖДОМЕТИЙ
                    tmpString = streamReader.ReadLine();
                    arrayOfDictionaryInterjections = tmpString.Split(supportSeparator);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удалось прочитать файл:");
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region Деление строки на предложения
        public static void divideIntoSentences()
        {
            String[] sentenceArray = FileString.Split(sentenceSeparatorsArray);

            foreach (var sentence in sentenceArray)
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
            using (StreamWriter outputFile = new StreamWriter(FileHandler.SentencesWithNumberFilePath))
            {
                for (var sentenceNumber = 0; sentenceNumber < listOfSentences.Count; sentenceNumber++)
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

                foreach (var word in wordArray)
                {
                    if (word != "")
                    {
                        String lowerWord = word.ToLower();
                        Word tempWord = new Word(lowerWord, "", (sentenceNumber + 1).ToString(), 1);
                        wordList.Add(tempWord);
                    }
                }
            }
        }
        #endregion

        #region Поиск ПРИЛАГАТЕЛЬНЫХ
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
            for (var elementNumber = 0; elementNumber < wordList.Count; elementNumber++)
            {
                String currentWord = wordList.ElementAt(elementNumber).word;

                bool isAdjective = false;

                if (wordList[elementNumber].partOfSpeech == "")
                {
                    // Проверка на то является ли currentWord прилагательным
                    for (var endNumber = 0; endNumber < arrayOfAdjectiveEnds.Length; endNumber++)
                    {
                        int wordLengthWithoutEnd = currentWord.Length - arrayOfAdjectiveEnds[endNumber].Length;
                        if (wordLengthWithoutEnd > 0)
                        {
                            if (currentWord.Substring(wordLengthWithoutEnd) == arrayOfAdjectiveEnds[endNumber])
                            {
                                isAdjective = true;
                                break;
                            }
                        }
                    }

                    // Если currentWord - прилагательное, то добавляем его в список прилагательных
                    if (isAdjective)
                    {
                        //wordList[elementNumber].partOfSpeech = "Прилагательное";
                        Word tempWord = wordList[elementNumber];
                        tempWord = new Word(tempWord.word, "Прилагательное", tempWord.sentenceNumber, tempWord.wordAmount);
                        wordList[elementNumber] = tempWord;
                    }
                }
            }
        }
        #endregion

        /*#region Поиск прилагательных с минимальной ошибкой первого рода
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
            for (var elementNumber = 0; elementNumber < wordList.Count; elementNumber++)
            {
                if (wordList[elementNumber].partOfSpeech == "Прилагательное")
                {
                    String currentWord = wordList.ElementAt(elementNumber).word;

                    bool isAdjective = false;

                    // Проверка на то является ли currentWord прилагательным
                    for (var endNumber = 0; endNumber < arrayOfAdjectiveEnds.Length; endNumber++)
                    {
                        for (var suffixNumber = 0; suffixNumber < arrayOfAdjectiveEnds.Length; suffixNumber++)
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
        #endregion*/

        #region Поиск НАРЕЧИЙ
        public static void findAdverb()
        {
            for (var i = 0; i <arrayOfAdverbEnds.Length; i++)
            {
                Console.WriteLine(arrayOfAdverbEnds[i]);
            }

            for (var elementNumber = 0; elementNumber < wordList.Count; elementNumber++)
            {
                String currentWord = wordList.ElementAt(elementNumber).word;

                bool isAdverb = false;

                if (wordList[elementNumber].partOfSpeech == "")
                {
                    // Проверка на то является ли currentWord прилагательным
                    for (var endNumber = 0; endNumber < arrayOfAdverbEnds.Length; endNumber++)
                    {
                        int wordLengthWithoutEnd = currentWord.Length - arrayOfAdjectiveEnds[endNumber].Length;
                        if (wordLengthWithoutEnd > 0)
                        {
                            if (currentWord.Substring(wordLengthWithoutEnd) == arrayOfAdverbEnds[endNumber])
                            {
                                isAdverb = true;
                                break;
                            }
                        }
                    }

                    for (var startNumber = 0; startNumber < arrayOfAdverbStarts.Length; startNumber++)
                    {
                        int wordLengthWithoutStart = currentWord.Length - arrayOfAdverbStarts[startNumber].Length;
                        if (wordLengthWithoutStart > 0)
                        {
                            if (currentWord.Substring(0, wordLengthWithoutStart) == arrayOfAdverbStarts[startNumber])
                            {
                                isAdverb = true;
                                break;
                            }
                        }
                    }

                    for (var dictionaryWordNumber = 0; dictionaryWordNumber < arrayOfDictionaryAdverbs.Length; dictionaryWordNumber++)
                    {
                        if (currentWord == arrayOfDictionaryAdverbs[dictionaryWordNumber])
                        {
                            isAdverb = true;
                            break;
                        }
                    }

                    // Если currentWord - прилагательное, то добавляем его в список наречием
                    if (isAdverb)
                    {
                        Word tempWord = wordList[elementNumber];
                        tempWord = new Word(tempWord.word, "Наречие", tempWord.sentenceNumber, tempWord.wordAmount);
                        wordList[elementNumber] = tempWord;
                    }
                }
            }
        }
        #endregion

        #region Поиск ГЛАГОЛОВ 
        public static void findVerb()
        {
            for (var elementNumber = 0; elementNumber < wordList.Count; elementNumber++)
            {
                String currentWord = wordList.ElementAt(elementNumber).word;

                bool isVerb = false;

                if (wordList[elementNumber].partOfSpeech == "")
                {
                    // Проверка на то, является ли currentWord глаголом 
                    for (var endNumber = 0; endNumber < arrayOfVerbEnds.Length; endNumber++)
                    {
                        for (var suffixNumber = 0; suffixNumber < arrayOfVerbSuffixes.Length; suffixNumber++)
                        {
                            int wordLengthWithoutEndAndSuffix =
                            currentWord.Length - arrayOfVerbEnds[endNumber].Length
                            - arrayOfVerbSuffixes[suffixNumber].Length;

                            if (wordLengthWithoutEndAndSuffix > 0)
                                if (currentWord.Substring(wordLengthWithoutEndAndSuffix,
                                arrayOfVerbSuffixes[suffixNumber].Length)
                                == arrayOfVerbSuffixes[suffixNumber])
                                {
                                    isVerb = true;
                                    break;
                                }
                        }
                        if (isVerb) break;
                    }

                    for (var endNumber = 0; endNumber < arrayOfVerbEnds.Length; endNumber++)
                    {
                        int wordLengthWithoutEnd = currentWord.Length - arrayOfVerbEnds[endNumber].Length;
                        if (wordLengthWithoutEnd > 0)
                        {
                            if (currentWord.Substring(wordLengthWithoutEnd) == arrayOfVerbEnds[endNumber])
                            {
                                isVerb = true;
                                break;
                            }
                        }
                    }

                    // Если currentWord - глагол, то добавляем его в список глаголов 
                    if (isVerb)
                    {
                        Word tempWord = wordList[elementNumber];
                        tempWord = new Word(tempWord.word, "Глагол", tempWord.sentenceNumber, tempWord.wordAmount);
                        wordList[elementNumber] = tempWord;
                    }
                }
            }
        }
        #endregion

        #region Поиск ПРИЧАСТИЙ
        public static void findParticiple()
        {
            for (var elementNumber = 0; elementNumber < wordList.Count; elementNumber++)
            {
                if (wordList[elementNumber].partOfSpeech == "")
                {
                    String currentWord = wordList.ElementAt(elementNumber).word;
                    String subword = currentWord;
                    String mainWord = "";
                    bool isParticiple = false;

                    //Цикл по постфиксам
                    foreach (string postfix in arrayOfParticiplePostfixes)
                    {
                        if (currentWord.EndsWith(postfix))
                        {
                            subword = currentWord.Substring(0, (currentWord.Length - postfix.Length));
                        }
                    }

                    //Цикл по окончаниям из двух букв
                    foreach (string ending in arrayOfParticipleEndings)
                    {
                        if (currentWord.Length - ending.Length > 0)
                        {
                            mainWord = subword.Substring(0, currentWord.Length - ending.Length); //Убираем окончания

                            if (subword.EndsWith(ending))
                            {
                                //Цикл по суффикам
                                foreach (string suffix in arrayOfParticipleSuffixes)
                                {
                                    if (mainWord.EndsWith(suffix))
                                    {
                                        isParticiple = true;
                                    }
                                }
                            }
                        }
                    }

                    // Если currentWord - прилагательное, то добавляем его в список причастий
                    if (isParticiple)
                    {
                        Word tempWord = wordList[elementNumber];
                        tempWord = new Word(tempWord.word, "Причастие", tempWord.sentenceNumber, tempWord.wordAmount);
                        wordList[elementNumber] = tempWord;
                    }
                }
            }
        }
        #endregion

        #region Поиск ДЕЕПРИЧАСТИЙ
        public static void findDeeprichastie()

        {
            for (var elementNumber = 0; elementNumber < wordList.Count; elementNumber++)
            {
                String currentWord = wordList.ElementAt(elementNumber).word;

                bool isDeepr = false;

                if (wordList[elementNumber].partOfSpeech == "")
                {
                    // Проверка на то является ли currentWord деепричастием
                    for (var suffixNumber = 0; suffixNumber < arrayOfDeeprSuffixes.Length; suffixNumber++)
                    {
                        if (currentWord.Length > arrayOfDeeprSuffixes[suffixNumber].Length)
                        {
                            if ((currentWord.EndsWith(arrayOfDeeprSuffixes[suffixNumber]) || currentWord.EndsWith(arrayOfDeeprSuffixes[suffixNumber] + "сь")))
                            {
                                isDeepr = true;
                                break;
                            }
                        }
                    }

                    // Если currentWord - деепричастие, то добавляем его в список прилагательных
                    if (isDeepr)
                    {
                        Word tempWord = wordList[elementNumber];
                        tempWord = new Word(tempWord.word, "Деепричастие", tempWord.sentenceNumber, tempWord.wordAmount);
                        wordList[elementNumber] = tempWord;
                    }
                }
            }

        }
        #endregion

        #region Поиск ЧИСЛИТЕЛЬНЫХ, МЕСТОИМЕНИЙ, СОЮЗОВ, ПРЕДЛОГОВ, ЧАСТИЦ и МЕЖДОМЕТИЙ по словарю
        public static void findDictionary()
        {
            for (var elementNumber = 0; elementNumber < wordList.Count; elementNumber++)
            {
                String currentWord = wordList.ElementAt(elementNumber).word;

                bool isDictionary = false;

                // Проверка на то, является ли currentWord ЧИСЛИТЕЛЬНЫМ
                for (var startNumber = 0; startNumber < arrayOfNumeralStarts.Length; startNumber++)
                {
                    int wordLengthWithoutStart = currentWord.Length - arrayOfNumeralStarts[startNumber].Length;
                    if (wordLengthWithoutStart > 0)
                    {
                        if (currentWord.Substring(0, wordLengthWithoutStart) == arrayOfNumeralStarts[startNumber])
                        {
                            isDictionary = true;
                            break;
                        }
                    }
                }

                for (var endNumber = 0; endNumber < arrayOfNumeralEnds.Length; endNumber++)
                {
                    int wordLengthWithoutEnd = currentWord.Length - arrayOfNumeralEnds[endNumber].Length;
                    if (wordLengthWithoutEnd > 0)
                    {
                        if (currentWord.Substring(wordLengthWithoutEnd) == arrayOfNumeralEnds[endNumber])
                        {
                            isDictionary = true;
                            break;
                        }
                    }
                }

                for (var dictionaryWordNumber = 0; dictionaryWordNumber < arrayOfDictionaryNumerals.Length; dictionaryWordNumber++)
                {
                    if (currentWord == arrayOfDictionaryNumerals[dictionaryWordNumber])
                    {
                        isDictionary = true;
                        break;
                    }
                }

                // Проверка на то, является ли currentWord словом из словаря МЕСТОИМЕНИЙ
                for (var dictionaryWordNumber = 0; dictionaryWordNumber < arrayOfDictionaryPronouns.Length; dictionaryWordNumber++)
                {
                    if (currentWord == arrayOfDictionaryPronouns[dictionaryWordNumber])
                    {
                        isDictionary = true;
                        break;
                    }
                }

                // Проверка на то, является ли currentWord словом из словаря СОЮЗОВ
                for (var dictionaryWordNumber = 0; dictionaryWordNumber < arrayOfDictionaryUnions.Length; dictionaryWordNumber++)
                {
                    if (currentWord == arrayOfDictionaryUnions[dictionaryWordNumber])
                    {
                        isDictionary = true;
                        break;
                    }
                }

                // Проверка на то, является ли currentWord словом из словаря ПРЕДЛОГОВ
                for (var dictionaryWordNumber = 0; dictionaryWordNumber < arrayOfDictionaryPrepositions.Length; dictionaryWordNumber++)
                {
                    if (currentWord == arrayOfDictionaryPrepositions[dictionaryWordNumber])
                    {
                        isDictionary = true;
                        break;
                    }
                }

                // Проверка на то, является ли currentWord словом из словаря ЧАСТИЦ
                for (var dictionaryWordNumber = 0; dictionaryWordNumber < arrayOfDictionaryParticles.Length; dictionaryWordNumber++)
                {
                    if (currentWord == arrayOfDictionaryParticles[dictionaryWordNumber])
                    {
                        isDictionary = true;
                        break;
                    }
                }

                // Проверка на то, является ли currentWord словом из словаря МЕЖДОМЕТИЙ
                for (var dictionaryWordNumber = 0; dictionaryWordNumber < arrayOfDictionaryInterjections.Length; dictionaryWordNumber++)
                {
                    if (currentWord == arrayOfDictionaryInterjections[dictionaryWordNumber])
                    {
                        isDictionary = true;
                        break;
                    }
                }

                // Если currentWord - слово из словаря, то добавляем его в список слов из словаря
                if (isDictionary)
                {
                    Word tempWord = wordList[elementNumber];
                    tempWord = new Word(tempWord.word, "Слова из словаря", tempWord.sentenceNumber, tempWord.wordAmount);
                    wordList[elementNumber] = tempWord;
                }
            }
        }
        #endregion

        #region Поиск СУЩЕСТВИТЕЛЬНЫХ
        public static void findNoun()
        {
            for (var elementNumber = 0; elementNumber < wordList.Count; elementNumber++)
            {
                if (wordList[elementNumber].partOfSpeech == "")
                {
                    Word tempWord = wordList[elementNumber];
                    tempWord = new Word(tempWord.word, "Существительное", tempWord.sentenceNumber, tempWord.wordAmount);
                    wordList[elementNumber] = tempWord;
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
            for (var currentNumber = 0; currentNumber < wordList.Count; currentNumber++)
            {
                for (var anotherNumber = currentNumber + 1; anotherNumber < wordList.Count; anotherNumber++)
                {
                    if (wordList.ElementAt(currentNumber).word == wordList.ElementAt(anotherNumber).word)
                    {
                        Word tempWord = wordList[currentNumber];
                        tempWord.wordAmount++;
                        tempWord.sentenceNumber = wordList[currentNumber].sentenceNumber + "," + wordList[anotherNumber].sentenceNumber;
                        wordList[currentNumber] = tempWord;

                        wordList.RemoveAt(anotherNumber);
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
            for (var wordNumber = 0; wordNumber < wordList.Count; wordNumber++)
            {
                // Делим номера предложений для этого слова по запятым в массив
                // Пример: было "1,2,3", стало "1","2","3"
                String[] arrayOfSentenceNumbersForWord = wordList[wordNumber].sentenceNumber.Split(sentenceNumberSeparator);

                // Копируем массив в список
                List<String> listOfSentenceNumbersForWord = new List<String>();
                for (var elementNumber = 0; elementNumber < arrayOfSentenceNumbersForWord.Length; elementNumber++)
                {
                    listOfSentenceNumbersForWord.Add(arrayOfSentenceNumbersForWord[elementNumber]);
                }

                // Удаляем одинаковые номера предложений
                for (var currentNumber = 0; currentNumber < listOfSentenceNumbersForWord.Count; currentNumber++)
                {
                    for (var anotherNumber = currentNumber + 1; anotherNumber < listOfSentenceNumbersForWord.Count; anotherNumber++)
                    {
                        if (listOfSentenceNumbersForWord[currentNumber] == listOfSentenceNumbersForWord[anotherNumber])
                        {
                            listOfSentenceNumbersForWord.RemoveAt(anotherNumber);
                            anotherNumber--;
                        }
                    }
                }

                // Заменяем текущее значение элемента списка номеров предложений на скорректированное
                Word tempWord = wordList[wordNumber];
                tempWord.sentenceNumber = listOfSentenceNumbersForWord[0];
                for (var elementNumber = 1; elementNumber < listOfSentenceNumbersForWord.Count; elementNumber++)
                {
                    tempWord.sentenceNumber +=
                        "," + listOfSentenceNumbersForWord[elementNumber];
                }
                wordList[wordNumber] = tempWord;
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
            for (var currentIndex = 0; currentIndex < wordList.Count; currentIndex++)
            {
                for (var anotherIndex = 0; anotherIndex < wordList.Count - currentIndex - 1; anotherIndex++)
                {
                    if (wordList[anotherIndex].wordAmount > wordList[anotherIndex + 1].wordAmount)
                    {
                        Word tempWord = wordList[anotherIndex];
                        wordList[anotherIndex] = wordList[anotherIndex + 1];
                        wordList[anotherIndex + 1] = tempWord;
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
        public static void writeInFiles(String partOfSpeech)
        {
            StreamWriter outputFile;

            if (FileHandler.IsEmptyOutputFile)
            {
                // Запись в файл с минимальной ошибкой второго рода
                outputFile = new StreamWriter(FileHandler.OutputFilePath);
                FileHandler.IsEmptyOutputFile = false;
            }
            else
            {
                FileStream fileStream = new FileStream(FileHandler.OutputFilePath, FileMode.Append);
                // Запись в файл с минимальной ошибкой второго рода
                outputFile = new StreamWriter(fileStream);
            }

            outputFile.WriteLine("{0,-30} {1,5:N0}        {2,5:N0}", "Слово", "Количество", "Номера предложений");
            outputFile.WriteLine("      " + partOfSpeech);

            for (var elementNumber = 0; elementNumber < wordList.Count; elementNumber++)
            {
                if (wordList[elementNumber].partOfSpeech == partOfSpeech)
                {
                    outputFile.WriteLine("{0,-30} {1,5:N0}             {2,-1:N0}",
                        wordList[elementNumber].word,
                        wordList[elementNumber].wordAmount,
                        wordList[elementNumber].sentenceNumber);
                }
            }

            outputFile.Close();
        }
        #endregion

        #region Обнуление исходных данных
        public static void clearData()
        {
            wordList.RemoveRange(0, wordList.Count);
            listOfSentences.RemoveRange(0, listOfSentences.Count);
            listOfAdjectivesWithFirstTypeError.RemoveRange(0, listOfAdjectivesWithFirstTypeError.Count);
        }
        #endregion

        #region Инициализация таблицы
        /// <summary>
        /// Инициализация таблицы.
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="table"></param>
        public static void InitGrid(ref DataGridView dataGridView, ref DataTable table)
        {
            table.Columns.Add("Слово", typeof(string));
            table.Columns.Add("Количество", typeof(int));
            dataGridView.RowHeadersVisible = false;
            dataGridView.ColumnHeadersVisible = false;
        }
        #endregion

        #region Заполнение таблицы
        /// <summary>
        /// Заполнение таблицы.
        /// </summary>
        /// <param name="partOfSpeech"></param>
        /// <param name="dataGridView"></param>
        /// <param name="table"></param>
        public static void FillGrid(String partOfSpeech, ref DataGridView dataGridView, ref DataTable table)
        {
            table.Rows.Add(partOfSpeech, null);
            int tableSize = table.Rows.Count;
            foreach (Word s in wordList)
            {
                if (s.partOfSpeech == partOfSpeech)
                {
                    table.Rows.Add(s.word, s.wordAmount);
                }
            }
            dataGridView.DataSource = table;
        }
        #endregion

        #region Вывод предложений для выбранного в таблице слова на экран
        /// <summary>
        /// Вывод предложений для выбранного в таблице слова на экран.
        /// </summary>
        /// <param name="word"></param>
        /// <param name="partOfSpeech"></param>
        /// <param name="tbSentences"></param>
        public static void PutSentencesForWord(String word, ref TextBox tbSentences)
        {
            String outputString = "";
            for (var wordNumber = 0; wordNumber < wordList.Count; wordNumber++)
            {
                if (wordList[wordNumber].word == word)
                {
                    String[] stringSentencesNumber = wordList[wordNumber].sentenceNumber.Split(',');

                    for (var sentenceNumberIndex = 0; sentenceNumberIndex < stringSentencesNumber.Length; sentenceNumberIndex++)
                    {
                        int tmp = Convert.ToInt32(stringSentencesNumber[sentenceNumberIndex]);
                        outputString += listOfSentences[tmp - 1];
                        outputString += ".\r\n\r\n";
                        Console.WriteLine(outputString);
                    }
                }
            }
            tbSentences.Text = outputString;
        }
        #endregion

        public static void getStatistics(String _partOfSpeech)
        {
            count = 0;
            foreach (Word word in wordList)
            {
                if (word.partOfSpeech == _partOfSpeech)
                {
                    count++;
                }
            }
        }
    }
}