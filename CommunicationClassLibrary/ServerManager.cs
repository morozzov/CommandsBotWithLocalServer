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
    public class ServerManager
    {
        private TcpListener tcpListener;
        private TcpClient tcpClient;

        public ServerManager()
        {
            tcpListener = new TcpListener(NetworkIO.ConnectionAddress, NetworkIO.ConnectionPort);
        }

        public void Start()
        {
            tcpListener.Start();
            LogHelper.Log($"SERVER STARTED AT {tcpListener.LocalEndpoint}");
        }

        public void AcceptClient()
        {
            tcpClient = tcpListener.AcceptTcpClient();
            LogHelper.Log($"CLIENT CONNECTED FROM {tcpClient.Client.RemoteEndPoint}");
        }

        public void Stop()
        {
            tcpListener.Stop();
        }

        public void SendMsgToClient(Msg response)
        {
            string responseInString = JsonConvert.SerializeObject(response);

            LogHelper.Log($"SEND MSG TO CLIENT {tcpClient.Client.RemoteEndPoint} DATA: {responseInString}");

            NetworkIO.SendString(tcpClient, responseInString);
        }

        public Msg RecieveMsgFromClient()
        {
            string requestInString = NetworkIO.RecieveString(tcpClient);

            LogHelper.Log($"RECIEVE MSG FROM CLIENT {tcpClient.Client.RemoteEndPoint} DATA: {requestInString}");

            return JsonConvert.DeserializeObject<Msg>(requestInString);
        }
    }
}
