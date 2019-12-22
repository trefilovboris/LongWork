using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class DeleteFileInComputer
    {
        public DeleteFileInComputer(string FirstParametr)
        {
            _FirstParametr = FirstParametr;
            string path = Path.Combine(_FirstParametr);
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), _FirstParametr);
            _IsSuccesed = true;
            _Result = new string[1];
            if (_FirstParametr == "")
            {
                 new ExceptionCommand("Введите какой файл хотите удалить", ref _Error, ref _IsSuccesed);
                   return;
            }
            else
            {
                if (!File.Exists(path) && !File.Exists(fullPath))
                {
                    new ExceptionCommand("Нет файла с именем: ", ref _Error, ref _FirstParametr, ref _IsSuccesed);
                    return;
                }
                else
                {
                    if (!File.Exists(path))
                    {
                        path = fullPath;
                    }
                    try
                    {
                        File.Delete(path);
                        _Result[0] = _FirstParametr + " было удалено";
                    }
                    catch (System.UnauthorizedAccessException)
                    {
                        new ExceptionCommand("Нет прав к файлу с именем: ", ref _Error, ref _FirstParametr, ref _IsSuccesed);
                        return;
                    }
                }
            }
        }
        public string[] _Result;
        public bool _IsSuccesed;
        public string _Error;
        public string _FirstParametr;
    }
}
