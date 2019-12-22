using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class ReadBites
    {
        public ReadBites(string FirstParametr)
        {
            _FirstParametr = FirstParametr;
            _IsSuccesed = true;
            string path = Path.Combine(Directory.GetCurrentDirectory(), _FirstParametr);
            if (_FirstParametr == "")
            {
                 new ExceptionCommand("Введите имя файла: ",ref _Error, ref _IsSuccesed);
                return;
            }
            else
            {
                if (!File.Exists(path))
                {
                     new ExceptionCommand("Нет файла с именем: ", ref _Error, ref _FirstParametr, ref _IsSuccesed);
                    return;
                }
                else
                {
                    try
                    {

                        _Data = File.ReadAllBytes(path);
                        NameFile nameFileClass = new NameFile(path);
                        _FirstParametr = nameFileClass._FullNameFile;
                    }
                    catch (System.UnauthorizedAccessException)
                    {
                         new ExceptionCommand("Нет доступа к файлу с именем: ", ref _Error, ref _FirstParametr, ref _IsSuccesed);
                        return;
                    }
                }
            }
        }
        public string[] _Result;
        public bool _IsSuccesed;
        public string _Error;
        public string _FirstParametr;
        public byte[] _Data;
    }

}
