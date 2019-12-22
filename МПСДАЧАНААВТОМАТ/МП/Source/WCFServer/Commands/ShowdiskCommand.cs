using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class ShowdiskCommand : ICommand
    {
        public ShowdiskCommand()
        {
        }
        public CommandResult Execute(CommandResult CommandExecutor)
        {
            _CommandExecutor = CommandExecutor;
            var ShowDisk = new ShowdiskInComputer();
            _CommandExecutor.Result = ShowDisk._Result;
            _CommandExecutor.IsSuccesed = ShowDisk._IsSuccesed;
            _CommandExecutor.Error = ShowDisk._Error;
            return _CommandExecutor;
        }
        public CommandResult _CommandExecutor;
    }

    
}
