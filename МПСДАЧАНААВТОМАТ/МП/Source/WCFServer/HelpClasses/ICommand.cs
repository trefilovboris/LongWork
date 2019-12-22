using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Windows.Forms;

namespace WCFServer
{
    [ServiceContract(CallbackContract = typeof(IServerCallback))]
    public interface ICommand
    {
        [OperationContract]
        CommandResult Execute(CommandResult command);
    }
}

