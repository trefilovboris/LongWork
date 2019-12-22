using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class ExceptionCommand 
    {
        public int value { get; }
        public ExceptionCommand( string message , ref string _Error, ref bool _IsSuccesed)
         
        {
            _Error = message;
            _IsSuccesed = false;
        }
        public ExceptionCommand( string message, ref string _Error, ref string FirstParametr, ref bool _IsSuccesed)
        {
            _Error = message + FirstParametr;
            _IsSuccesed = false;
        }
    }
}
