using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class DeleteFileCommand : ICommand
    {
        public DeleteFileCommand() { }
        public CommandResult Execute(CommandResult CommandExecutor)
        {
            _CommandExecutor = CommandExecutor;
            var DeleteFile = new DeleteFileInComputer(_CommandExecutor.FirstParametr);
            _CommandExecutor.Result = DeleteFile._Result;
            _CommandExecutor.IsSuccesed = DeleteFile._IsSuccesed;
            _CommandExecutor.Error = DeleteFile._Error;
            return _CommandExecutor;
        }
        public CommandResult _CommandExecutor;
    }

    public class DeleteFileInComputer
    {
        public DeleteFileInComputer(string FirstParametr)
        {
            _FirstParametr = FirstParametr;
            string path = Path.Combine(_FirstParametr);
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), _FirstParametr);
            _IsSuccesed = true;
            _Result = new string[1];
            if (_FirstParametr == "")
            {
                throw new CommandException("Введите какой файл хотите удалить", _Error, _IsSuccesed);
            }
            else
            {
                if (!File.Exists(path) && !File.Exists(fullPath))
                {
                    throw new CommandException("Нет файла с именем: ", _Error, _FirstParametr, _IsSuccesed);
                }
                else
                {
                    if (!File.Exists(path))
                    {
                        path = fullPath;
                    }
                    try
                    {
                        File.Delete(path);
                        _Result[0] = _FirstParametr + " было удалено";
                    }
                    catch (System.UnauthorizedAccessException)
                    {
                        throw new CommandException("Нет прав к файлу с именем: ", _Error, _FirstParametr, _IsSuccesed);
                    }
                }
            }
        }
        public string[] _Result { get; set; }
        public bool _IsSuccesed { get; set; }
        public string _Error { get; set; }
        public string _FirstParametr { get; set; }
    }
}
