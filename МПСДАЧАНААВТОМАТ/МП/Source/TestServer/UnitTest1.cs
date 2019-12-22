using NUnit.Framework;
using WCFServer;
using System.IO;
using System.Diagnostics;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class DownloadFileCommandTests
    {
        [SetUp]
        public void Setup()
        {
            DownloadFileCommand downloadFile = new DownloadFileCommand();
            _downloadFile = downloadFile;
        }

        [Test]
        public void Test1()
        {
            FileStream fs = File.Create("Test.txt");
            string[] s = {"Тестовая строка"};
            fs.Close();
            System.IO.File.WriteAllLines("Test.txt", s);
            byte[] data = Encoding.Default.GetBytes("Тестовая строка\r\n");
            CommandResult res = new CommandResult();
            res.FirstParametr = "Test.txt";
            res.SecondParametr = "";
            res = _downloadFile.Execute(res);
            Assert.AreEqual(data, res.Data);
            File.Delete("Test.txt");
        }

        [Test]
        public void Test2()
        {
            CommandResult res = new CommandResult();
            res.FirstParametr = "Test.txt";
            res.Data = null;
            try
            {
                res = _downloadFile.Execute(res);
            }
            catch (Exception ex)
            {
                Assert.NotNull(ex);
            }
        }
        DownloadFileCommand _downloadFile;
    }

    public class StartAppCommandTests
    {
        [SetUp]
        public void Setup()
        {
            StartAppCommand startAppCommand = new StartAppCommand();
            _startAppCommand = startAppCommand;
        }

        [Test]
        public void Test1()
        {
            CommandResult res = new CommandResult();
            res.FirstParametr = "cmd1.exe";
            res.SecondParametr = "";
            res = _startAppCommand.Execute(res);
            Process[] processList = Process.GetProcessesByName("cmd1");
            Assert.False(processList.Length > 0);
        }
        [Test]
        public void Test2()
        {
            CommandResult res = new CommandResult();
            res.FirstParametr = "cmd.exe";
            res.SecondParametr = "";
            res = _startAppCommand.Execute(res);
            Process[] processList = Process.GetProcessesByName("cmd");
            Assert.True(processList.Length > 0);
        }
        [Test]
        public void Test3()
        {
            CommandResult res = new CommandResult();
            res.FirstParametr = "cmd.exe /k java -v";
            res.SecondParametr = "";
            res = _startAppCommand.Execute(res);
            Process[] processList = Process.GetProcessesByName("cmd");
            Assert.True(processList.Length > 0);
        }
        StartAppCommand _startAppCommand;
    }
    public class UploadFileCommandTests
    {
        [SetUp]
        public void Setup()
        {
            UploadFileCommand uploadFileCommand = new UploadFileCommand();
            _uploadFileCommand = uploadFileCommand;
        }
        [Test]
        public void Test1()
        {
            CommandResult res = new CommandResult();
            res.FirstParametr = "Test.txt";
            res.Data = Encoding.Default.GetBytes("Тестовая строка");
            res.IsSuccesed = true;
            res.SecondParametr = "";
            res = _uploadFileCommand.Execute(res);
            Assert.True(File.Exists("Test.txt"));
            string s = "Файл Test.txt записан в директорию";
            Assert.IsTrue(s == res.Result[0]);
        }
        [Test]
        public void Test2()
        {
            CommandResult res = new CommandResult();
            res.FirstParametr = "Test.txt";
            res.Data = Encoding.Default.GetBytes("");
            res.IsSuccesed = true;
            res.SecondParametr = "";
            res = _uploadFileCommand.Execute(res);
            Assert.AreEqual("", System.IO.File.ReadAllLines("Test.txt"));
        }
        UploadFileCommand _uploadFileCommand;
    }
    public class ShowdirCommandTests
    {
        [SetUp]
        public void Setup()
        {
            ShowdirCommand showdirCommand = new ShowdirCommand();
            _showdirCommand = showdirCommand;
        }
        [Test]
        public void Test1()
        {
            string Parametrs = "TestServer.dll";
            CommandResult res = new CommandResult();
            res.FirstParametr = AppDomain.CurrentDomain.BaseDirectory;
            res.FirstParametr += Parametrs;
            res = _showdirCommand.Execute(res);
            Assert.AreEqual("Это файл", res.Error);
        }
        [Test]
        public void Test2()
        {
            string Parametrs = "gdfgt.txt";
            CommandResult res = new CommandResult();
            res.FirstParametr = AppDomain.CurrentDomain.BaseDirectory;
            res.FirstParametr += Parametrs;
            res = _showdirCommand.Execute(res);
            Assert.AreEqual("Нет такой директории", res.Error);
        }
        [Test]
        public void Test3()
        {
            CommandResult res = new CommandResult();
            res.FirstParametr = AppDomain.CurrentDomain.BaseDirectory;
            res.FirstParametr += "//Test";
            res = _showdirCommand.Execute(res);
            Assert.IsTrue(res.Result[0] == "Директории: ");
            Assert.IsTrue(res.Result[1] == "TestDir");
            Assert.IsTrue(res.Result[2] == "Файлы: ");
            Assert.IsTrue(res.Result[3] == "1.txt");
        }
        ShowdirCommand _showdirCommand;
    }
    public class ShowdiskCommandTests
    {
        [SetUp]
        public void Setup()
        {
            ShowdiskCommand showdiskCommand = new ShowdiskCommand();
            _showdiskCommand = showdiskCommand;
        }
        [Test]
        public void Test1()
        {
            CommandResult res = new CommandResult();
            res.FirstParametr = "";
            res = _showdiskCommand.Execute(res);
            string[] Drives = Environment.GetLogicalDrives();
            int i = 1;
            foreach (string item in Drives)
            {

                Assert.IsTrue(item == res.Result[i]);
                ++i;
            }
        }
        ShowdiskCommand _showdiskCommand;
    }
    public class DirectoryCommandTests
    {
        [SetUp]
        public void Setup()
        {
            DirectoryCommand directoryCommand = new DirectoryCommand();
            _directoryCommand = directoryCommand;
        }
        [Test]
        public void Test1()
        {
            CommandResult res = new CommandResult();
            res.FirstParametr = "";
            res = _directoryCommand.Execute(res);
            Assert.IsTrue(AppDomain.CurrentDomain.BaseDirectory == res.Result[1]);
            Assert.IsTrue("Текущая директория: "==res.Result[0]);
        }

        DirectoryCommand _directoryCommand;
    }

    public class DeleteFileCommandTests
    {
        [SetUp]
        public void Setup()
        {
            DeleteFileCommand deleteFileCommand = new DeleteFileCommand();
            _deleteFileCommand = deleteFileCommand;
        }
        [Test]
        public void Test1()
        {
            CommandResult res = new CommandResult();
            res.FirstParametr = "Delete.txt";
            byte[] data = { };
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, res.FirstParametr);
            File.WriteAllBytes(path, data);
            Assert.True(File.Exists("Delete.txt"));
            res = _deleteFileCommand.Execute(res);
            Assert.True(!File.Exists("Delete.txt"));
        }
        [Test]
        public void Test2()
        {
            CommandResult res = new CommandResult();
            res.FirstParametr = "qwqw.txt";
            res= _deleteFileCommand.Execute(res);
            Assert.True("Нет файла с именем: qwqw.txt" == res.Error);
        }
        DeleteFileCommand _deleteFileCommand;
    }

    public class ChangeDirCommandTests
    {
        [SetUp]
        public void Setup()
        {
            ChangeDirCommand changeDirCommand = new ChangeDirCommand();
            _changeDirCommand = changeDirCommand;
        }
        [Test]
        public void Test1()
        {
            CommandResult res = new CommandResult();
            string Parametrs = AppDomain.CurrentDomain.BaseDirectory;
            string Reverse = Parametrs;
            Parametrs += "Test";
            res.FirstParametr = Parametrs;
            Directory.SetCurrentDirectory(Reverse);
            string s = Parametrs + " - это новая директория";
            res = _changeDirCommand.Execute(res);
            Directory.SetCurrentDirectory(Reverse);
            Assert.AreEqual(s, res.Result[0]);
        }
        [Test]
        public void Test2()
        {
            CommandResult res = new CommandResult();
            string Parametrs = AppDomain.CurrentDomain.BaseDirectory;
            Parametrs += "NoDir";
            res = _changeDirCommand.Execute(res);
            Assert.AreEqual("Нет такой директории", res.Error);
        }
        ChangeDirCommand _changeDirCommand;
    }

    public class MacroCommandTests
    {
        [SetUp]
        public void Setup()
        {
            MacroCommand macroCommand = new MacroCommand();
            _macroCommand = macroCommand;
        }
        [Test]
        public void Test1()
        {
            ShowdirCommand commandOne = new ShowdirCommand();
            ShowdiskCommand commandTwo = new ShowdiskCommand();
            DirectoryCommand commandThree = new DirectoryCommand();
            StartAppCommand commandFour = new StartAppCommand();
            DeleteFileCommand commandFive = new DeleteFileCommand();
            UploadFileCommand commandSix = new UploadFileCommand();
            ChangeDirCommand commandSeven = new ChangeDirCommand();
            DownloadFileCommand commandEight = new DownloadFileCommand();
            List<ICommand> container = new List<ICommand>();
            container.Add(commandOne);
            container.Add(commandTwo);
            container.Add(commandThree);
            container.Add(commandFour);
            container.Add(commandFive);
            container.Add(commandSix);
            container.Add(commandSeven);
            container.Add(commandEight);
            foreach (var value in container)
            {
                bool finders = false;
                foreach (var value2 in _macroCommand._commands)
                {
                    if (value2.GetType() == value.GetType())
                    {
                        finders = true;
                    }
                }
                Assert.True(finders);
            }
        }
        MacroCommand _macroCommand;
    }

}