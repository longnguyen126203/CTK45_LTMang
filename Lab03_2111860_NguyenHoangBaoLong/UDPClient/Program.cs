using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDPClient
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string str = "Hello Server...";
            byte[] buff = new byte[1024];
            EndPoint serverEndPoint = new IPEndPoint(IPAddress.Loopback, 5000);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            buff = Encoding.ASCII.GetBytes(str);
            server.SendTo(buff, buff.Length, SocketFlags.None, serverEndPoint);
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
            EndPoint remote = (EndPoint)sender;
            Console.WriteLine("Da goi cau chao len Server...");
            //while (true)
            //{
            //    buff = new byte[1024];

            //    str = Console.ReadLine();
            //    buff = Encoding.ASCII.GetBytes(str);
            //    server.SendTo(buff, buff.Length, SocketFlags.None, serverEndPoint);
            //    if (str == "exit" || str == "exit all") break;
            //    buff = new byte[1024];
            //    server.ReceiveFrom(buff, 0, buff.Length, SocketFlags.None, ref remote);
            //    str = Encoding.ASCII.GetString(buff, 0, buff.Length);
            //    Console.WriteLine(str);
            //}
            for (int i = 1; i <= 5; i++)
            {
                buff = new byte[1024];
                
                str = Console.ReadLine();
                buff = Encoding.ASCII.GetBytes(str);
                server.SendTo(buff, buff.Length, SocketFlags.None, serverEndPoint);
                if (str == "exit" || str == "exit all") break;
                buff = new byte[1024];
                server.ReceiveFrom(buff, 0, buff.Length, SocketFlags.None, ref remote);
                str = Encoding.ASCII.GetString(buff, 0, buff.Length);
                Console.WriteLine(str);
            }

        }
    }
}
