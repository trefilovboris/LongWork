namespace Client
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.Argument1 = new System.Windows.Forms.TextBox();
            this.CommandList = new System.Windows.Forms.ComboBox();
            this.ApplyCommand = new System.Windows.Forms.Button();
            this.ResultTextBox = new System.Windows.Forms.RichTextBox();
            this.HelpForArgument1 = new System.Windows.Forms.Label();
            this.HelpForArgument2 = new System.Windows.Forms.Label();
            this.Argument2 = new System.Windows.Forms.TextBox();
            this.Choose1 = new System.Windows.Forms.Button();
            this.Choose2 = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.OpenFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // Argument1
            // 
            this.Argument1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.Argument1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Argument1.Location = new System.Drawing.Point(38, 86);
            this.Argument1.Name = "Argument1";
            this.Argument1.Size = new System.Drawing.Size(385, 20);
            this.Argument1.TabIndex = 1;
            this.Argument1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Argument1.Visible = false;
            // 
            // CommandList
            // 
            this.CommandList.BackColor = System.Drawing.SystemColors.MenuBar;
            this.CommandList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CommandList.FormattingEnabled = true;
            this.CommandList.Location = new System.Drawing.Point(38, 32);
            this.CommandList.Name = "CommandList";
            this.CommandList.Size = new System.Drawing.Size(386, 21);
            this.CommandList.TabIndex = 7;
            this.CommandList.SelectedIndexChanged += new System.EventHandler(this.CommandList_SelectedIndexChanged);
            // 
            // ApplyCommand
            // 
            this.ApplyCommand.BackColor = System.Drawing.Color.Aqua;
            this.ApplyCommand.Location = new System.Drawing.Point(143, 364);
            this.ApplyCommand.Name = "ApplyCommand";
            this.ApplyCommand.Size = new System.Drawing.Size(211, 51);
            this.ApplyCommand.TabIndex = 8;
            this.ApplyCommand.Text = "Выполнить команду";
            this.ApplyCommand.UseVisualStyleBackColor = false;
            this.ApplyCommand.Click += new System.EventHandler(this.ApplyCommand_Click);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.BackColor = System.Drawing.Color.LavenderBlush;
            this.ResultTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ResultTextBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ResultTextBox.Location = new System.Drawing.Point(31, 182);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.ReadOnly = true;
            this.ResultTextBox.Size = new System.Drawing.Size(401, 149);
            this.ResultTextBox.TabIndex = 9;
            this.ResultTextBox.Text = "";
          
            // 
            // HelpForArgument1
            // 
            this.HelpForArgument1.AutoSize = true;
            this.HelpForArgument1.BackColor = System.Drawing.Color.RoyalBlue;
            this.HelpForArgument1.Location = new System.Drawing.Point(36, 62);
            this.HelpForArgument1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HelpForArgument1.Name = "HelpForArgument1";
            this.HelpForArgument1.Size = new System.Drawing.Size(0, 13);
            this.HelpForArgument1.TabIndex = 10;
            this.HelpForArgument1.Visible = false;
            // 
            // HelpForArgument2
            // 
            this.HelpForArgument2.AutoSize = true;
            this.HelpForArgument2.BackColor = System.Drawing.Color.RoyalBlue;
            this.HelpForArgument2.Location = new System.Drawing.Point(36, 115);
            this.HelpForArgument2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HelpForArgument2.Name = "HelpForArgument2";
            this.HelpForArgument2.Size = new System.Drawing.Size(0, 13);
            this.HelpForArgument2.TabIndex = 11;
            this.HelpForArgument2.Visible = false;
            // 
            // Argument2
            // 
            this.Argument2.Location = new System.Drawing.Point(38, 143);
            this.Argument2.Margin = new System.Windows.Forms.Padding(2);
            this.Argument2.Name = "Argument2";
            this.Argument2.Size = new System.Drawing.Size(385, 20);
            this.Argument2.TabIndex = 12;
            this.Argument2.Visible = false;
            // 
            // Choose1
            // 
            this.Choose1.Location = new System.Drawing.Point(429, 84);
            this.Choose1.Name = "Choose1";
            this.Choose1.Size = new System.Drawing.Size(28, 20);
            this.Choose1.TabIndex = 13;
            this.Choose1.Text = "...";
            this.Choose1.UseVisualStyleBackColor = true;
            this.Choose1.Visible = false;
            this.Choose1.Click += new System.EventHandler(this.Choose1_Click);
            // 
            // Choose2
            // 
            this.Choose2.Location = new System.Drawing.Point(429, 143);
            this.Choose2.Name = "Choose2";
            this.Choose2.Size = new System.Drawing.Size(28, 23);
            this.Choose2.TabIndex = 14;
            this.Choose2.Text = "...";
            this.Choose2.UseVisualStyleBackColor = true;
            this.Choose2.Visible = false;
            this.Choose2.Click += new System.EventHandler(this.Choose2_Click);
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "openFileDialog1";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Pink;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(483, 482);
            this.Controls.Add(this.Choose2);
            this.Controls.Add(this.Choose1);
            this.Controls.Add(this.Argument2);
            this.Controls.Add(this.HelpForArgument2);
            this.Controls.Add(this.HelpForArgument1);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.ApplyCommand);
            this.Controls.Add(this.CommandList);
            this.Controls.Add(this.Argument1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClientForm";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Argument1;
        private System.Windows.Forms.ComboBox CommandList;
        private System.Windows.Forms.Button ApplyCommand;
        private System.Windows.Forms.RichTextBox ResultTextBox;
        private System.Windows.Forms.Label HelpForArgument1;
        private System.Windows.Forms.Label HelpForArgument2;
        private System.Windows.Forms.TextBox Argument2;
        private System.Windows.Forms.Button Choose1;
        private System.Windows.Forms.Button Choose2;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.FolderBrowserDialog OpenFolder;
    }
}

