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
            WordCalculator.readInputTextFile();

            WordCalculator.readInputEndsFile();

            WordCalculator.divideIntoSentences();
            
            WordCalculator.writeFileWithSentenceNumber();
            
            WordCalculator.divideIntoWords();
            
            WordCalculator.findAdjectivesWithMinFirstKindError();
            
            WordCalculator.findAdjectivesWithMinSecondKindError();
            
            WordCalculator.countWordAmount();
            
            WordCalculator.correctWordAmount();
            
            WordCalculator.writeFiles();
        }
        #endregion

        
    }
}
