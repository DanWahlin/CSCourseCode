using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Text;

namespace netadmin
{
 class netserver
 {
   
   private TcpListener server_socket;
   private int port;
   
   ///<summary>
   /// This is the constructor of netserver class it opens the specified port to listen 
   /// for clients
   ///</summary>
   ///<param name="prt">Port at which Server works</param>

   public netserver(int prt)
   {
    try
    {

     port=prt;
     server_socket=new TcpListener(port);
     server_socket.Start(); 
     Console.WriteLine("Server started, Listening at port"+port.ToString());
     Thread thr=new Thread(new ThreadStart(server_listen));
     thr.Start();
    }
    catch(Exception e)
    {
     Console.WriteLine("Exception1 thrown "+e.Message);
    }

   }

   
   ///<summary>
   /// This method is a starting point of listener thread which continously listens for new clients 
   /// and when a client arrives starts a new thread to handle that client
   ///</summary>
   public void server_listen()
   {
    while(true)
    {
     try
     {
 
      Socket sock=server_socket.AcceptSocket();
      Console.WriteLine("Connected to Server "+sock.RemoteEndPoint);
      clientconnect clt=new clientconnect(sock);
     }
     catch(Exception e)
     {
      Console.WriteLine("Exception2 thrown "+e.Message);
     }  
    }
   }
  }

 
 class clientconnect 
 {
  private Socket connected_socket;
  private Thread clt_thread;

   ///<summary>
   /// This is the constructor of clientconnect class it initializes the socket with its member 
   /// socket and starts a thread which handles that client
   ///</summary>
   ///<param name="sock">Socket which represents a client</param>
 
  public clientconnect(Socket sock)
  {
   try
   {
    connected_socket=sock;
    clt_thread=new Thread(new ThreadStart(rec_mesg));
    clt_thread.Start();
   }
   catch(Exception e)
   {
    Console.WriteLine("Exception3 thrown "+e.Message);
   }
  }


   ///<summary>
   /// This method is a starting point of listener thread which continousy listens from client 
   ///</summary>
  
  public void rec_mesg()
  {
    try
    {
     Byte[] bReceive = new Byte[100];
   
     while(true)
     { 
      int i = connected_socket.Receive(bReceive,bReceive.Length,0);
      string sBuffer=Encoding.ASCII.GetString(bReceive);
      Console.WriteLine("Client said "+sBuffer.TrimEnd());     
     }
    }
    catch(Exception e)
    {
     Console.WriteLine("Exception4 thrown "+e.Message);
     
    }
    finally
    {
     connected_socket.Close();
    }
  }
 }


  class prog_start
  {
   ///<summary>
   /// This is the program start point
   ///</summary>
   ///<returns>State in which program ends (int)</returns>
   
   public static int Main()
   {
    int prt=2020;
    
    netserver server=new netserver(prt);
    return 0; 
   }
  
  }
}