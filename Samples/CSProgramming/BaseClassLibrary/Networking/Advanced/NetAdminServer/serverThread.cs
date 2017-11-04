using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Text;
using System.Collections;
using System.ComponentModel;
using System.Xml;
using System.Windows.Forms;

namespace NetAdminServer
{

	class ProcessObject
	{
		private string processName;
		private string processStartTime;
		
		public ProcessObject(string pName, string pStartTime)
		{
			this.processName = pName;
			this.processStartTime = pStartTime;
        }

		public string ProcessName
		{
			get
			{
				return this.processName;
			}
			set
			{
				this.processName = value;
			}
		}

		public string ProcessStartTime
		{
			get
			{
				return this.processStartTime ;
			}
			set
			{
				this.processStartTime = value;
			}
		}
	}

	class ServiceObject
	{
		private string displayName;
		private string serviceType;
		private string status;

		public ServiceObject(string dName, string sType, string sStatus)
		{
			this.displayName = dName;
			this.serviceType = sType;
			this.status = sStatus;
		}
		public string DisplayName
		{
			get
			{
				return this.displayName;
			}
			set
			{
				this.displayName = value;
			}
		}

		public string ServiceType
		{
			get
			{
				return this.serviceType;
			}
			set
			{
				this.serviceType = value;
			}
		}

		public string Status
		{
			get
			{
				return this.status;
			}
			set
			{
				this.status = value;
			}
		}
	}

	

		class serverListenerArgs : EventArgs
		{
			private clientInfo clientinfo;

			public serverListenerArgs(clientInfo cltinfo):base()
			{
				this.clientinfo = cltinfo;
			}

			public clientInfo ClientInfo
			{
				get
				{
					return clientinfo;
				}
			}


		}

		class serverListener
		{
			public  delegate void clientSignal (object Sender , serverListenerArgs args);
	
			public event clientSignal onClientSignal;

			private TcpListener server_socket;	
			private int port;
			private bool running=true;
   
			///<summary>
			/// This is the constructor of netserver class it opens the specified port to listen 
			/// for clients
			///</summary>
			///<param name="prt">Port at which Server works</param>

			public serverListener(int prt)
			{
				try
				{

					port=prt;
					server_socket=new TcpListener(port);
					server_socket.Start(); 
					
					// Console.WriteLine("Server started, Listening at port"+port.ToString());
					Thread thr=new Thread(new ThreadStart(server_listen));
					thr.Start();
				}
				catch(Exception e)
				{
					throw new Exception ("Error Occurred in Listener");
				}

			}

   
			///<summary>
			/// This method is a starting point of listener thread which continously listens for new clients 
			/// and when a client arrives starts a new thread to handle that client
			///</summary>
			public void server_listen()
			{
				while(running)
				{
					try
					{
					

						Socket sock=server_socket.AcceptSocket();
						//  Console.WriteLine("Connected to Server "+sock.RemoteEndPoint);
						clientInfo clt=new clientInfo(sock);
					
						onClientSignal(this , new serverListenerArgs(clt));
						//clt.getMachineName(); 
					}
					catch(Exception e)
					{
						throw new Exception("Error Occurred while listening for clients ");
					}  
				

				}
			}

			public void close()
			{
				running=false;
				server_socket.Stop();
			}


		}


		class clientInfo 
		{
			/// <summary>
			/// Client Attributes
			/// </summary>
			private Socket connectedSocket;
			private Thread clt_thread;
			private string machineName ="";
			private string ipAddress = "";
			private int portNumber;
			private string userName ="";
			private ArrayList serviceList;
			private ArrayList processList;
			private bool running = true;
			//private NetworkStream dataStream;

			public ArrayList ProcessList
			{
				get
				{
					return processList;
				}
			}
			public ArrayList ServiceList
			{
				get
				{
					return serviceList;
				}
			}

			public string IpAddress
			{
				get
				{
					return ipAddress;
				}
				set
				{
					ipAddress = value;
				}
			}
		

