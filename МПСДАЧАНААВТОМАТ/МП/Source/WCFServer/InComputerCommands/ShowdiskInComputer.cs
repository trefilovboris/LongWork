using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
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
                 new ExceptionCommand("Не найдены диски", ref _Error, ref _IsSuccesed);
                return;
            }
        }
        public string[] _Result;
        public bool _IsSuccesed;
        public string _Error;
    }
}
