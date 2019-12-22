using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFServer
{
    public enum NumberCommands
    {
        Showdir = 0,
        Showdisk,
        Directory,
        Startapp,
        Delete,
        Changedir,
        Upload,
        Download
    }
}
