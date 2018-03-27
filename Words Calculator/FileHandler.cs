using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
namespace Words_Calculator
{
    public class FileHandler
    {
        ///ПУТИ К ФАЙЛАМ
        // Путь к входному файлу с текстом.
        private static String inputTextFilePath = @"";
        public static string InputTextFilePath { get => inputTextFilePath; set => inputTextFilePath = value; }
        // Путь к входному вспомогательному файлу.
        private const String inputSupportFilePath = @"InputSupportFile.txt";
        public static string InputSupportFilePath => inputSupportFilePath;
        // Путь к выходному файлу c ошибкой второго рода.
        private static String outputFilePath = @"";
        public static string OutputFilePath { get => outputFilePath; set => outputFilePath = value; }
        // Путь к выходному файлу с ошибкой первого рода.
        //private const String firstKindErrorFilePath = @"D:\Langs\C#\WordCalculator\FirstKindErrorOutputFile.txt";
        // Путь к выходному файлу с пронумерованными предложениями.
        private const String sentencesWithNumberFilePath = @"SentencesWithNumberOutputFile.txt";
        public static string SentencesWithNumberFilePath => sentencesWithNumberFilePath;
        // Начальная директория для открытия файла.
        private const String startDirectory = @"D:\Langs\C#";
        public static string StartDirectory => startDirectory;
        // Фильтр, чтобы можно было открывать только текстовые файлы.
        private const String filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        public static string Filter => filter;

        // Наличие открытого входного файла.
        private static bool isOpenOutputFile = false;
        public static bool IsOpenOutputFile { get => isOpenOutputFile; set => isOpenOutputFile = value; }

        // Наличие пустого выходного файла.
        private static bool isEmptyOutputFile = true;
        public static bool IsEmptyOutputFile { get => isEmptyOutputFile; set => isEmptyOutputFile = value; }

        // Получение пути к файлу.
        public static String PutFilePath()
        {
            String filePath = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = FileHandler.StartDirectory;
            openFileDialog.Filter = FileHandler.Filter;
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }

            return filePath;
        }
    }
}