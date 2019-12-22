using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using Client.ServiceReference1;
using System.IO;
using System.Diagnostics;
namespace Client
{
    class FunctionsClient
    {
        public int WriteBytes(string message, byte[] data)
        {
            String[] words = message.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
            string path = Path.Combine(words[0],words[1]);
            try
            { File.WriteAllBytes(path, data); }
            catch (System.UnauthorizedAccessException)
            {
                throw new System.UnauthorizedAccessException();
            }
            return 0;
        }

        public byte[] ReadBites(string message)
        {
            byte[] data = { };
            string path = Path.Combine(Directory.GetCurrentDirectory(), message);
            if (!File.Exists(path))
            {
                return data;
            }
            try { data = File.ReadAllBytes(path); }
            catch (System.UnauthorizedAccessException)
            {
               throw new System.UnauthorizedAccessException();
            }
            return data;
        }
        public string WriteFile(string parametrs, byte[] data)
        {
            string message = "";
            string s = "";
            String[] words = parametrs.Split(new char[] { '*' }, StringSplitOptions.RemoveEmptyEntries);
            if (!Directory.Exists(words[0]))
            {
                message = "Нет директории, в которую нужно загрузить файл!\n";
            }
            else
            {
                try
                {
                    new FunctionsClient().WriteBytes(parametrs, data);
                    message = "Файл записан!\n";
                }
                catch (System.UnauthorizedAccessException)
                {
                    message = "Нет прав!\n";
                }
            }
            s = message;
            return s;
        }


    }
}

