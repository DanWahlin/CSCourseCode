using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
namespace netadmin
{
 class netclient
 {

   private TcpClient client_socket;
   private int port;
   private string server_ip;
   
   public netclient(string ipaddr, int prt)
   {
    port=prt;
    server_ip=ipaddr;
    client_socket=new TcpClient();
    client_socket.Connect(server_ip,port); 
    Console.WriteLine("Client Connected to Server");
    NetworkStream networkStream = client_socket.GetStream();

        if(networkStream.CanWrite && networkStream.CanRead)
      {
                   
            while (true)
            {
              string str=Console.ReadLine(); 

              Byte[] sendBytes = Encoding.ASCII.GetBytes(str);
              networkStream.Write(sendBytes, 0, sendBytes.Length);
            }  
      }
   }

 
  
//   public Socket server_listen()
//   {
//    return(server_socket.AcceptSocket());
//   }
   


 }

  class client_start
  {
   public static int Main()
   {
    int prt=2020;
    string ipaddr="127.0.0.1";
    netclient client=new netclient(ipaddr,prt);
//    Socket client_socket=server.server_listen();
 //   Console.WriteLine("COnneted to server "+client_socket.ToString());
    
    return 0; 
           

   }
  }
}