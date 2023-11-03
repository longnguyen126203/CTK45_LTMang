using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace UDPSvr
{
    class Program
    {
        static void Main(string[] args)
        {
            string str;
            int byteReceive;
            byte[] buff = new byte[1024];
            // Tao server EndPoint, EndPoint nay se tham chieu den dia chi IP va Port cua Server
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            // IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 0);

            // Tao Server Socket, Socket nay dung de trao doi du lieu voi Client
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            serverSocket.Bind(serverEndPoint);
            Console.WriteLine("Dang cho client ket noi toi...");

            IPEndPoint sender = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            // IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 0);
            EndPoint remote = (EndPoint)(sender);

            byteReceive = serverSocket.ReceiveFrom(buff, ref remote);
            Console.WriteLine("Da ket noi toi client: {0}:", remote.ToString());
            Console.WriteLine(Encoding.ASCII.GetString(buff, 0, byteReceive));

            Console.WriteLine("Hello Server {0}", remote.ToString());
            while (true)
            {
                buff = new byte[1024];
                byteReceive = serverSocket.ReceiveFrom(buff, 0, buff.Length, SocketFlags.None, ref remote);
                str = Encoding.ASCII.GetString(buff, 0, byteReceive);
                Console.WriteLine(str);
                if (str.Replace("\0", "").Equals("exit all")) break;
                serverSocket.SendTo(buff, 0, buff.Length, SocketFlags.None, remote);
            }
            serverSocket.Connect(remote);
            //for(int i = 0; i < 5; i++)
            //{
            //    str = Console.ReadLine();
            //    if (str == "exit") 
            //        break;
            //    serverSocket.SendTo(Encoding.ASCII.GetBytes(str), remote);
            //    buff = new byte[i];
            //    try
            //    {
            //        byteReceive = serverSocket.ReceiveFrom(buff, ref remote);
            //        str = Encoding.ASCII.GetString(buff, 0, byteReceive);
            //        Console.WriteLine(str);
            //    }
            //    catch(SocketException)
            //    {
            //        Console.WriteLine("Canh bao: du lieu bi mat, hay thu lai");
            //        i += 10;
            //    }
            //}
        }    
    }
}
