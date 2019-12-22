using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using WCFServer;
namespace ServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(WCFServer.MacroCommand)))
            {
                host.Open();
                Console.WriteLine("Включен хост");
                Console.ReadLine();
                
            }
        }
    }
}
