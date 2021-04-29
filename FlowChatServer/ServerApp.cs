﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlowChatServer
{
    public class ServerApp
    {
        private TcpListener listener;
        private const int SERVER_PORT = 6690;
        private bool isExit;
        private List<ServerAppClient> currentConnectedClients;

        public ServerApp()
        {
            isExit = false;
            listener = new TcpListener(IPAddress.Any, SERVER_PORT);
            currentConnectedClients = new List<ServerAppClient>();
        }

        public void Run()
        {
            listener.Start();

            Console.WriteLine("FlowChat Server v1.0");

            while (!isExit)
            {
                var tcpClient = listener.AcceptTcpClient();

                Console.WriteLine("Client " + tcpClient.Client.RemoteEndPoint.ToString() + " connected!");

                ServerAppClient serverAppClient = new ServerAppClient(tcpClient);
                serverAppClient.Exited += () =>
                {
                    Console.WriteLine("Client " + serverAppClient.TcpClient.Client.RemoteEndPoint.ToString() + " connected!");
                    currentConnectedClients.Remove(serverAppClient);
                };
                currentConnectedClients.Add(serverAppClient);
            }

            listener.Stop();

            Console.WriteLine("Server Shutdown. Bye-bye!");
        }
    }
}
