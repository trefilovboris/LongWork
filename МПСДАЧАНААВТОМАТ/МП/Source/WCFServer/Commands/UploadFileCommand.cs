using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace WCFServer
{
    public class UploadFileCommand : ICommand
    {
        public UploadFileCommand() { }
        public CommandResult Execute(CommandResult CommandExecutor)
        {
            _CommandExecutor = CommandExecutor;
            if (_CommandExecutor.IsSuccesed != false)
            {
                var UploadFile = new UploadFileInComputer(_CommandExecutor.SecondParametr, _CommandExecutor.Data, _CommandExecutor.FirstParametr);
                _CommandExecutor.Result = UploadFile._Result;
                _CommandExecutor.IsSuccesed = UploadFile._IsSuccesed;
                _CommandExecutor.Error = UploadFile._Error;
            }
            return _CommandExecutor;
        }
        public CommandResult _CommandExecutor;
    }
}

