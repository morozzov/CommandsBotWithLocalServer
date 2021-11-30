using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationClassLibrary.Tools
{
    public class LogHelper
    {
        public static void Log(string msg)
        {
            Console.WriteLine($"{DateTime.Now}: {msg}");
        }
    }
}
