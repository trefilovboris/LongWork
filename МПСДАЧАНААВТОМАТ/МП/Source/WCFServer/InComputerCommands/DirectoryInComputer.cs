using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class DirectoryInComputer
    {
        public DirectoryInComputer()
        {
            _Result = new string[2];
            _Result[0] = "Текущая директория: ";
            _Result[1] = "";
            _Result[1] = AppDomain.CurrentDomain.BaseDirectory;
            _IsSuccesed = true;
            if (_Result[1] == "")
            {
                 new ExceptionCommand("Ошибка вывода директории", ref _Error, ref _IsSuccesed);
                return;
            }
        }
        public string[] _Result;
        public bool _IsSuccesed;
        public string _Error;
    }
}
