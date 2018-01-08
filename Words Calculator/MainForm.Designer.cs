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
            this.msMenu = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.tsmiAppInformation = new System.Windows.Forms.ToolStripMenuItem();
            this.grbPartsOfSpeech = new System.Windows.Forms.GroupBox();
            this.grbOutputOptions = new System.Windows.Forms.GroupBox();
            this.chbFileOutput = new System.Windows.Forms.CheckBox();
            this.chbScreenOutput = new System.Windows.Forms.CheckBox();
            this.msMenu.SuspendLayout();
            this.grbPartsOfSpeech.SuspendLayout();
            this.grbOutputOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSearch.Location = new System.Drawing.Point(233, 134);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(170, 108);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "КНОПКА НАЙТИ ДЛЯ ЕБАНОГО ФЕДИ";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.searchButton_Click);
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
            this.chbAll.Location = new System.Drawing.Point(16, 156);
            this.chbAll.Name = "chbAll";
            this.chbAll.Size = new System.Drawing.Size(102, 17);
            this.chbAll.TabIndex = 9;
            this.chbAll.Text = "Все части речи";
            this.chbAll.UseVisualStyleBackColor = true;
            this.chbAll.CheckedChanged += new System.EventHandler(this.chbAll_CheckedChanged);
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(242, 27);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(161, 23);
            this.btnChoose.TabIndex = 10;
            this.btnChoose.Text = "Выбрать файл с текстом";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // msMenu
            // 
            this.msMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiAppInformation});
            this.msMenu.Location = new System.Drawing.Point(0, 0);
            this.msMenu.Name = "msMenu";
            this.msMenu.Size = new System.Drawing.Size(415, 24);
            this.msMenu.TabIndex = 11;
            this.msMenu.Text = "menuStrip";
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(48, 20);
            this.tsmiFile.Text = "Файл";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 23);
            this.toolStripTextBox1.Text = "Открыть";
            // 
            // tsmiAppInformation
            // 
            this.tsmiAppInformation.Name = "tsmiAppInformation";
            this.tsmiAppInformation.Size = new System.Drawing.Size(65, 20);
            this.tsmiAppInformation.Text = "Справка";
            // 
            // grbPartsOfSpeech
            // 
            this.grbPartsOfSpeech.Controls.Add(this.chbNoun);
            this.grbPartsOfSpeech.Controls.Add(this.chbAdjective);
            this.grbPartsOfSpeech.Controls.Add(this.chbAll);
            this.grbPartsOfSpeech.Controls.Add(this.chbVerb);
            this.grbPartsOfSpeech.Controls.Add(this.chbDeeprichastie);
            this.grbPartsOfSpeech.Controls.Add(this.chbAdverb);
            this.grbPartsOfSpeech.Controls.Add(this.chbParticiple);
            this.grbPartsOfSpeech.Location = new System.Drawing.Point(12, 39);
            this.grbPartsOfSpeech.Name = "grbPartsOfSpeech";
            this.grbPartsOfSpeech.Size = new System.Drawing.Size(200, 189);
            this.grbPartsOfSpeech.TabIndex = 12;
            this.grbPartsOfSpeech.TabStop = false;
            this.grbPartsOfSpeech.Text = "Выберите часть речи для поиска";
            // 
            // grbOutputOptions
            // 
            this.grbOutputOptions.Controls.Add(this.chbScreenOutput);
            this.grbOutputOptions.Controls.Add(this.chbFileOutput);
            this.grbOutputOptions.Location = new System.Drawing.Point(242, 56);
            this.grbOutputOptions.Name = "grbOutputOptions";
            this.grbOutputOptions.Size = new System.Drawing.Size(140, 72);
            this.grbOutputOptions.TabIndex = 13;
            this.grbOutputOptions.TabStop = false;
            this.grbOutputOptions.Text = "Параметры вывода";
            // 
            // chbFileOutput
            // 
            this.chbFileOutput.AutoSize = true;
            this.chbFileOutput.Location = new System.Drawing.Point(6, 19);
            this.chbFileOutput.Name = "chbFileOutput";
            this.chbFileOutput.Size = new System.Drawing.Size(108, 17);
            this.chbFileOutput.TabIndex = 0;
            this.chbFileOutput.Text = "Вывести в файл";
            this.chbFileOutput.UseVisualStyleBackColor = true;
            // 
            // chbScreenOutput
            // 
            this.chbScreenOutput.AutoSize = true;
            this.chbScreenOutput.Location = new System.Drawing.Point(6, 42);
            this.chbScreenOutput.Name = "chbScreenOutput";
            this.chbScreenOutput.Size = new System.Drawing.Size(118, 17);
            this.chbScreenOutput.TabIndex = 1;
            this.chbScreenOutput.Text = "Вывести на экран";
            this.chbScreenOutput.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 244);
            this.Controls.Add(this.grbOutputOptions);
            this.Controls.Add(this.grbPartsOfSpeech);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.msMenu);
            this.MainMenuStrip = this.msMenu;
            this.Name = "mainForm";
            this.Text = "Подсчёт слов";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.msMenu.ResumeLayout(false);
            this.msMenu.PerformLayout();
            this.grbPartsOfSpeech.ResumeLayout(false);
            this.grbPartsOfSpeech.PerformLayout();
            this.grbOutputOptions.ResumeLayout(false);
            this.grbOutputOptions.PerformLayout();
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
        private System.Windows.Forms.MenuStrip msMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem tsmiAppInformation;
        private System.Windows.Forms.GroupBox grbPartsOfSpeech;
        private System.Windows.Forms.GroupBox grbOutputOptions;
        private System.Windows.Forms.CheckBox chbScreenOutput;
        private System.Windows.Forms.CheckBox chbFileOutput;
    }
}

