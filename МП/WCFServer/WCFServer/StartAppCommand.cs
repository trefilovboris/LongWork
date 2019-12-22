using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class StartAppCommand : ICommand
    {
        public StartAppCommand()
        {
        }
        public CommandResult Execute(CommandResult CommandExecutor)
        {
            _CommandExecutor = CommandExecutor;
            var StartApp = new StartAppInComputer(_CommandExecutor.FirstParametr, _CommandExecutor.SecondParametr);
            _CommandExecutor.Result = StartApp._Result;
            _CommandExecutor.IsSuccesed = StartApp._IsSuccesed;
            _CommandExecutor.Error = StartApp._Error;
            _CommandExecutor.FirstParametr = StartApp._FirstParametr;
            _CommandExecutor.SecondParametr = StartApp._SecondParametr;
            return _CommandExecutor;
        }
        public CommandResult _CommandExecutor;
    }

    public class StartAppInComputer
    {
        public StartAppInComputer(string FirstParametr, string SecondParametr)
        {
          
                _FirstParametr = FirstParametr;
                _SecondParametr = SecondParametr;
                _IsSuccesed = true;
                _Result = new string[1];
            if (_FirstParametr == "")
            {
                throw new CommandException("Введите имя приложения", _Error, _IsSuccesed);
            }
            else
                {
                    Process iStartProcess = new Process();
                    iStartProcess.StartInfo.FileName = _FirstParametr;
                    if (_SecondParametr != "")
                    {
                        iStartProcess.StartInfo.Arguments = _SecondParametr;
                    }
                    try
                    {
                        iStartProcess.Start();
                        _Result[0] = "Приложение запущено\n";
                    }
                catch (System.ComponentModel.Win32Exception)
                {
                    throw new CommandException("Ошибка запуска", _Error, _IsSuccesed);
                }
                catch (System.UnauthorizedAccessException)
                {
                    throw new CommandException("Нет доступа к файлу с именем:", _Error, _FirstParametr, _IsSuccesed);
                }
            }
            }
        
        public string _FirstParametr { get; set; }
        public string _SecondParametr { get; set; }
        public string[] _Result { get; set; }
        public bool _IsSuccesed { get; set; }
        public string _Error { get; set; }
    }
}
