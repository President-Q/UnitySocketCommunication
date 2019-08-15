// A C# program for Client 
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class Client : MonoBehaviour
{
    StreamWriter sw;
    StreamReader sr;

    public void SendToServer()
    {
        TcpClient tcpClient = new TcpClient("127.0.0.1", 8532);
        Stream s = tcpClient.GetStream();
        sw = new StreamWriter(s);
        sr = new StreamReader(s);
        sw.AutoFlush = true;
        print(sr.ReadLine());
        sw.WriteLine("Hello from client");
        s.Close();
        tcpClient.Close();
    }
}


