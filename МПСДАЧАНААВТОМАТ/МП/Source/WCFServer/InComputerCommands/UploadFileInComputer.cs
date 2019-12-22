using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class UploadFileInComputer
    {
        public UploadFileInComputer(string SecondParametr, byte[] Data, string Filename)
        {
            _SecondParametr = SecondParametr;
            _IsSuccesed = true;
            string path = Path.Combine(_SecondParametr);
            string newpath = Path.Combine(Directory.GetCurrentDirectory(), _SecondParametr);
            if (!Directory.Exists(path) && !Directory.Exists(newpath))
            {
                 new ExceptionCommand("Нет такой директории с названием: ", ref _Error, ref _SecondParametr, ref _IsSuccesed);
                return;
            }
            else
            {
                if (!Directory.Exists(path))
                {
                    path = newpath;
                }

                try
                {
                    path = Path.Combine(path, Filename);
                    File.WriteAllBytes(path, Data);
                    _Result = new string[1];
                    _Result[0] = "Файл " + Filename;
                     _Result[0] += " записан в директорию";
                }
                catch (System.UnauthorizedAccessException)
                {
                     new ExceptionCommand("Нет прав записи с названием: ", ref _Error, ref _SecondParametr, ref _IsSuccesed);
                    return;
                }
            }
        }
        public string[] _Result;
        public bool _IsSuccesed;
        public string _Error;
        public string _SecondParametr;
    }
}
