using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class ShowdirCommand : ICommand
    {
        public ShowdirCommand()
        {
        }
        public CommandResult Execute(CommandResult CommandExecutor)
        {
            _CommandExecutor = CommandExecutor;
            var ShowDir = new ShowDirInComputer(_CommandExecutor.FirstParametr);
            _CommandExecutor.Result = ShowDir._Result;
            _CommandExecutor.IsSuccesed = ShowDir._IsSuccesed;
            _CommandExecutor.Error = ShowDir._Error;
            _CommandExecutor.FirstParametr = ShowDir._FirstParametr;
            return _CommandExecutor;
        }
        public CommandResult _CommandExecutor;
    }

    public class ShowDirInComputer
    {
        public ShowDirInComputer(string FirstParametr)
        {
            _FirstParametr = FirstParametr;
            _IsSuccesed = false;
            if (_FirstParametr == "")
            {
                throw new CommandException("Введите название директории", _Error, _IsSuccesed);
            }
            else
            {
                if (Directory.Exists(FirstParametr))
                {
                    _IsSuccesed = true;
                    DirectoryInfo dir = new DirectoryInfo(_FirstParametr);
                    _Result = new string[1];
                    _Result[0] = "Директории: ";
                    foreach (var item in dir.GetDirectories())
                    {
                        string[] Result = new string[1];
                        Result[0] = item.Name;
                        _Result = _Result.Concat(Result).ToArray();
                    }
                    string[] Files = new string[1];
                    Files[0] = "Файлы: ";
                    _Result = _Result.Concat(Files).ToArray();
                    foreach (var item in dir.GetFiles())
                    {
                        string[] Result = new string[1];
                        Result[0] = item.Name;
                        _Result = _Result.Concat(Result).ToArray();
                    }
                    return;
                }
                if (File.Exists(_FirstParametr))
                {
                    throw new CommandException("Это файл", _Error, _IsSuccesed);
                    
                }
                throw new CommandException("Нет такой директории", _Error, _IsSuccesed);
            }
        }
        public string _FirstParametr { get; set; }
        public string[] _Result { get; set; }
        public bool _IsSuccesed { get; set; }
        public string _Error { get; set; }
    }

}
