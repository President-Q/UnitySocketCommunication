// A C# Program for Server 
using System;
using System.IO;
using System.Collections;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

class Server : MonoBehaviour
{
    Thread thrd;
    TcpListener listener;
    private void Start()
    {
        StartServer();

    }
    public void StartServer()
    {
        IPAddress[] addrs = Dns.GetHostEntry("localhost").AddressList;
        foreach (IPAddress addr in addrs)
            print(addr);
        listener = new TcpListener(addrs[1], 8532);
        listener.Start();
        thrd = new Thread(Reciver);
        thrd.Start();

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            thrd.Abort();
    }
    public void Reciver()
    {
        while (true)
        {
            Socket soc = listener.AcceptSocket();
            //soc.SetSocketOption(SocketOptionLevel.Socket,
            //        SocketOptionName.ReceiveTimeout,10000);
            print("Connected:" + soc.RemoteEndPoint);
            Stream s = new NetworkStream(soc);
            StreamReader sr = new StreamReader(s);
            StreamWriter sw = new StreamWriter(s);
            sw.AutoFlush = true; // enable automatic flushing
            sw.WriteLine("Helllo from sever");
            print(sr.ReadLine());
        }
    }
}