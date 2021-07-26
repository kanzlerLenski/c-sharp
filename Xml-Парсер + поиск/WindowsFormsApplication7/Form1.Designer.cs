namespace WindowsFormsApplication7
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.myBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.myList = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // myBox
            // 
            this.myBox.Location = new System.Drawing.Point(310, 7);
            this.myBox.Multiline = true;
            this.myBox.Name = "myBox";
            this.myBox.Size = new System.Drawing.Size(210, 41);
            this.myBox.TabIndex = 1;
            this.myBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(310, 54);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Поиск";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(310, 83);
            this.result.Multiline = true;
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(226, 519);
            this.result.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(4, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(210, 33);
            this.button2.TabIndex = 4;
            this.button2.Text = "Посмотреть структуру документа";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // myList
            // 
            this.myList.Location = new System.Drawing.Point(4, 54);
            this.myList.Multiline = true;
            this.myList.Name = "myList";
            this.myList.Size = new System.Drawing.Size(300, 548);
            this.myList.TabIndex = 5;
            this.myList.TextChanged += new System.EventHandler(this.myList_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 614);
            this.Controls.Add(this.myList);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.result);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.myBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox myBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox myList;
    }
}

