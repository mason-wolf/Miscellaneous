using System.Net;
using System.Text;
using System.Net.Sockets;
using System;

namespace Server
{
    class Program
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";

        static void Main(string[] args)
        {
            bool connection = true;
            while (connection == true) {
          
            // Listening on port 5000 at 127.0.0.1
            IPAddress localAdd = IPAddress.Parse(SERVER_IP);
            TcpListener listener = new TcpListener(localAdd, PORT_NO);
            listener.Start();

            // Incoming client
            TcpClient client = listener.AcceptTcpClient();

            // Get incoming data through network string
            NetworkStream nwStream = client.GetStream();
            byte[] buffer = new byte[client.ReceiveBufferSize];

            // Read incoming string
            int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

            // Convert the data recieved into a string
            string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
            Console.WriteLine("Received : \n\n" + dataReceived + "\n");


            client.Close();
            listener.Stop();
           
            }
        }
    }
}
