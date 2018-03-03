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
            this.btnChoose = new System.Windows.Forms.Button();
            this.grbPartsOfSpeech = new System.Windows.Forms.GroupBox();
            this.chbFileOutput = new System.Windows.Forms.CheckBox();
            this.btnResult = new System.Windows.Forms.Button();
            this.btnFindSentence = new System.Windows.Forms.Button();
            this.chbAnotherParts = new System.Windows.Forms.CheckBox();
            this.btnStatistics = new System.Windows.Forms.Button();
            this.grbPartsOfSpeech.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearch.Location = new System.Drawing.Point(249, 63);
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
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(249, 11);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(140, 23);
            this.btnChoose.TabIndex = 10;
            this.btnChoose.Text = "Выбрать файл";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
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
            this.grbPartsOfSpeech.Location = new System.Drawing.Point(24, 23);
            this.grbPartsOfSpeech.Name = "grbPartsOfSpeech";
            this.grbPartsOfSpeech.Size = new System.Drawing.Size(200, 211);
            this.grbPartsOfSpeech.TabIndex = 12;
            this.grbPartsOfSpeech.TabStop = false;
            this.grbPartsOfSpeech.Text = "Выберите часть речи для поиска";
            // 
            // chbFileOutput
            // 
            this.chbFileOutput.AutoSize = true;
            this.chbFileOutput.Location = new System.Drawing.Point(261, 40);
            this.chbFileOutput.Name = "chbFileOutput";
            this.chbFileOutput.Size = new System.Drawing.Size(108, 17);
            this.chbFileOutput.TabIndex = 0;
            this.chbFileOutput.Text = "Вывести в файл";
            this.chbFileOutput.UseVisualStyleBackColor = true;
            // 
            // btnResult
            // 
            this.btnResult.Location = new System.Drawing.Point(249, 158);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(140, 41);
            this.btnResult.TabIndex = 14;
            this.btnResult.Text = "Посмотреть результат анализа";
            this.btnResult.UseVisualStyleBackColor = true;
            // 
            // btnFindSentence
            // 
            this.btnFindSentence.Location = new System.Drawing.Point(249, 125);
            this.btnFindSentence.Name = "btnFindSentence";
            this.btnFindSentence.Size = new System.Drawing.Size(140, 27);
            this.btnFindSentence.TabIndex = 15;
            this.btnFindSentence.Text = "Найти предложение";
            this.btnFindSentence.UseVisualStyleBackColor = true;
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
            this.btnStatistics.Location = new System.Drawing.Point(249, 205);
            this.btnStatistics.Name = "btnStatistics";
            this.btnStatistics.Size = new System.Drawing.Size(140, 41);
            this.btnStatistics.TabIndex = 16;
            this.btnStatistics.Text = "Статистика";
            this.btnStatistics.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 259);
            this.Controls.Add(this.btnStatistics);
            this.Controls.Add(this.btnFindSentence);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.chbFileOutput);
            this.Controls.Add(this.grbPartsOfSpeech);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnSearch);
            this.Name = "mainForm";
            this.Text = "Подсчёт слов";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.grbPartsOfSpeech.ResumeLayout(false);
            this.grbPartsOfSpeech.PerformLayout();
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
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.GroupBox grbPartsOfSpeech;
        private System.Windows.Forms.CheckBox chbFileOutput;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Button btnFindSentence;
        private System.Windows.Forms.CheckBox chbAnotherParts;
        private System.Windows.Forms.Button btnStatistics;
    }
}

