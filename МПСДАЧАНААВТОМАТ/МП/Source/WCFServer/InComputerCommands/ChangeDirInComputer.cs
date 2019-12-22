using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class ChangeDirInComputer
    {
        public ChangeDirInComputer(string FirstParametr)
        {
            _FirstParametr = FirstParametr;
            _IsSuccesed = true;
            if (_FirstParametr == "")
            {
                 new ExceptionCommand("Введите директорию",ref _Error, ref _IsSuccesed);
                return;
            }
            else
            {
                if (!Directory.Exists(_FirstParametr))
                {
                     new ExceptionCommand("Нет такой директории", ref _Error, ref _FirstParametr, ref _IsSuccesed);
                    return;
                }
                else
                {
                    Directory.SetCurrentDirectory(_FirstParametr);
                    string NewDirectory = Directory.GetCurrentDirectory();
                    _Result = new string[1];
                    _Result[0] = NewDirectory;
                    _Result[0] += " - это новая директория";
                }
            }
        }
        public string[] _Result;
        public bool _IsSuccesed;
        public string _Error;
        public string _FirstParametr;
    }
}
