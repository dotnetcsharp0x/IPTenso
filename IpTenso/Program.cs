using System;
using System.Net.Sockets;

namespace IpTenso
{
    static class Program
    {
        const int port = 4001;
        const string address = "192.168.188.189";
        static void Main(string[] args)
        {
            byte[] bytes = new byte[16];
            string dat = "";
            byte[] datas = { 0xff, 0x01, 0xc2, 0x8a, 0xff, 0xff };
            NetworkStream stream = null;
            TcpClient client = null;
            client = new TcpClient(address, port);
            stream = client.GetStream();
            stream.Write(datas, 0, datas.Length);
            do
            {
                int bytesRec = stream.Read(bytes, 0, bytes.Length);
                for (int i = 3; i < bytes.Length - 3; i++)
                {
                    if (Convert.ToString(bytes[i], 16) == "51") break;
                    dat += Convert.ToString(bytes[i], 16);
                }
            }
            while (stream.DataAvailable);
            Console.WriteLine(dat);
            Console.ReadLine();
        }
    }
}
