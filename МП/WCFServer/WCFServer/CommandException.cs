using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class CommandException : Exception
    {
        public int value { get; }
        public CommandException(string message, string _Error, bool _IsSuccesed)
         : base(message)
        {
            _Error = message;
            _IsSuccesed = false;
        }
        public CommandException(string message, string _Error, string FirstParametr, bool _IsSuccesed)
    : base(message)
        {
            _Error = message + FirstParametr;
            _IsSuccesed = false;
        }
    }
}
