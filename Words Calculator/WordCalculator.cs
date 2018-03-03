using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

/// <summary>
/// Осуществляет работу с частями речи(прилагательными).
/// </summary>
public class WordCalculator
{

    #region Данные

    // Текст файла.
    private static String fileString;

    ///ПУТИ К ФАЙЛАМ
    // Путь к входному файлу с текстом.
    private static String inputTextFilePath = @"";
    // Путь к входному вспомогательному файлу.
    private const String inputSupportFilePath = @"D:\Langs\C#\WordCalculator\InputSupportFile.txt";
    // Путь к выходному файлу c ошибкой второго рода.
    private const String secondKindErrorFilePath = @"D:\Langs\C#\WordCalculator\SecondKindErrorOutputFile.txt";
    // Путь к выходному файлу с ошибкой первого рода.
    //private const String firstKindErrorFilePath = @"D:\Langs\C#\WordCalculator\FirstKindErrorOutputFile.txt";
    // Путь к выходному файлу с пронумерованными предложениями.
    private const String sentencesWithNumberFilePath = @"D:\Langs\C#\WordCalculator\SentencesWithNumberOutputFile.txt";
    // Начальная директория для открытия файла
    private const String startDirectory = @"D:\Langs\C#";
    // Фильтр, чтобы можно было открывать только текстовые файлы
    private const String filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";

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

    struct Word
    {
        // Слово
        public String word;
        // Часть речи
        public String partOfSpeech;
        // Номера предложений, в которых встречалось слово
        public String sentenceNumber;
        // Сколько раз слово встречается в тексте
        public int wordAmount;

        public Word(String _word, String _partOfSpeech, String _sentenceNumber, int _wordAmount)
        {
            word = _word;
            partOfSpeech = _partOfSpeech;
            sentenceNumber = _sentenceNumber;
            wordAmount = _wordAmount;
        }

    };
    
    // Список слов
    private static List<Word> wordList =  new List<Word>();

    ///ВСПОМОГАТЕЛЬНЫЕ СПИСКИ
    // Список найденных прилагательных с ошибкой первого рода
    private static List<String> listOfAdjectivesWithFirstTypeError = new List<String>();
    // Список предложений из текста
    private static List<String> listOfSentences = new List<String>();

    ///ВСПОМОГАТЕЛЬНЫЕ МАССИВЫ
    // Массив окончаний ПРИЛАГАТЕЛЬНЫХ
    private static String[] arrayOfAdjectiveEnds;
    // Массив суффиксов ПРИЛАГАТЕЛЬНЫХ
    private static String[] arrayOfAdjectiveSuffixes;
    // Массив окончаний НАРЕЧИЙ
    private static String[] arrayOfAdverbEnds;
    // Массив начал НАРЕЧИЙ
    private static String[] arrayOfAdverbStarts;
    // Массив словарных НАРЕЧИЙ
    private static String[] arrayOfDictionaryAdverbs;

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


        openFileDialog.InitialDirectory = startDirectory;
        openFileDialog.Filter = filter;
        openFileDialog.FilterIndex = 0;
        openFileDialog.RestoreDirectory = true;

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
                inputTextFilePath = openFileDialog.FileName;
                StreamReader streamReader = new StreamReader(File.OpenRead(inputTextFilePath), Encoding.GetEncoding(1251));
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
                String tmpString = streamReader.ReadLine();

                // Инициализация списка окончаний ПРИЛАГАТЕЛЬНЫХ
                tmpString = streamReader.ReadLine();
                arrayOfAdjectiveEnds = tmpString.Split(supportSeparator);

                // Инициализация списка суффиксов ПРИЛАГАТЕЛЬНЫХ
                tmpString = streamReader.ReadLine();
                arrayOfAdjectiveSuffixes = tmpString.Split(supportSeparator);



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
        using (StreamWriter outputFile = new StreamWriter(sentencesWithNumberFilePath))
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

