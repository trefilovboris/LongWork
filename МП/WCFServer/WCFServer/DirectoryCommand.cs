using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class DirectoryCommand : ICommand
    {
        public DirectoryCommand()
        {
        }
        public CommandResult Execute(CommandResult CommandExecutor)
        {
            _CommandExecutor = CommandExecutor;
            var Directory = new DirectoryInComputer();
            _CommandExecutor.Result = Directory._Result;
            _CommandExecutor.IsSuccesed = Directory._IsSuccesed;
            _CommandExecutor.Error = Directory._Error;
            return _CommandExecutor;
        }
        public CommandResult _CommandExecutor;
    }

    public class DirectoryInComputer
    {
        public DirectoryInComputer()
        {
            _Result = new string[2];
            _Result[0] = "Текущая директория: ";
            _Result[1] = "";
            _Result[1] = AppDomain.CurrentDomain.BaseDirectory;
            _IsSuccesed = true;
            if (_Result[1] == "")
            {
                throw new CommandException("Ошибка вывода директории", _Error, _IsSuccesed);
            }
        }
        public string[] _Result { get; set; }
        public bool _IsSuccesed { get; set; }
        public string _Error { get; set; }
    }
}
