using System.Net;
using System.Text;
using System.Net.Sockets;
using System;
using System.Security;
using System.Globalization;

namespace Client
{
    class Program
    {
        const int PORT_NO = 5000;
        const string SERVER_IP = "127.0.0.1";
		
        static void Main(string[] args)
        {
         
            //---data to send to the server---
			
			string ViperData = System.Security.Principal.WindowsIdentity.GetCurrent().Name + "\n" +
            DateTime.Now.ToString();
             try {
                 
            //---create a TCPClient object at the IP and port no.---
            TcpClient client = new TcpClient(SERVER_IP, PORT_NO);
            NetworkStream nwStream = client.GetStream();
            
        //    byte[] newline = Encoding.ASCII.GetBytes(Environment.NewLine);
        
            byte[] ClientInfo = ASCIIEncoding.ASCII.GetBytes(ViperData);
            //---send the text---
            Console.WriteLine("Sending : " + ClientInfo + "\n");
            nwStream.Write(ClientInfo, 0, ClientInfo.Length);
            client.Close();
            
             }
             catch(Exception) {
                Console.WriteLine("Cannot connect to server.");
                Console.ReadLine();
            }
        }
    }
}