			public Socket ConnectedSocket
			{
				get
				{
					return connectedSocket;
				}
				set
				{
					connectedSocket = value;
			    
				}
			}

			public string MachineName
			{
				get
				{
					return machineName;
				}
				set
				{
					machineName = value;
				}
			}

			public int PortNumber
			{
				get
				{
					return portNumber;
				}
				set 
				{
					portNumber = value;
				}
			}

			public string UserName
			{
				get
				{
					return userName;
				}
				set
				{
					userName = value;
				}
			}
		
			public bool stopService(string servicename)
			{
				string servicestring = "<command type=\"Stop_Service\">";
				servicestring += "<param name=\""+servicename+"\"></param>";
				servicestring += "</command>$";

				byte[] buffer = new byte[1024];
				buffer = Encoding.ASCII.GetBytes(servicestring);
				connectedSocket.Send(buffer);

				connectedSocket.Receive (buffer);
				string s =  Encoding.ASCII.GetString(buffer);

			
				while(connectedSocket.Available >0 )
				{
					connectedSocket.Receive (buffer);
					s +=  Encoding.ASCII.GetString(buffer);
				}

				string resultXML = s.Substring(0,s.IndexOf('$')); 

				XmlDocument doc = new XmlDocument();
				doc.LoadXml(resultXML);
  
				XmlNode node =doc.FirstChild;
				if (node.Attributes.GetNamedItem("type").Value == "Stop_Service")
				{
					XmlNode childNode = node.FirstChild;
					string a = childNode.Attributes.GetNamedItem("result").Value;   
					if (a == "Success")
						return true;
					else
						return false;


				}
				else
				{
					throw new Exception("Wrong Packet Recieved");
					return false;

				}
			}

			public void getRemoteMachineName()
			{
				string machinename = "<command type=\"Machine_Name\">";
				machinename += "</command>$";

			//	MessageBox.Show(machinename);


				byte[] buffer = new byte[1024];
				buffer = Encoding.ASCII.GetBytes(machinename);
				connectedSocket.Send(buffer);
				
				
				connectedSocket.Receive (buffer);
				string s =  Encoding.ASCII.GetString(buffer);

			
				while(connectedSocket.Available >0 )
				{
					connectedSocket.Receive (buffer);
					s +=  Encoding.ASCII.GetString(buffer);
				}


				string resultXML = s.Substring(0,s.IndexOf('$')); 
						
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(resultXML);
  
				XmlNode node =doc.FirstChild;
				if (node.Attributes.GetNamedItem("type").Value == "Machine_Name")
				{
					XmlNode childNode = node.FirstChild;
					this.machineName = childNode.Attributes.GetNamedItem("name").Value;   
				}
				else
					throw new Exception("Wrong Packet Recieved"); 
					  
			}
			

			public  void getRemoteUserName()
			{
				string username = "<command type=\"User_Name\">";
				username += "</command>$";
				
				
				byte[] buffer = new byte[1024];
				buffer = Encoding.ASCII.GetBytes(username);
				connectedSocket.Send(buffer);  


				connectedSocket.Receive (buffer);
				string s =  Encoding.ASCII.GetString(buffer);

				while(connectedSocket.Available >0 )
				{
					connectedSocket.Receive (buffer);
					s +=  Encoding.ASCII.GetString(buffer);
				}

				string resultXML = s.Substring(0,s.IndexOf('$')); 
				
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(resultXML);
  
				XmlNode node =doc.FirstChild;
				if (node.Attributes.GetNamedItem("type").Value == "User_Name")
				{
					XmlNode childNode = node.FirstChild;
					this.userName  = childNode.Attributes.GetNamedItem("name").Value;   
				}
				else
					throw new Exception("Wrong Packet Recieved");
			}

