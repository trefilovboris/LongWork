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

   

}
