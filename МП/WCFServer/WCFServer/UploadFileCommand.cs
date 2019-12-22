using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace WCFServer
{
    public class UploadFileCommand : ICommand
    {
        public UploadFileCommand() { }
        public CommandResult Execute(CommandResult CommandExecutor)
        {
            _CommandExecutor = CommandExecutor;
            if (_CommandExecutor.IsSuccesed != false)
            {
                var UploadFile = new UploadFileInComputer(_CommandExecutor.SecondParametr, _CommandExecutor.Data, _CommandExecutor.FirstParametr);
                _CommandExecutor.Result = UploadFile._Result;
                _CommandExecutor.IsSuccesed = UploadFile._IsSuccesed;
                _CommandExecutor.Error = UploadFile._Error;
            }
            return _CommandExecutor;
        }
        public CommandResult _CommandExecutor;
    }




    public class ReadBites
    {
        public ReadBites(string FirstParametr)
        {
            _FirstParametr = FirstParametr;
            _IsSuccesed = true;
            string path = Path.Combine(Directory.GetCurrentDirectory(), _FirstParametr);
            if (_FirstParametr == "")
            {
                throw new CommandException("Введите имя файла: ", _Error, _IsSuccesed);
            }
            else
            {
                if (!File.Exists(path))
                {
                    throw new CommandException("Нет файла с именем: ", _Error, _FirstParametr, _IsSuccesed);
                }
                else
                {
                    try
                    {

                        _Data = File.ReadAllBytes(path);
                        NameFile nameFileClass = new NameFile(path);
                        _FirstParametr = nameFileClass._FullNameFile;
                    }
                    catch (System.UnauthorizedAccessException)
                    {
                        throw new CommandException("Нет доступа к файлу с именем: ", _Error, _FirstParametr, _IsSuccesed);
                    }
                }
            }
        }
        public string[] _Result { get; set; }
        public bool _IsSuccesed { get; set; }
        public string _Error { get; set; }
        public string _FirstParametr { get; set; }
        public byte[] _Data { get; set; }
    }




    public class UploadFileInComputer
    {
        public UploadFileInComputer(string SecondParametr, byte[] Data, string Filename)
        {
            _SecondParametr = SecondParametr;
            _IsSuccesed = true;
            string path = Path.Combine(_SecondParametr);
            string newpath = Path.Combine(Directory.GetCurrentDirectory(), _SecondParametr);
            if (!Directory.Exists(path) && !Directory.Exists(newpath))
            {
                throw new CommandException("Нет такой директории с названием: ", _Error, _SecondParametr, _IsSuccesed);
            }
            else
            {
                if (!Directory.Exists(path))
                {
                    path = newpath;
                }

                try
                {
                    path = Path.Combine(path, Filename);
                    File.WriteAllBytes(path, Data);
                    _Result = new string[1];
                    _Result[0] = "Файл записан в директорию с именем: ";
                    _Result[0] += Filename;
                }
                catch (System.UnauthorizedAccessException)
                {
                    throw new CommandException("Нет прав записи с названием: ", _Error, _SecondParametr, _IsSuccesed);
                }
            }
        }
        public string[] _Result { get; set; }
        public bool _IsSuccesed { get; set; }
        public string _Error { get; set; }
        public string _SecondParametr { get; set; }
    }

    public class NameFile
    {
        public NameFile(string FullNameFile)
        {

            int i = FullNameFile.Length - 1;
            while (i != -1 && (FullNameFile[i] != '\\' && FullNameFile[i] != '/'))
            {
                _FullNameFile = FullNameFile[i] + _FullNameFile;
                --i;
            }
        }
        public string _FullNameFile { get; set; }
    }




}

