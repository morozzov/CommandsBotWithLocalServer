using System;
using System.Threading;
using System.Threading.Tasks;
using CommunicationClassLibrary;
using CommunicationClassLibrary.Entities;

namespace Server
{
    class Program
    {

        static void Main(string[] args)
        {
            Random rnd = new Random();

            ServerManager server = new ServerManager();
            Msg msg = null;

            server.Start();
            server.AcceptClient();

            bool isActive = true;

            while (isActive)
            {
                msg = server.RecieveMsgFromClient();

                switch (msg.Message)
                {
                    case "help":
                        msg = new Msg
                        {
                            Message = "time, date, random, exit"
                        };
                        break;

                    case "time":
                        msg = new Msg
                        {
                            Message = DateTime.Now.ToString("HH:mm:ss")
                        };
                        break;

                    case "date":
                        msg = new Msg
                        {
                            Message = DateTime.Now.Date.ToString("dd MMMM yyyy - dddd")
                        };
                        break;

                    case "random":
                        msg = new Msg
                        {
                            Message = rnd.Next(2).ToString()
                        };
                        break;

                    case "exit":
                        isActive = false;
                        break;

                    default:
                        msg = new Msg
                        {
                            Message = "Введите существующую команду..."
                        };
                        break;
                }
                if (isActive)
                {
                    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
                    CancellationToken token = cancellationTokenSource.Token;

                    Task task = Task.Run(() =>
                    {
                        //int n = rnd.Next(100, 301);
                        int n = 2;

                        for (int i = 1; i < n; i++)
                        {
                            if (token.IsCancellationRequested)
                            {
                                msg = new Msg
                                {
                                    Message = "TIME OUT"
                                };
                                server.SendMsgToClient(msg);

                                return;
                            }

                            Thread.Sleep(10);
                        }

                        server.SendMsgToClient(msg);
                    });

                    Task task1 = Task.Run(() =>
                    {
                        Thread.Sleep(2900);

                        if (task.Status == TaskStatus.Running)
                        {
                            cancellationTokenSource.Cancel();
                        }
                    });
                }
            }
            Console.WriteLine("Клиент покинул сервер.");
            Console.WriteLine("Нажмите на клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