    #region Поиск ПРИЛАГАТЕЛЬНЫХ с минимальной ошибкой второго рода
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
                Word tempWord = wordList[elementNumber];
                tempWord = new Word(tempWord.word, "Прилагательное", tempWord.sentenceNumber, tempWord.wordAmount);
                wordList[elementNumber] = tempWord;
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
        for (var elementNumber = 0; elementNumber < wordList.Count; elementNumber++)
        {
            String currentWord = wordList.ElementAt(elementNumber).word;

            bool isAdverb = false;

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
                    if (currentWord.Substring(0, wordLengthWithoutStart) == arrayOfAdverbEnds[startNumber])
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

            // Если currentWord - прилагательное, то добавляем его в список прилагательных
            if (isAdverb)
            {
                Word tempWord = wordList[elementNumber];
                tempWord = new Word(tempWord.word, "Наречие", tempWord.sentenceNumber, tempWord.wordAmount);
                wordList[elementNumber] = tempWord;
            }
        }
    }
    #endregion

    /* ОСТАВШИЕСЯ ЧАСТИ РЕЧИ
    #region Поиск СУЩЕСТВИТЕЛЬНЫХ
    public static void findNoun()
    {
        for (int i = 0; i < wordList.Count; i++) //ОГО ЕГО ОМУ ЕМУ
        {
            wordList.Add("");                       //базовое значение для каждого нового слова - нулевое
            bool checkfalseword = false;                   //опускаем флаг совпадения с ложным словом
            for (int l = 0; l < false_word.Length; l++)    //сравнение со всеми ложными словами
            {
                if (false_word[l] == Words[i])             //при совпадении с ложным словом 
                {
                    checkfalseword = true;                 //поднятие флага и выход из итерации цикла
                    break;
                }
            }
            if (checkfalseword) continue;                   //если данное слово не входит список ложных
            if (Words[i].Length > 2)                        //отбрасываются все слова меньше 3х символов
            {
                bool flag = false;   //опускаем флаг (флаг поднимется если данное слово сущ в Т.п или др часть речи:
                                     //совпадение с окончание др части речи или прил в П.п с предлогом)

                for (int j = 0; j < False_ending.Length; j++)       //сравнение окончания слова со всеми ложными окончаниями
                {
                    if (Words[i].Length > False_ending[j].Length)
                    {
                        if (Words[i].Substring(Words[i].Length - False_ending[j].Length) == False_ending[j])
                        //при совпадении окончаний
                        {
                            flag = true;     //поднятие флага (другая часть речи)
                            break;           // выход из итерации цикла
                        }
                    }
                }
                if (flag) continue;     //если данное слово не имеет ложного окончания
                                        //окончание другой чатси речи
                                        //проверка на прил в П.п(окончание ом ем и на наличие предлога перед проверяемым словом)

                for (int j = 0; j < Ending_tvorit_padeg.Length; j++)
                {//цикл по окончаниям прилагательных в П.п
                    if (Words[i].Length > Ending_tvorit_padeg[j].Length)
                    {
                        if (Words[i].Substring(Words[i].Length - Ending_tvorit_padeg[j].Length) == Ending_tvorit_padeg[j])
                        {// если данное слово оканчивается на ОМ или ЕМ
                            for (byte k = 0; k < Consonants.Length; k++)
                            {//и перед окончанием идет согласная
                                if (Words[i].Substring(Words[i].Length - Ending_tvorit_padeg[j].Length - 1, 1) == Consonants[k])
                                {//и перед словом идет один из придлогов П.п
                                    if (i != 0)
                                    {//если данное слово имеет нулевой номер перед ним не может стоять предлог
                                        for (int u = 0; u < pretext.Length; u++)
                                        {//цикл по всем предлогам П.п
                                            if (Words[i - 1] == pretext[u])//ессли предыдущее слово предлог П.п
                                            {
                                                flag = true;    //поднятие флага (прил в П.п с предлогом)
                                                break;          // выход из итерации цикла
                                            }
                                            else
                                            {//иначе данное слово сущ в форме Тв.п. т.к. перед ним нет предлога П.п
                                                Parts_of_speach[i] = "noun";    //данное слово сущ
                                                flag = true;     //поднятие флага (сущ в Тв.п)
                                                break;           // выход из итерации цикла
                                            }
                                        }
                                    }
                                    else
                                    {//иначе данное слово сущ в форме Тв.п. т.к. перед ним нет предлога П.п
                                        Parts_of_speach[i] = "noun";    //данное слово сущ
                                        flag = true;     //поднятие флага (сущ в Тв.п)
                                        break;           // выход из итерации цикла
                                    }
                                }//конец проверки на предлог

                            }

                        }//конец проверки на ОМ ЕМ
                    }
                }//конец цикла по окончаниям прилагательных в П.п
                if (flag) continue; //если флаг опущен то проверяем данное слово по окончаниям существительных
                                    //т.к. не были выявлены др части речи или сущ в Тв.п.

                for (int j = 0; j < ending.Length; j++)
                {//цикл по окончаниям сущ
                    if (Words[i].Length > ending[j].Length)
                    {
                        if (Words[i].Substring(Words[i].Length - ending[j].Length) == ending[j])
                        {//если окончание слова совпадает с окончанием сущ
                            Parts_of_speach[i] = "noun";    //данное слово сущ
                            flag = true;
                            break;           // выход из итерации цикла
                        }
                    }
                }
            }
        }
    }
    #endregion

    #region Поиск ГЛАГОЛОВ
    public static void findVerb()
    {

    }
    #endregion

    #region Поиск ПРИЧАСТИЙ
    public static void Participle()
    {
        
    }
    #endregion

    #region Поиск ДЕЕПРИЧАСТИЙ
    public static void Deeprichastie()
    {

    }

    #endregion
    */

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
            List<String> listOfSentenceNumbersForWord = new List <String>();
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
    public static void writeInFiles()
    {
        // Запись в файл с минимальной ошибкой второго рода
        using (StreamWriter outputFile = new StreamWriter(secondKindErrorFilePath))
        {
            outputFile.WriteLine("{0,-30} {1,5:N0}        {2,5:N0}", "Слово", "Количество", "Номера предложений");
            outputFile.WriteLine("      ПРИЛАГАТЕЛЬНЫЕ");
            for (var elementNumber = 0; elementNumber < wordList.Count; elementNumber++)
            {
                if (wordList[elementNumber].partOfSpeech == "Прилагательное")
                {
                    outputFile.WriteLine("{0,-30} {1,5:N0}             {2,-1:N0}",
                        wordList[elementNumber].word,
                        wordList[elementNumber].wordAmount,
                        wordList[elementNumber].sentenceNumber);
                }
            }

            outputFile.WriteLine("{0,-30} {1,5:N0}        {2,5:N0}", "Слово", "Количество", "Номера предложений");
            outputFile.WriteLine("      НАРЕЧИЯ");
            for (var elementNumber = 0; elementNumber < wordList.Count; elementNumber++)
            {
                if (wordList[elementNumber].partOfSpeech == "Наречие")
                {
                    outputFile.WriteLine("{0,-30} {1,5:N0}             {2,-1:N0}",
                        wordList[elementNumber].word,
                        wordList[elementNumber].wordAmount,
                        wordList[elementNumber].sentenceNumber);
                }
            }
        }

        /*// Запись в файл с минимальной ошибкой первого рода
        using (StreamWriter outputFile = new StreamWriter(firstKindErrorFilePath))
        {
            outputFile.WriteLine("{0,-30} {1,5:N0}        {2,5:N0}", "Слово", "Количество", "Номера предложений");
            outputFile.WriteLine("      ПРИЛАГАТЕЛЬНЫЕ");
            for (int listOfWordsFromFileElement = 0; listOfWordsFromFileElement < wordList.Count; listOfWordsFromFileElement++)
            {
                for (int listOfAdjectivesWithFirstTypeErrorElement = 0; listOfAdjectivesWithFirstTypeErrorElement < listOfAdjectivesWithFirstTypeError.Count; listOfAdjectivesWithFirstTypeErrorElement++)
                {
                    if (listOfAdjectivesWithFirstTypeError[listOfAdjectivesWithFirstTypeErrorElement]
                        == wordList[listOfWordsFromFileElement].word)
                    {
                        outputFile.WriteLine("{0,-30} {1,5:N0}             {2,-10:N0}",
                            wordList[listOfWordsFromFileElement].word,
                            wordList[listOfWordsFromFileElement].wordAmount,
                            wordList[listOfWordsFromFileElement].sentenceNumber);
                        break;
                    }
                }
            }
        }*/
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

}