			public void getProcessList()
			{
				string processlist = "<command type=\"Process_List\">";
				processlist += "</command>$";
				
				
				byte[] buffer = new byte[3000];
				buffer = Encoding.ASCII.GetBytes(processlist);
				connectedSocket.Send(buffer);  


				connectedSocket.Receive (buffer);
				string s =  Encoding.ASCII.GetString(buffer);

				while(connectedSocket.Available >0 )
				{
					connectedSocket.Receive (buffer);
					s +=  Encoding.ASCII.GetString(buffer);
				}

				string resultXML = s.Substring(0,s.IndexOf('$')); 
				
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(resultXML);
  
				XmlNode node =doc.FirstChild;
				if (node.Attributes.GetNamedItem("type").Value == "Process_List")
				{
					XmlNodeList nodeList = node.ChildNodes;
					IEnumerator en = nodeList.GetEnumerator();
  
					while (en.MoveNext())
					{

						XmlNode childNode = (XmlNode) en.Current;   
						string pname= childNode.Attributes.GetNamedItem("name").Value;
						string ptime = childNode.Attributes.GetNamedItem("time").Value;
						ProcessObject processObject = new ProcessObject(pname,ptime); 
						processList.Add(processObject);
					}
				}
				else
					throw new Exception("Wrong Packet Recieved");
			}

			public void getServiceList()
			{
				string servicelist = "<command type=\"Service_List\">";
				servicelist  += "</command>$";
				
				
				byte[] buffer = new byte[3000];
				buffer = Encoding.ASCII.GetBytes(servicelist);
				connectedSocket.Send(buffer);  


				connectedSocket.Receive (buffer);
				string s =  Encoding.ASCII.GetString(buffer);

				while(connectedSocket.Available >0 )
				{
					connectedSocket.Receive (buffer);
					s +=  Encoding.ASCII.GetString(buffer);
				}

				string resultXML = s.Substring(0,s.IndexOf('$')); 
				
				XmlDocument doc = new XmlDocument();
				doc.LoadXml(resultXML);
  
				XmlNode node =doc.FirstChild;
				if (node.Attributes.GetNamedItem("type").Value == "Service_List")
				{
					XmlNodeList nodeList = node.ChildNodes;
					IEnumerator en = nodeList.GetEnumerator();
  
					while (en.MoveNext())
					{

						XmlNode childNode = (XmlNode) en.Current;   
						string sname= childNode.Attributes.GetNamedItem("name").Value;
						string stype = childNode.Attributes.GetNamedItem("type").Value;
						string sstatus = childNode.Attributes.GetNamedItem("status").Value;
						ServiceObject serviceObject = new ServiceObject(sname,stype,sstatus); 
						serviceList.Add(serviceObject);
					}
				}
				else
					throw new Exception("Wrong Packet Recieved");
			}

			///<summary>
			/// This is the constructor of clientconnect class it initializes the socket with its member 
			/// socket and starts a thread which handles that client
			///</summary>
			///<param name="sock">Socket which represents a client</param>
 
			public clientInfo(Socket sock)
			{
				try
				{
					connectedSocket=sock;
					
				
					string temp  =  sock.RemoteEndPoint.ToString();
					ipAddress = temp.Substring(0,temp.IndexOf(':'));
					portNumber = Convert.ToInt32(temp.Substring(temp.IndexOf(':')+1));

					getRemoteMachineName();
					getRemoteUserName(); 
					
					serviceList = new ArrayList();
					processList = new ArrayList();

					getProcessList();
					getServiceList();

				//	clt_thread=new Thread(new ThreadStart(run_Thread));
				//	clt_thread.Start();
				}
				catch(Exception e)
				{
					MessageBox.Show(e.Message,"Information");  
				}
			}


			///<summary>
			/// This method is a starting point of listener thread which continousy listens from client 
			///</summary>
  
			public void run_Thread()
			{
				try
				{
					Byte[] bReceive = new Byte[1024];
   
					while(running)
					{ 
						int i = connectedSocket.Receive( bReceive);
						string sBuffer=Encoding.ASCII.GetString(bReceive);
						//Console.WriteLine("Client said "+sBuffer.TrimEnd());     
					}
				}
				catch(Exception e)
				{
					MessageBox.Show(e.Message);
     			}
				finally
				{
					connectedSocket.Close();
				}
			}
		}
	}
