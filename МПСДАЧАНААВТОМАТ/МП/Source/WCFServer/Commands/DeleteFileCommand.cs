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

    
}
