using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class NameFile
    {
        public NameFile(string FullNameFile)
        {

            int i = FullNameFile.Length - 1;
            while (i != -1 && (FullNameFile[i] != '\\' && FullNameFile[i] != '/'))
            {
                _FullNameFile = FullNameFile[i] + _FullNameFile;
                --i;
            }
        }
        public string _FullNameFile;
    }

}
