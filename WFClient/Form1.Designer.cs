namespace WFClient
{
    partial class Form1
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
            this.buttonEnter = new System.Windows.Forms.Button();
            this.listBoxOut = new System.Windows.Forms.ListBox();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonEnter
            // 
            this.buttonEnter.BackColor = System.Drawing.Color.Transparent;
            this.buttonEnter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonEnter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEnter.Location = new System.Drawing.Point(457, 356);
            this.buttonEnter.Margin = new System.Windows.Forms.Padding(0);
            this.buttonEnter.Name = "buttonEnter";
            this.buttonEnter.Size = new System.Drawing.Size(56, 26);
            this.buttonEnter.TabIndex = 1;
            this.buttonEnter.Text = "GO";
            this.buttonEnter.UseVisualStyleBackColor = false;
            this.buttonEnter.Click += new System.EventHandler(this.buttonEnter_Click);
            // 
            // listBoxOut
            // 
            this.listBoxOut.FormattingEnabled = true;
            this.listBoxOut.ItemHeight = 16;
            this.listBoxOut.Items.AddRange(new object[] {
            "Для вывода всех команд введите help"});
            this.listBoxOut.Location = new System.Drawing.Point(0, 0);
            this.listBoxOut.Margin = new System.Windows.Forms.Padding(0);
            this.listBoxOut.Name = "listBoxOut";
            this.listBoxOut.Size = new System.Drawing.Size(511, 356);
            this.listBoxOut.TabIndex = 2;
            this.listBoxOut.TabStop = false;
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(0, 356);
            this.textBoxCommand.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(457, 22);
            this.textBoxCommand.TabIndex = 0;
            this.textBoxCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCommand_KeyPress);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(536, 425);
            this.Controls.Add(this.textBoxCommand);
            this.Controls.Add(this.listBoxOut);
            this.Controls.Add(this.buttonEnter);
            this.Name = "Form1";
            this.Text = "CommandsBot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEnter;
        private System.Windows.Forms.ListBox listBoxOut;
        private System.Windows.Forms.TextBox textBoxCommand;
    }
}

