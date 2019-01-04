namespace OOP4
{
    partial class MainForm
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.maxCountTextBox = new System.Windows.Forms.TextBox();
            this.messageBoxPanel = new System.Windows.Forms.Panel();
            this.squareDetailRadioButton = new System.Windows.Forms.RadioButton();
            this.roundDetailRadioButton = new System.Windows.Forms.RadioButton();
            this.sphereDetailRadioButton = new System.Windows.Forms.RadioButton();
            this.conveyerStartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(13, 13);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(692, 555);
            this.mainPanel.TabIndex = 0;
            // 
            // maxCountTextBox
            // 
            this.maxCountTextBox.Location = new System.Drawing.Point(1238, 13);
            this.maxCountTextBox.Name = "maxCountTextBox";
            this.maxCountTextBox.Size = new System.Drawing.Size(33, 26);
            this.maxCountTextBox.TabIndex = 1;
            this.maxCountTextBox.Text = "5";
            // 
            // messageBoxPanel
            // 
            this.messageBoxPanel.BackColor = System.Drawing.Color.Beige;
            this.messageBoxPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.messageBoxPanel.Location = new System.Drawing.Point(711, 46);
            this.messageBoxPanel.Name = "messageBoxPanel";
            this.messageBoxPanel.Size = new System.Drawing.Size(560, 290);
            this.messageBoxPanel.TabIndex = 2;
            // 
            // squareDetailRadioButton
            // 
            this.squareDetailRadioButton.AutoSize = true;
            this.squareDetailRadioButton.Checked = true;
            this.squareDetailRadioButton.Location = new System.Drawing.Point(1040, 343);
            this.squareDetailRadioButton.Name = "squareDetailRadioButton";
            this.squareDetailRadioButton.Size = new System.Drawing.Size(188, 24);
            this.squareDetailRadioButton.TabIndex = 3;
            this.squareDetailRadioButton.TabStop = true;
            this.squareDetailRadioButton.Text = "Квадратная деталь";
            this.squareDetailRadioButton.UseVisualStyleBackColor = true;
            this.squareDetailRadioButton.CheckedChanged += new System.EventHandler(this.squareDetailRadioButton_CheckedChanged);
            // 
            // roundDetailRadioButton
            // 
            this.roundDetailRadioButton.AutoSize = true;
            this.roundDetailRadioButton.Location = new System.Drawing.Point(1040, 373);
            this.roundDetailRadioButton.Name = "roundDetailRadioButton";
            this.roundDetailRadioButton.Size = new System.Drawing.Size(156, 24);
            this.roundDetailRadioButton.TabIndex = 4;
            this.roundDetailRadioButton.Text = "Круглая деталь";
            this.roundDetailRadioButton.UseVisualStyleBackColor = true;
            this.roundDetailRadioButton.CheckedChanged += new System.EventHandler(this.roundDetailRadioButton_CheckedChanged);
            // 
            // sphereDetailRadioButton
            // 
            this.sphereDetailRadioButton.AutoSize = true;
            this.sphereDetailRadioButton.Location = new System.Drawing.Point(1039, 403);
            this.sphereDetailRadioButton.Name = "sphereDetailRadioButton";
            this.sphereDetailRadioButton.Size = new System.Drawing.Size(200, 24);
            this.sphereDetailRadioButton.TabIndex = 5;
            this.sphereDetailRadioButton.Text = "Сферическая деталь";
            this.sphereDetailRadioButton.UseVisualStyleBackColor = true;
            this.sphereDetailRadioButton.CheckedChanged += new System.EventHandler(this.sphereDetailRadioButton_CheckedChanged);
            // 
            // conveyerStartButton
            // 
            this.conveyerStartButton.Location = new System.Drawing.Point(711, 458);
            this.conveyerStartButton.Name = "conveyerStartButton";
            this.conveyerStartButton.Size = new System.Drawing.Size(560, 48);
            this.conveyerStartButton.TabIndex = 6;
            this.conveyerStartButton.Text = "Запустить конвейер";
            this.conveyerStartButton.UseVisualStyleBackColor = true;
            this.conveyerStartButton.Click += new System.EventHandler(this.conveyerStartButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 580);
            this.Controls.Add(this.conveyerStartButton);
            this.Controls.Add(this.sphereDetailRadioButton);
            this.Controls.Add(this.roundDetailRadioButton);
            this.Controls.Add(this.squareDetailRadioButton);
            this.Controls.Add(this.messageBoxPanel);
            this.Controls.Add(this.maxCountTextBox);
            this.Controls.Add(this.mainPanel);
            this.Name = "MainForm";
            this.Text = "OOP4";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.TextBox maxCountTextBox;
        private System.Windows.Forms.Panel messageBoxPanel;
        private System.Windows.Forms.RadioButton squareDetailRadioButton;
        private System.Windows.Forms.RadioButton roundDetailRadioButton;
        private System.Windows.Forms.RadioButton sphereDetailRadioButton;
        private System.Windows.Forms.Button conveyerStartButton;
    }
}

