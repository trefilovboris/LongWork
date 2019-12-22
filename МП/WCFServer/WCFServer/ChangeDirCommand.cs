using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;


namespace WCFServer
{
    public class ChangeDirCommand : ICommand
    {
        public ChangeDirCommand() { }
        public CommandResult Execute(CommandResult CommandExecutor)
        {
            _CommandExecutor = CommandExecutor;
            var ChangeDir = new ChangeDirInComputer(_CommandExecutor.FirstParametr);
            _CommandExecutor.Result = ChangeDir._Result;
            _CommandExecutor.IsSuccesed = ChangeDir._IsSuccesed;
            _CommandExecutor.Error = ChangeDir._Error;
            return _CommandExecutor;
        }
        public CommandResult _CommandExecutor;
    }

    public class ChangeDirInComputer
    {
        public ChangeDirInComputer(string FirstParametr)
        {
            _FirstParametr = FirstParametr;
           _IsSuccesed = true;
            if (_FirstParametr == "")
            {
                throw new CommandException("Введите директорию", _Error, _IsSuccesed);
            }
            else
            {
                if (!Directory.Exists(_FirstParametr))
                {
                    throw new CommandException("Нет такой директории, как ", _Error, _FirstParametr, _IsSuccesed);
                }
                else
                {
                    Directory.SetCurrentDirectory(_FirstParametr);
                    string NewDirectory = Directory.GetCurrentDirectory();
                    _Result = new string[1];
                    _Result[0] = NewDirectory;
                    _Result[0] += " - это новая директория";
                }
            }
        }
        public string[] _Result { get; set; }
        public bool _IsSuccesed { get; set; }
        public string _Error { get; set; }
        public string _FirstParametr { get; set; }
    }
      
}

