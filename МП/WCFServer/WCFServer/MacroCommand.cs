using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class MacroCommand : ICommand
    {

        public List<ICommand> _commands;
        public MacroCommand()
        {
            ShowdirCommand commandOne = new ShowdirCommand();
            ShowdiskCommand commandTwo = new ShowdiskCommand();
            DirectoryCommand commandThree = new DirectoryCommand();
            StartAppCommand commandFour = new StartAppCommand();
            DeleteFileCommand commandFive = new DeleteFileCommand();
            ChangeDirCommand commandSix = new ChangeDirCommand();
            UploadFileCommand commandSeven = new UploadFileCommand();
            DownloadFileCommand commandEight = new DownloadFileCommand();
            List<ICommand> Commands = new List<ICommand>();
            Commands.Add(commandOne);
            Commands.Add(commandTwo);
            Commands.Add(commandThree);
            Commands.Add(commandFour);
            Commands.Add(commandFive);
            Commands.Add(commandSix);
            Commands.Add(commandSeven);
            Commands.Add(commandEight);
            _commands = Commands;
        }
        public CommandResult Execute(CommandResult command)
        {
          return _commands[command.CodeCommand].Execute(command);
        }
    }
}
