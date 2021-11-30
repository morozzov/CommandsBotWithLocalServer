using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using CommunicationClassLibrary.Entities;
using CommunicationClassLibrary.Tools;
using Newtonsoft.Json;

namespace CommunicationClassLibrary
{
    public class ClientManager
    {
        private TcpClient tcpClient;

        public ClientManager()
        {
            tcpClient = new TcpClient();
        }

        public void Connect()
        {
            tcpClient.Connect(NetworkIO.ConnectionAddress, NetworkIO.ConnectionPort);
        }

        public void SendMsgToServer(Msg request)
        {
            string requestInString = JsonConvert.SerializeObject(request);

            NetworkIO.SendString(tcpClient, requestInString);
        }

        public Msg RecieveMsgFromServer()
        {
            string responseInString = NetworkIO.RecieveString(tcpClient);

            //LogHelper.Log(responseInString);

            return JsonConvert.DeserializeObject<Msg>(responseInString);
        }

        public void Disconnect()
        {
            tcpClient.Close();
        }
    }
}
