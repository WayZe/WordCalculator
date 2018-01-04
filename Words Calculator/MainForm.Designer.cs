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
            this.searchButton = new System.Windows.Forms.Button();
            this.searchLabel = new System.Windows.Forms.Label();
            this.chbNoun = new System.Windows.Forms.CheckBox();
            this.chbAdjective = new System.Windows.Forms.CheckBox();
            this.chbVerb = new System.Windows.Forms.CheckBox();
            this.chbAdverb = new System.Windows.Forms.CheckBox();
            this.chbParticiple = new System.Windows.Forms.CheckBox();
            this.chbDeeprichastie = new System.Windows.Forms.CheckBox();
            this.chbAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(268, 82);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(100, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "Искать";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(12, 22);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(174, 13);
            this.searchLabel.TabIndex = 2;
            this.searchLabel.Text = "Выберите часть речи для поиска";
            // 
            // chbNoun
            // 
            this.chbNoun.AutoSize = true;
            this.chbNoun.Location = new System.Drawing.Point(15, 55);
            this.chbNoun.Name = "chbNoun";
            this.chbNoun.Size = new System.Drawing.Size(141, 17);
            this.chbNoun.TabIndex = 3;
            this.chbNoun.Text = "Имя существительное";
            this.chbNoun.UseVisualStyleBackColor = true;
            // 
            // chbAdjective
            // 
            this.chbAdjective.AutoSize = true;
            this.chbAdjective.Location = new System.Drawing.Point(15, 78);
            this.chbAdjective.Name = "chbAdjective";
            this.chbAdjective.Size = new System.Drawing.Size(133, 17);
            this.chbAdjective.TabIndex = 4;
            this.chbAdjective.Text = "Имя прилагательное";
            this.chbAdjective.UseVisualStyleBackColor = true;
            // 
            // chbVerb
            // 
            this.chbVerb.AutoSize = true;
            this.chbVerb.Location = new System.Drawing.Point(15, 100);
            this.chbVerb.Name = "chbVerb";
            this.chbVerb.Size = new System.Drawing.Size(61, 17);
            this.chbVerb.TabIndex = 5;
            this.chbVerb.Text = "Глагол";
            this.chbVerb.UseVisualStyleBackColor = true;
            // 
            // chbAdverb
            // 
            this.chbAdverb.AutoSize = true;
            this.chbAdverb.Location = new System.Drawing.Point(15, 123);
            this.chbAdverb.Name = "chbAdverb";
            this.chbAdverb.Size = new System.Drawing.Size(69, 17);
            this.chbAdverb.TabIndex = 6;
            this.chbAdverb.Text = "Наречие";
            this.chbAdverb.UseVisualStyleBackColor = true;
            // 
            // chbParticiple
            // 
            this.chbParticiple.AutoSize = true;
            this.chbParticiple.Location = new System.Drawing.Point(15, 146);
            this.chbParticiple.Name = "chbParticiple";
            this.chbParticiple.Size = new System.Drawing.Size(80, 17);
            this.chbParticiple.TabIndex = 7;
            this.chbParticiple.Text = "Причастие";
            this.chbParticiple.UseVisualStyleBackColor = true;
            // 
            // chbDeeprichastie
            // 
            this.chbDeeprichastie.AutoSize = true;
            this.chbDeeprichastie.Location = new System.Drawing.Point(15, 169);
            this.chbDeeprichastie.Name = "chbDeeprichastie";
            this.chbDeeprichastie.Size = new System.Drawing.Size(99, 17);
            this.chbDeeprichastie.TabIndex = 8;
            this.chbDeeprichastie.Text = "Деепричастие";
            this.chbDeeprichastie.UseVisualStyleBackColor = true;
            // 
            // chbAll
            // 
            this.chbAll.AutoSize = true;
            this.chbAll.Location = new System.Drawing.Point(15, 192);
            this.chbAll.Name = "chbAll";
            this.chbAll.Size = new System.Drawing.Size(102, 17);
            this.chbAll.TabIndex = 9;
            this.chbAll.Text = "Все части речи";
            this.chbAll.UseVisualStyleBackColor = true;
            this.chbAll.CheckedChanged += new System.EventHandler(this.chbAll_CheckedChanged);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 244);
            this.Controls.Add(this.chbAll);
            this.Controls.Add(this.chbDeeprichastie);
            this.Controls.Add(this.chbParticiple);
            this.Controls.Add(this.chbAdverb);
            this.Controls.Add(this.chbVerb);
            this.Controls.Add(this.chbAdjective);
            this.Controls.Add(this.chbNoun);
            this.Controls.Add(this.searchLabel);
            this.Controls.Add(this.searchButton);
            this.Name = "mainForm";
            this.Text = "Подсчёт слов";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.CheckBox chbNoun;
        private System.Windows.Forms.CheckBox chbAdjective;
        private System.Windows.Forms.CheckBox chbVerb;
        private System.Windows.Forms.CheckBox chbAdverb;
        private System.Windows.Forms.CheckBox chbParticiple;
        private System.Windows.Forms.CheckBox chbDeeprichastie;
        private System.Windows.Forms.CheckBox chbAll;
    }
}

