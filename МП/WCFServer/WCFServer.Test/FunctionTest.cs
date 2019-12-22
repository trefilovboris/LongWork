using NUnit.Framework;
using WCFServer;
using Client.ServiceReference1;
using System.IO;
using Client;
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

            string Parametrs = "Test.txt";
            string Test = "Тестовая строка";
            byte[] mass = Encoding.Default.GetBytes(Test);

            _downloadFile.function(Parametrs, mass);

            string[] lines = System.IO.File.ReadAllLines(Parametrs);
            Assert.IsTrue(File.Exists("Test.txt"));
            Assert.AreEqual("Тестовая строка", lines[0]);
        }

        [Test]
        public void Test2()
        {
            string Parametrs = "Test.txt";
            byte[] mass = { };
            string result = _downloadFile.function(Parametrs, mass);
            Assert.IsFalse(File.Exists("Test2.txt"));
        }
        [Test]
        public void Test3()
        {
            string Parametrs = "Test1.txt";
            if (File.Exists("Test1.txt"))
            {
                File.Delete("Test1.txt");
            }
            byte[] mass = { };
            string result = _downloadFile.function(Parametrs, mass);
            Assert.IsTrue(File.Exists("Test1.txt"));
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
            string Parametrs = "cmd1.exe";
            byte[] mass = { };
            string result = _startAppCommand.function(Parametrs, mass);
            Process[] processList = Process.GetProcessesByName("cmd1");
            Assert.False(processList.Length > 0);
        }
        [Test]
        public void Test2()
        {
            string Parametrs = "cmd.exe";
            byte[] mass = { };
            string result = _startAppCommand.function(Parametrs, mass);
            Process[] processList = Process.GetProcessesByName("cmd");
            Assert.True(processList.Length > 0);
        }
        [Test]
        public void Test3()
        {
            string Parametrs = "cmd.exe /k java -v";
            byte[] mass = { };
            string result = _startAppCommand.function(Parametrs, mass);
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
            string Parametrs = "Test.txt";
            byte[] mass = { };
            string result = _uploadFileCommand.function(Parametrs, mass);
            Assert.AreEqual("Тестовая строка", result);
        }
        [Test]
        public void Test2()
        {
            string Parametrs = "Test2.txt";
            byte[] mass = { };
            string result = _uploadFileCommand.function(Parametrs, mass);
            Assert.AreEqual("Ошибка открытия!\n", result);
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
            string Parametrs = "Test.txt";
            string f = AppDomain.CurrentDomain.BaseDirectory;
            f += Parametrs;
            byte[] mass = { };
            string result = _showdirCommand.function(f, mass);
            Assert.AreEqual("Это файл!\n", result);
        }
        [Test]
        public void Test2()
        {
            string Parametrs = "gdfgt.txt";
            string f = AppDomain.CurrentDomain.BaseDirectory;
            f += Parametrs;
            byte[] mass = { };
            string result = _showdirCommand.function(f, mass);
            Assert.AreEqual("Нет такого пути!\n", result);
        }
        [Test]
        public void Test3()
        {
            string Parametrs = "Directory\\";
            string f = AppDomain.CurrentDomain.BaseDirectory;
            f += Parametrs;
            byte[] mass = { };
            string result = _showdirCommand.function(f, mass);
            Assert.AreEqual("Директории: \nDir\nDir 2\nФайлы: \nTestDir.txt\nTestDir2.txt\n", result);
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
            string Parametrs = "";
            byte[] mass = { };
            string result = _showdiskCommand.function(Parametrs, mass);
            string[] Drives = Environment.GetLogicalDrives();
            string s = "Диски: \n";
            foreach (string item in Drives)
            {
                s += item;
                s += "\n";
            }
            Assert.AreEqual(s, result);
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
            string Parametrs = "";
            byte[] mass = { };
            string result = _directoryCommand.function(Parametrs, mass);
            string s = "";
            s = "Текущая директория: \n";
            s += AppDomain.CurrentDomain.BaseDirectory;
            s += "\n";
            Assert.AreEqual(s, result);
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
            string Parametrs = "Delete.txt";
            byte[] mass = { };
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Parametrs);
            File.WriteAllBytes(path, mass);
            Assert.True(File.Exists("Delete.txt"));
            string result = _deleteFileCommand.function(Parametrs, mass);
            Assert.True(!File.Exists("Delete.txt"));
        }
        [Test]
        public void Test2()
        {
            string Parametrs = "NoDelete.txt";
            byte[] mass = { };
            string result = _deleteFileCommand.function(Parametrs, mass);
            Assert.AreEqual("Нет такого файла!\n", result);
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
            string Parametrs = AppDomain.CurrentDomain.BaseDirectory;
            string Reverse = Parametrs;
            Parametrs += "Directory";
            byte[] mass = { };
            Directory.SetCurrentDirectory(Reverse);
            string s = Parametrs + " это новая директория\n";
            string result = _changeDirCommand.function(Parametrs, mass);
            Directory.SetCurrentDirectory(Reverse);
            Assert.AreEqual(s, result);
        }
        [Test]
        public void Test2()
        {
            string Parametrs = "NoDirectory";
            byte[] mass = { };
            string result = _changeDirCommand.function(Parametrs, mass);
            Assert.AreEqual("Ошибка директории\n", result);
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
            List<IToDo> container = new List<IToDo>();
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