using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class ShowDirInComputer
    {
        public ShowDirInComputer(string FirstParametr)
        {
            _FirstParametr = FirstParametr;
            _IsSuccesed = false;
            if (_FirstParametr == "")
            {
                new ExceptionCommand("Введите название директории", ref _Error, ref _IsSuccesed);
                return;
            }
            else
            {
                if (Directory.Exists(FirstParametr))
                {
                    _IsSuccesed = true;
                    DirectoryInfo dir = new DirectoryInfo(_FirstParametr);
                    _Result = new string[1];
                    _Result[0] = "Директории: ";
                    foreach (var item in dir.GetDirectories())
                    {
                        string[] Result = new string[1];
                        Result[0] = item.Name;
                        _Result = _Result.Concat(Result).ToArray();
                    }
                    string[] Files = new string[1];
                    Files[0] = "Файлы: ";
                    _Result = _Result.Concat(Files).ToArray();
                    foreach (var item in dir.GetFiles())
                    {
                        string[] Result = new string[1];
                        Result[0] = item.Name;
                        _Result = _Result.Concat(Result).ToArray();
                    }
                    return;
                }
                if (File.Exists(_FirstParametr))
                {
                     new ExceptionCommand("Это файл", ref _Error, ref _IsSuccesed);
                    return;

                }
                 new ExceptionCommand("Нет такой директории", ref _Error, ref _IsSuccesed);
                return;
            }
        }
        public string _FirstParametr;
        public string[] _Result;
        public bool _IsSuccesed;
        public string _Error;
    }
}
