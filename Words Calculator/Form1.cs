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
        private List<String> stringList;
        private String fileString;
        private const String filePath = "D:\\Langs\\C#\\Words Calculator\\InputFile.txt";

        public mainForm()
        {
            InitializeComponent();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            readText();
        }

        private void readText()
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader streamReader = new StreamReader(filePath, Encoding.GetEncoding(1251)))
                {
                    // Read the stream to a string, and write the string to the console.
                    String line = streamReader.ReadToEnd();
                    Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            //return 
        }
    }
}
