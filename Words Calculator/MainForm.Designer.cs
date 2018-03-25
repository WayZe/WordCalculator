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
            this.chbNoun = new System.Windows.Forms.CheckBox();
            this.chbAdjective = new System.Windows.Forms.CheckBox();
            this.chbVerb = new System.Windows.Forms.CheckBox();
            this.chbAdverb = new System.Windows.Forms.CheckBox();
            this.chbParticiple = new System.Windows.Forms.CheckBox();
            this.chbDeeprichastie = new System.Windows.Forms.CheckBox();
            this.chbAll = new System.Windows.Forms.CheckBox();
            this.btnChooseInputFile = new System.Windows.Forms.Button();
            this.grbPartsOfSpeech = new System.Windows.Forms.GroupBox();
            this.chbAnotherParts = new System.Windows.Forms.CheckBox();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.tbInputText = new System.Windows.Forms.TextBox();
            this.grbFileWork = new System.Windows.Forms.GroupBox();
            this.tbOutputFilePath = new System.Windows.Forms.TextBox();
            this.tbInputFilePath = new System.Windows.Forms.TextBox();
            this.btnChooseOutputFile = new System.Windows.Forms.Button();
            this.btnClearTextBox = new System.Windows.Forms.Button();
            this.grbPartsOfSpeech.SuspendLayout();
            this.grbFileWork.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearch.Location = new System.Drawing.Point(256, 368);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(140, 56);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "Анализ";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // chbNoun
            // 
            this.chbNoun.AutoSize = true;
            this.chbNoun.Location = new System.Drawing.Point(16, 19);
            this.chbNoun.Name = "chbNoun";
            this.chbNoun.Size = new System.Drawing.Size(141, 17);
            this.chbNoun.TabIndex = 3;
            this.chbNoun.Text = "Имя существительное";
            this.chbNoun.UseVisualStyleBackColor = true;
            // 
            // chbAdjective
            // 
            this.chbAdjective.AutoSize = true;
            this.chbAdjective.Location = new System.Drawing.Point(16, 42);
            this.chbAdjective.Name = "chbAdjective";
            this.chbAdjective.Size = new System.Drawing.Size(133, 17);
            this.chbAdjective.TabIndex = 4;
            this.chbAdjective.Text = "Имя прилагательное";
            this.chbAdjective.UseVisualStyleBackColor = true;
            // 
            // chbVerb
            // 
            this.chbVerb.AutoSize = true;
            this.chbVerb.Location = new System.Drawing.Point(16, 64);
            this.chbVerb.Name = "chbVerb";
            this.chbVerb.Size = new System.Drawing.Size(61, 17);
            this.chbVerb.TabIndex = 5;
            this.chbVerb.Text = "Глагол";
            this.chbVerb.UseVisualStyleBackColor = true;
            // 
            // chbAdverb
            // 
            this.chbAdverb.AutoSize = true;
            this.chbAdverb.Location = new System.Drawing.Point(16, 87);
            this.chbAdverb.Name = "chbAdverb";
            this.chbAdverb.Size = new System.Drawing.Size(69, 17);
            this.chbAdverb.TabIndex = 6;
            this.chbAdverb.Text = "Наречие";
            this.chbAdverb.UseVisualStyleBackColor = true;
            // 
            // chbParticiple
            // 
            this.chbParticiple.AutoSize = true;
            this.chbParticiple.Location = new System.Drawing.Point(16, 110);
            this.chbParticiple.Name = "chbParticiple";
            this.chbParticiple.Size = new System.Drawing.Size(80, 17);
            this.chbParticiple.TabIndex = 7;
            this.chbParticiple.Text = "Причастие";
            this.chbParticiple.UseVisualStyleBackColor = true;
            // 
            // chbDeeprichastie
            // 
            this.chbDeeprichastie.AutoSize = true;
            this.chbDeeprichastie.Location = new System.Drawing.Point(16, 133);
            this.chbDeeprichastie.Name = "chbDeeprichastie";
            this.chbDeeprichastie.Size = new System.Drawing.Size(99, 17);
            this.chbDeeprichastie.TabIndex = 8;
            this.chbDeeprichastie.Text = "Деепричастие";
            this.chbDeeprichastie.UseVisualStyleBackColor = true;
            // 
            // chbAll
            // 
            this.chbAll.AutoSize = true;
            this.chbAll.Location = new System.Drawing.Point(16, 179);
            this.chbAll.Name = "chbAll";
            this.chbAll.Size = new System.Drawing.Size(102, 17);
            this.chbAll.TabIndex = 9;
            this.chbAll.Text = "Все части речи";
            this.chbAll.UseVisualStyleBackColor = true;
            this.chbAll.CheckedChanged += new System.EventHandler(this.chbAll_CheckedChanged);
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
            // grbPartsOfSpeech
            // 
            this.grbPartsOfSpeech.Controls.Add(this.chbAnotherParts);
            this.grbPartsOfSpeech.Controls.Add(this.chbNoun);
            this.grbPartsOfSpeech.Controls.Add(this.chbAdjective);
            this.grbPartsOfSpeech.Controls.Add(this.chbAll);
            this.grbPartsOfSpeech.Controls.Add(this.chbVerb);
            this.grbPartsOfSpeech.Controls.Add(this.chbDeeprichastie);
            this.grbPartsOfSpeech.Controls.Add(this.chbAdverb);
            this.grbPartsOfSpeech.Controls.Add(this.chbParticiple);
            this.grbPartsOfSpeech.Location = new System.Drawing.Point(24, 29);
            this.grbPartsOfSpeech.Name = "grbPartsOfSpeech";
            this.grbPartsOfSpeech.Size = new System.Drawing.Size(200, 211);
            this.grbPartsOfSpeech.TabIndex = 12;
            this.grbPartsOfSpeech.TabStop = false;
            this.grbPartsOfSpeech.Text = "Выберите часть речи для поиска";
            // 
            // chbAnotherParts
            // 
            this.chbAnotherParts.AutoSize = true;
            this.chbAnotherParts.Location = new System.Drawing.Point(16, 156);
            this.chbAnotherParts.Name = "chbAnotherParts";
            this.chbAnotherParts.Size = new System.Drawing.Size(114, 17);
            this.chbAnotherParts.TabIndex = 10;
            this.chbAnotherParts.Text = "Остальные части";
            this.chbAnotherParts.UseVisualStyleBackColor = true;
            // 
            // btnStatistics
            // 
            this.btnStatistics.Location = new System.Drawing.Point(256, 446);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(140, 41);
            this.btnStatistics.TabIndex = 16;
            this.btnStatistics.Text = "Статистика";
            this.btnStatistics.UseVisualStyleBackColor = true;
            // 
            // tbInputText
            // 
            this.tbInputText.Location = new System.Drawing.Point(256, 29);
            this.tbInputText.Multiline = true;
            this.tbInputText.Name = "tbInputText";
            this.tbInputText.Size = new System.Drawing.Size(390, 173);
            this.tbInputText.TabIndex = 17;
            this.tbInputText.TextChanged += new System.EventHandler(this.tbInputText_TextChanged);
            // 
            // grbFileWork
            // 
            this.grbFileWork.Controls.Add(this.tbOutputFilePath);
            this.grbFileWork.Controls.Add(this.tbInputFilePath);
            this.grbFileWork.Controls.Add(this.btnChooseOutputFile);
            this.grbFileWork.Controls.Add(this.btnChooseInputFile);
            this.grbFileWork.Location = new System.Drawing.Point(24, 252);
            this.grbFileWork.Name = "grbFileWork";
            this.grbFileWork.Size = new System.Drawing.Size(631, 88);
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
            // btnClearTextBox
            // 
            this.btnClearTextBox.Location = new System.Drawing.Point(526, 214);
            this.btnClearTextBox.Name = "btnClearTextBox";
            this.btnClearTextBox.Size = new System.Drawing.Size(110, 26);
            this.btnClearTextBox.TabIndex = 19;
            this.btnClearTextBox.Text = "Очистить";
            this.btnClearTextBox.UseVisualStyleBackColor = true;
            this.btnClearTextBox.Click += new System.EventHandler(this.btnClearTextBox_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 509);
            this.Controls.Add(this.btnClearTextBox);
            this.Controls.Add(this.grbFileWork);
            this.Controls.Add(this.tbInputText);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.grbPartsOfSpeech);
            this.Controls.Add(this.btnSearch);
            this.Name = "mainForm";
            this.Text = "Подсчёт слов";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.grbPartsOfSpeech.ResumeLayout(false);
            this.grbPartsOfSpeech.PerformLayout();
            this.grbFileWork.ResumeLayout(false);
            this.grbFileWork.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.CheckBox chbNoun;
        private System.Windows.Forms.CheckBox chbAdjective;
        private System.Windows.Forms.CheckBox chbVerb;
        private System.Windows.Forms.CheckBox chbAdverb;
        private System.Windows.Forms.CheckBox chbParticiple;
        private System.Windows.Forms.CheckBox chbDeeprichastie;
        private System.Windows.Forms.CheckBox chbAll;
        private System.Windows.Forms.Button btnChooseInputFile;
        private System.Windows.Forms.GroupBox grbPartsOfSpeech;
        private System.Windows.Forms.CheckBox chbAnotherParts;
        private System.Windows.Forms.Button btnStatistics;
        private System.Windows.Forms.TextBox tbInputText;
        private System.Windows.Forms.GroupBox grbFileWork;
        private System.Windows.Forms.TextBox tbOutputFilePath;
        private System.Windows.Forms.TextBox tbInputFilePath;
        private System.Windows.Forms.Button btnChooseOutputFile;
        private System.Windows.Forms.Button btnClearTextBox;
    }
}

