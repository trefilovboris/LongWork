using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class CommandResult
    {
        public bool IsSuccesed;
        public string Error;
        public string[] Result;
        public int CodeCommand;
        public string FirstParametr;
        public string SecondParametr;
        public byte[] Data;
    }
}
