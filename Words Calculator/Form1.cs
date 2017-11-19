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
        private List<String> stringList = new List<String>();
        private String fileString;
        private const String filePath = "D:\\Langs\\C#\\WordsCalculator\\InputFile.txt";

        public mainForm()
        {
            InitializeComponent();
            //stringList.Add("");
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            searchComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            searchComboBox.Items.Add("Прилагательное");
            searchComboBox.SelectedIndex = 0;

        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            readText();
            listCreating();

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

            //Console.WriteLine(separatorArrayt.Count());
            //List<String> stringList = new List<String>();

            foreach (String element in separatorArrayt)
            {
                if(element != "")
                    stringList.Add(element);
            }

            foreach (String element in stringList)
            {
                System.Console.WriteLine(element);
            }

            Console.WriteLine(stringList.Count());
        }
    }
}
