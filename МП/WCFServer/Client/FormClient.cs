using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using Client.ServiceReference1;
using System.IO;
using System.Diagnostics;
using WCFServer;
namespace Client
{
    public partial class ClientForm : Form
    {
        CommandClient client;
        public ClientForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ClientForm_KeyUp);
        }

        private void ClientForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ApplyCommand.PerformClick();
        }


        private void CommandList_SelectedIndexChanged(object sender, EventArgs e)
        {
            HelpForArgument1.Visible = false;
            Argument1.Visible = false;
            HelpForArgument2.Visible = false;
            Argument2.Visible = false;
            Choose1.Visible = false;
            Choose2.Visible = false;
            if (CommandList.SelectedIndex == (int)NumberCommands.Showdir)
            {
                HelpForArgument1.Visible = true;
                Argument1.Visible = true;
                HelpForArgument1.Text = "Введите путь по которому хотите увидеть список файлов";
            }
            if (CommandList.SelectedIndex == (int)NumberCommands.Startapp)
            {
                HelpForArgument1.Visible = true;
                Argument1.Visible = true;
                HelpForArgument2.Visible = true;
                Argument2.Visible = true;
                HelpForArgument1.Text = "Введите адрес приложения которое хотите запустить";
                HelpForArgument2.Text = "Введите параметры";
            }
            if (CommandList.SelectedIndex == (int)NumberCommands.Delete)
            {
                HelpForArgument1.Visible = true;
                Argument1.Visible = true;
                HelpForArgument1.Text = "Введите имя файла, который хотите удалить";
            }
            if (CommandList.SelectedIndex == (int)NumberCommands.Upload)
            {
                HelpForArgument1.Visible = true;
                Argument1.Visible = true;
                HelpForArgument2.Visible = true;
                Argument2.Visible = true;
                Choose1.Visible = true;
                HelpForArgument1.Text = "Введите файл который хотите загрузить";
                HelpForArgument2.Text = "Введите куда хотите загрузить";
            }
            if (CommandList.SelectedIndex == (int)NumberCommands.Changedir)
            {
                HelpForArgument1.Visible = true;
                Argument1.Visible = true;
                HelpForArgument1.Text = "Введите директорию на которую хотите сменить текущую";
            }
            if (CommandList.SelectedIndex == (int)NumberCommands.Download)
            {
                HelpForArgument1.Visible = true;
                Argument1.Visible = true;
                HelpForArgument2.Visible = true;
                Argument2.Visible = true;
                HelpForArgument1.Text = "Введите файл который хотите выгрузить";
                HelpForArgument2.Text = "Введите куда хотите выгрузить";
                Choose2.Visible = true;
            }
        }

        private void ApplyCommand_Click(object sender, EventArgs e)
        {
            ResultTextBox.Text = "";
            InstanceContext instanceContext = new InstanceContext(this);
            client = new CommandClient(instanceContext);
            int select = CommandList.SelectedIndex;
                CommandResult StatusCommand = new CommandResult();
                StatusCommand.CodeCommand = select;
                StatusCommand.FirstParametr = Argument1.Text;
                StatusCommand.SecondParametr = Argument2.Text;
                if (StatusCommand.CodeCommand == (int)NumberCommands.Upload)
                {
                    ReadBites ReadFile = new ReadBites(StatusCommand.FirstParametr);
                    StatusCommand.Data = ReadFile._Data;
                    StatusCommand.IsSuccesed = ReadFile._IsSuccesed;
                    StatusCommand.Error = ReadFile._Error;
                    StatusCommand.FirstParametr = ReadFile._FirstParametr;
                }
         
               var  ResultCommand = client.Execute(StatusCommand);

            if (StatusCommand.CodeCommand == (int)NumberCommands.Download && ResultCommand.IsSuccesed == true)
            {
                var DownloadFile = new UploadFileInComputer(ResultCommand.SecondParametr, ResultCommand.Data, ResultCommand.FirstParametr);
                ResultCommand.Error = DownloadFile._Error;
                ResultCommand.IsSuccesed = DownloadFile._IsSuccesed;
                ResultCommand.Result = DownloadFile._Result;
            }
                if (ResultCommand.IsSuccesed == false)
                {
                    ResultTextBox.Text = ResultCommand.Error;
                }
                else
                {
                    for (int i = 0; i < ResultCommand.Result.Length; ++i)
                    {
                        ResultTextBox.Text += ResultCommand.Result[i];
                        ResultTextBox.Text += "\n";
                    }
                }
        }
        private void ClientForm_Load(object sender, EventArgs e)
        {
            CommandList.Items.Add("Получить список файлов по указанному пути");
            CommandList.Items.Add("Получить список дисков");
            CommandList.Items.Add("Получить текущую директорию");
            CommandList.Items.Add("Запустить приложение с параметрами");
            CommandList.Items.Add("Удалить файл");
            CommandList.Items.Add("Сменить текущий диск и каталог");
            CommandList.Items.Add("Загрузить файл на сервер");
            CommandList.Items.Add("Загрузить файл с сервера");
            
        }

        private void Choose1_Click(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog() == DialogResult.OK)
            {
                Argument1.Text = OpenFile.FileName;
            }
        }

        private void Choose2_Click(object sender, EventArgs e)
        {
            if (OpenFolder.ShowDialog() == DialogResult.OK)
            {
                Argument2.Text = OpenFolder.SelectedPath;
            }
        }
    }
}
