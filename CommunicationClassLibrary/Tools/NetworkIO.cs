using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using CommunicationClassLibrary.Entities;
using Newtonsoft.Json;

namespace CommunicationClassLibrary.Tools
{
    class NetworkIO
    {
        public static int ConnectionPort { get; } = 12345;
        public static IPAddress ConnectionAddress { get; } =  IPAddress.Parse("127.0.0.1");

        public static string RecieveString(TcpClient tcpClient)
        {
            byte[] data = new byte[1024];
            StringBuilder message = new StringBuilder();

            NetworkStream stream = tcpClient.GetStream();

            do
            {
                int bytes = stream.Read(data, 0, data.Length);
                string part = Encoding.Unicode.GetString(data, 0, bytes);

                message.Append(part);
            }
            while (stream.DataAvailable); 

            //stream.Close();
            //stream.Flush();

            return message.ToString();
        }

        public static void SendString(TcpClient tcpClient, string message)
        {
            NetworkStream stream = tcpClient.GetStream();
            
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);

            //stream.Flush();
            //stream.Close();
        }

    }
}
