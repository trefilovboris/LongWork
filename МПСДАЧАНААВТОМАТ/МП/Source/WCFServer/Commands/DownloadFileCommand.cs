using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class DownloadFileCommand : ICommand
    {
        public DownloadFileCommand() { }
        public CommandResult Execute(CommandResult CommandExecutor)
        {
                _CommandExecutor = CommandExecutor;
                var DownloadFile = new ReadBites(_CommandExecutor.FirstParametr);
                _CommandExecutor.FirstParametr = DownloadFile._FirstParametr;
                _CommandExecutor.Result = DownloadFile._Result;
                _CommandExecutor.IsSuccesed = DownloadFile._IsSuccesed;
                _CommandExecutor.Error = DownloadFile._Error;
                _CommandExecutor.Data = DownloadFile._Data;
            
            return _CommandExecutor;
        }
        public CommandResult _CommandExecutor;
    }
}
