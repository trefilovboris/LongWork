using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public class StartAppInComputer
    {
        public StartAppInComputer(string FirstParametr, string SecondParametr)
        {

            _FirstParametr = FirstParametr;
            _SecondParametr = SecondParametr;
            _IsSuccesed = true;
            _Result = new string[1];
            if (_FirstParametr == "")
            {
                 new ExceptionCommand("Введите имя приложения", ref _Error, ref _IsSuccesed);
                return;
            }
            else
            {
                Process iStartProcess = new Process();
                iStartProcess.StartInfo.FileName = _FirstParametr;
                if (_SecondParametr != "")
                {
                    iStartProcess.StartInfo.Arguments = _SecondParametr;
                }
                try
                {
                    iStartProcess.Start();
                    _Result[0] = "Приложение запущено\n";
                }
                catch (System.ComponentModel.Win32Exception)
                {
                     new ExceptionCommand("Ошибка запуска", ref _Error, ref _IsSuccesed);
                    return;
                }
                catch (System.UnauthorizedAccessException)
                {
                     new ExceptionCommand("Нет доступа к файлу с именем:", ref _Error, ref _FirstParametr, ref _IsSuccesed);
                    return;
                }
            }
        }

        public string _FirstParametr;
        public string _SecondParametr;
        public string[] _Result;
        public bool _IsSuccesed;
        public string _Error;
    }
}
