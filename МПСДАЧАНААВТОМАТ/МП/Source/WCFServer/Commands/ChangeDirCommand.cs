using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;


namespace WCFServer
{
    public class ChangeDirCommand : ICommand
    {
        public ChangeDirCommand() { }
        public CommandResult Execute(CommandResult CommandExecutor)
        {
            _CommandExecutor = CommandExecutor;
            var ChangeDir = new ChangeDirInComputer(_CommandExecutor.FirstParametr);
            _CommandExecutor.Result = ChangeDir._Result;
            _CommandExecutor.IsSuccesed = ChangeDir._IsSuccesed;
            _CommandExecutor.Error = ChangeDir._Error;
            return _CommandExecutor;
        }
        public CommandResult _CommandExecutor;
    }

    
      
}

