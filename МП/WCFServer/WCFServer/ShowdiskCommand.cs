using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    class RemoteCodeExecutor : Exception
    {
        public RemoteCodeExecutor(string message)
            : base(message)
        { }

        public RemoteCodeExecutor(string message, Exception innerException)
            : base(message, innerException)
        { }
    }

    public class CommandResult
    {
        public bool IsSuccesed { get; set; }
        public string Error { get; set; }
        public string[] Result { get; set; }
        public int CodeCommand { get; set; }
        public string FirstParametr { get; set; }
        public string SecondParametr { get; set; }
        public byte[] Data { get; set; }
    }
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

    public class ShowdiskInComputer
    {
        public ShowdiskInComputer()
        {
            string[] ShowDisk = Environment.GetLogicalDrives();
            string[] Drives = new string[1];
            Drives[0] = "Диски:";
            Drives = Drives.Concat(ShowDisk).ToArray();
            _IsSuccesed = true;
            _Result = Drives;
            if (Drives[1] == null || Drives[1] == "")
            {
                throw new CommandException("Не найдены диски", _Error, _IsSuccesed);
            }
        }
        public string[] _Result { get; set; }
        public bool _IsSuccesed { get; set; }
        public string _Error { get; set; }
    }
}
