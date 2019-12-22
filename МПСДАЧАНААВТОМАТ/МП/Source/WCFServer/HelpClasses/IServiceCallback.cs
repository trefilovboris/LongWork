using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    [ServiceContract]
    public interface IServerCallback
    {
        [OperationContract(IsOneWay = true)]
        void Callback(string message, byte[] data, int codeCommand);
        
    }
}
