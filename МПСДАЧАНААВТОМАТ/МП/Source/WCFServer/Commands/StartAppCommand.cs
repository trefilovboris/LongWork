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

   
}
