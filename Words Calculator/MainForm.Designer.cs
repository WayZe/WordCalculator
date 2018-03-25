namespace Words_Calculator
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnChooseInputFile = new System.Windows.Forms.Button();
            this.tbInputText = new System.Windows.Forms.TextBox();
            this.grbFileWork = new System.Windows.Forms.GroupBox();
            this.tbOutputFilePath = new System.Windows.Forms.TextBox();
            this.tbInputFilePath = new System.Windows.Forms.TextBox();
            this.btnChooseOutputFile = new System.Windows.Forms.Button();
            this.cmbPartsOfSpeech = new System.Windows.Forms.ComboBox();
            this.btnClearInputTextBox = new System.Windows.Forms.Button();
            this.dgrvFoundWords = new System.Windows.Forms.DataGridView();
            this.lblFoundWords = new System.Windows.Forms.Label();
            this.lblChoosePartOfSpeech = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSentences = new System.Windows.Forms.TextBox();
            this.lblSentences = new System.Windows.Forms.Label();
            this.grbFileWork.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvFoundWords)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearch.Location = new System.Drawing.Point(294, 358);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(352, 97);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Анализ";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnChooseInputFile
            // 
            this.btnChooseInputFile.Location = new System.Drawing.Point(16, 19);
            this.btnChooseInputFile.Name = "btnChooseInputFile";
            this.btnChooseInputFile.Size = new System.Drawing.Size(158, 23);
            this.btnChooseInputFile.TabIndex = 10;
            this.btnChooseInputFile.Text = "Выбрать входной файл";
            this.btnChooseInputFile.UseVisualStyleBackColor = true;
            this.btnChooseInputFile.Click += new System.EventHandler(this.btnChooseInputFile_Click);
            // 
            // tbInputText
            // 
            this.tbInputText.Location = new System.Drawing.Point(24, 29);
            this.tbInputText.Multiline = true;
            this.tbInputText.Name = "tbInputText";
            this.tbInputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbInputText.Size = new System.Drawing.Size(622, 173);
            this.tbInputText.TabIndex = 17;
            this.tbInputText.TextChanged += new System.EventHandler(this.tbInputText_TextChanged);
            // 
            // grbFileWork
            // 
            this.grbFileWork.Controls.Add(this.tbOutputFilePath);
            this.grbFileWork.Controls.Add(this.tbInputFilePath);
            this.grbFileWork.Controls.Add(this.btnChooseOutputFile);
            this.grbFileWork.Controls.Add(this.btnChooseInputFile);
            this.grbFileWork.Location = new System.Drawing.Point(24, 255);
            this.grbFileWork.Name = "grbFileWork";
            this.grbFileWork.Size = new System.Drawing.Size(622, 88);
            this.grbFileWork.TabIndex = 18;
            this.grbFileWork.TabStop = false;
            this.grbFileWork.Text = "Работа с файлами";
            // 
            // tbOutputFilePath
            // 
            this.tbOutputFilePath.Location = new System.Drawing.Point(197, 54);
            this.tbOutputFilePath.Name = "tbOutputFilePath";
            this.tbOutputFilePath.Size = new System.Drawing.Size(415, 20);
            this.tbOutputFilePath.TabIndex = 13;
            // 
            // tbInputFilePath
            // 
            this.tbInputFilePath.Location = new System.Drawing.Point(197, 21);
            this.tbInputFilePath.Name = "tbInputFilePath";
            this.tbInputFilePath.Size = new System.Drawing.Size(415, 20);
            this.tbInputFilePath.TabIndex = 12;
            // 
            // btnChooseOutputFile
            // 
            this.btnChooseOutputFile.Location = new System.Drawing.Point(16, 52);
            this.btnChooseOutputFile.Name = "btnChooseOutputFile";
            this.btnChooseOutputFile.Size = new System.Drawing.Size(158, 23);
            this.btnChooseOutputFile.TabIndex = 11;
            this.btnChooseOutputFile.Text = "Выбрать выходной файл";
            this.btnChooseOutputFile.UseVisualStyleBackColor = true;
            this.btnChooseOutputFile.Click += new System.EventHandler(this.btnChooseOutputFile_Click);
            // 
            // cmbPartsOfSpeech
            // 
            this.cmbPartsOfSpeech.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPartsOfSpeech.FormattingEnabled = true;
            this.cmbPartsOfSpeech.Location = new System.Drawing.Point(24, 405);
            this.cmbPartsOfSpeech.Name = "cmbPartsOfSpeech";
            this.cmbPartsOfSpeech.Size = new System.Drawing.Size(208, 21);
            this.cmbPartsOfSpeech.TabIndex = 19;
            // 
            // btnClearInputTextBox
            // 
            this.btnClearInputTextBox.Location = new System.Drawing.Point(571, 208);
            this.btnClearInputTextBox.Name = "btnClearInputTextBox";
            this.btnClearInputTextBox.Size = new System.Drawing.Size(75, 23);
            this.btnClearInputTextBox.TabIndex = 20;
            this.btnClearInputTextBox.Text = "Очистить";
            this.btnClearInputTextBox.UseVisualStyleBackColor = true;
            this.btnClearInputTextBox.Click += new System.EventHandler(this.btnClearInputTextBox_Click_1);
            // 
            // dgrvFoundWords
            // 
            this.dgrvFoundWords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrvFoundWords.Location = new System.Drawing.Point(705, 57);
            this.dgrvFoundWords.Name = "dgrvFoundWords";
            this.dgrvFoundWords.Size = new System.Drawing.Size(220, 398);
            this.dgrvFoundWords.TabIndex = 21;
            this.dgrvFoundWords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.drwvFoundWords_CellClick);
            // 
            // lblFoundWords
            // 
            this.lblFoundWords.AutoSize = true;
            this.lblFoundWords.Location = new System.Drawing.Point(702, 29);
            this.lblFoundWords.Name = "lblFoundWords";
            this.lblFoundWords.Size = new System.Drawing.Size(101, 13);
            this.lblFoundWords.TabIndex = 22;
            this.lblFoundWords.Text = "Найденные слова:";
            // 
            // lblChoosePartOfSpeech
            // 
            this.lblChoosePartOfSpeech.AutoSize = true;
            this.lblChoosePartOfSpeech.Location = new System.Drawing.Point(21, 384);
            this.lblChoosePartOfSpeech.Name = "lblChoosePartOfSpeech";
            this.lblChoosePartOfSpeech.Size = new System.Drawing.Size(117, 13);
            this.lblChoosePartOfSpeech.TabIndex = 23;
            this.lblChoosePartOfSpeech.Text = "Выберите часть речи:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(212, 26);
            this.label1.TabIndex = 24;
            this.label1.Text = "Оставьте это поле пустым, если хотите \r\nпроанализировать все части речи";
            // 
            // tbSentences
            // 
            this.tbSentences.Location = new System.Drawing.Point(961, 57);
            this.tbSentences.Multiline = true;
            this.tbSentences.Name = "tbSentences";
            this.tbSentences.Size = new System.Drawing.Size(206, 398);
            this.tbSentences.TabIndex = 25;
            this.tbSentences.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSentences
            // 
            this.lblSentences.AutoSize = true;
            this.lblSentences.Location = new System.Drawing.Point(958, 29);
            this.lblSentences.Name = "lblSentences";
            this.lblSentences.Size = new System.Drawing.Size(198, 13);
            this.lblSentences.TabIndex = 26;
            this.lblSentences.Text = "Предложения для выбранного слова:";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 470);
            this.Controls.Add(this.lblSentences);
            this.Controls.Add(this.tbSentences);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblChoosePartOfSpeech);
            this.Controls.Add(this.lblFoundWords);
            this.Controls.Add(this.dgrvFoundWords);
            this.Controls.Add(this.btnClearInputTextBox);
            this.Controls.Add(this.cmbPartsOfSpeech);
            this.Controls.Add(this.grbFileWork);
            this.Controls.Add(this.tbInputText);
            this.Controls.Add(this.btnSearch);
            this.Name = "mainForm";
            this.Text = "Подсчёт слов";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.grbFileWork.ResumeLayout(false);
            this.grbFileWork.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrvFoundWords)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnChooseInputFile;
        private System.Windows.Forms.TextBox tbInputText;
        private System.Windows.Forms.GroupBox grbFileWork;
        private System.Windows.Forms.TextBox tbOutputFilePath;
        private System.Windows.Forms.TextBox tbInputFilePath;
        private System.Windows.Forms.Button btnChooseOutputFile;
        private System.Windows.Forms.ComboBox cmbPartsOfSpeech;
        private System.Windows.Forms.Button btnClearInputTextBox;
        private System.Windows.Forms.DataGridView dgrvFoundWords;
        private System.Windows.Forms.Label lblFoundWords;
        private System.Windows.Forms.Label lblChoosePartOfSpeech;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSentences;
        private System.Windows.Forms.Label lblSentences;
    }
}

