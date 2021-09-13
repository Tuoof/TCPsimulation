﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Linq;

namespace TCPsim_server
{
    class TCPSim_server
    {
        static TcpListener Listener;
        static Socket tcpSocket;

        static Int32 port = 5000;
        static IPAddress localAddress = IPAddress.Parse("127.0.0.1");

        public void Start()
        {
            Listener = new TcpListener(localAddress, port);
            Listener.Start();
            Console.WriteLine("Server listening on " + Listener.LocalEndpoint);

            tcpSocket = Listener.AcceptSocket();
            Console.WriteLine("Client Accepted...!");
            
            byte[] receivedBytes = new byte[1500];

            try
            {
                while (true)
                {
                    int receivedSize = tcpSocket.Receive(receivedBytes);

                    for (int i = 0; i < receivedSize; i++)
                    {
                        // Print each character to the console window
                        Console.Write(Convert.ToChar(receivedBytes[i]));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        /*public void writeMessage(string chat)
        {
            messages.Add(chat);
            File.WriteAllLines("C:/Users/andik/Documents/Tugas/Jaringan/chat.txt", messages);
        }*/
    }
}