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

    
}
