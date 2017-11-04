using System;
using System.Net;
using System.Net.Sockets; 
using System.Threading;
using System.Text;  
using System.ServiceProcess;
using System.ServiceProcess.Design;
using System.Collections; 
using System.Diagnostics;  
using System.Windows.Forms; 
using System.Xml;


namespace client
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class StartClient
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				//mlTextReader tr = new XmlTextReader("settings.xml"); 

			
				netclient client = new netclient("127.0.0.1",1024);
				Console.ReadLine();  
			}
			catch(Exception e)
			{
				Console.WriteLine("Setting file not found");
			}
		}
	}

		class netclient
		{
			/// <summary>
			/// Attributes which contains all the client information.
			/// </summary>
			
			private TcpClient clientSocket;
			private int serverPort;
			private string serverIp;
			private string machineName;
			private string userName;
			private NetworkStream networkStream;

			private ServiceController[] services;
			private Process[] processes;

			private bool running=true;

			/// <summary>
			/// Pauses the client thread
			/// </summary>
			/// <returns></returns>
			/*public bool pauseClient()
			{
				return true;
			}*/
			/// <summary>
			/// Resumes the client thread
			/// </summary>
			/// <returns></returns>

			/*public bool resumeClient()
			{
				return true;
			}*/

			/// <summary>
			/// stops the current client
			/// </summary>
			/// <returns></returns>
			public bool stopClient()
			{
				this.running = false;
				return true;
			}

			
			/// <summary>
			/// Restart clients Computer
			/// </summary>
			/// <returns></returns>
			/*public bool restartClient()
			{
				return true;
			}*/

			/// <summary>
			/// Shutdown clients computer
			/// </summary>
			/// <returns></returns>
			/*public bool shutdownClient()
			{
				return true;
			}*/

			/// <summary>
			/// pauses the specified service
			/// </summary>
			/// <param name="serviceName"></param>
			/// <returns></returns>
			public bool pauseService(string serviceName)
			{
				try
				{
					IEnumerator en = services.GetEnumerator();
 
						while (en.MoveNext())
						{
							ServiceController service = (ServiceController) en.Current;
							if (service.DisplayName == serviceName)
								service.Pause();
						}
	
					refreshServiceList(); 
					return true;
				}
				catch(Exception e)
				{
					return false;
				}

			}
			
			/// <summary>
			/// stops the specified service
			/// </summary>
			/// <param name="serviceName"></param>
			/// <returns></returns>
			public bool stopService(string serviceName)
			{
				try
				{
					IEnumerator en = services.GetEnumerator();
 
					while (en.MoveNext())
					{
						ServiceController service = (ServiceController) en.Current;
						if (service.DisplayName == serviceName)
							service.Stop();
					}
					refreshServiceList(); 
					string resultXML;
					resultXML = "<result type=\"Stop_Service\">";
					resultXML += "<params result=\"Success\"/>";
					resultXML += "</result>$";

					byte[] buffer = new byte[3000];
					buffer = Encoding.ASCII.GetBytes(resultXML);   
					networkStream.Write(buffer,0,resultXML.Length);

					return true;
				}
				catch(Exception e)
				{
					string resultXML = "<result type=\"Stop_Service\">";
					resultXML += "<params result=\"Failure\"/>";
					resultXML += "</result>$";

					byte[] buffer = new byte[3000];
					buffer = Encoding.ASCII.GetBytes(resultXML);   
					networkStream.Write(buffer,0,resultXML.Length);
					return false;
				}
			}
			
			/// <summary>
			/// resume the specifed service
			/// </summary>
			/// <param name="serviceName"></param>
			/// <returns></returns>
			public bool resumeService(string serviceName)
			{
				try
				{
					IEnumerator en = services.GetEnumerator();
 
					while (en.MoveNext())
					{
						ServiceController service = (ServiceController) en.Current;
						if (service.DisplayName == serviceName)
							service.Start();
					}
					refreshServiceList(); 
					return true;
				}
				catch(Exception e)
				{
					return false;
				}
			
			}

			/// <summary>
			/// pause the specified process
			/// </summary>
			/// <param name="processName"></param>
			/// <returns></returns>

			/*public bool pauseProcess(string processName)
			{
				return true;
			}*/

			/// <summary>
			/// kills the specifed process
			/// </summary>
			/// <param name="processName"></param>
			/// <returns></returns>
			public bool stopProcess(string processName)
			{
				try
				{
					IEnumerator en = processes.GetEnumerator();
 
					while (en.MoveNext())
					{
						Process process = (Process) en.Current;
						if (process.ProcessName == processName)
							process.Kill();
					}
					refreshProcessList(); 
					return true;
				}
				catch(Exception e)
				{
					return false;
				}
			}
		
			/// <summary>
			/// resumes the specifed process
			/// </summary>
			/// <param name="processName"></param>
			/// <returns></returns>
			/*public bool resumeProcess(string processName)
			{
				return true;
			}*/
			
			/// <summary>
			/// prepares and sends the process list to server
			/// </summary>
			public void sendProcessList()
			{
				string processXML = "";
				processXML += "<result type=\"Process_List\">";
				IEnumerator en = processes.GetEnumerator();
				while (en.MoveNext())
				{
					Process  process = (Process) en.Current;
					processXML += "<params name=\""+process.ProcessName+"\" time=\""+process.StartTime.ToString()+"\" />";
				}
				processXML += "</result>$";	
				byte[] buffer = new byte[3000];
				buffer = Encoding.ASCII.GetBytes(processXML);   
				networkStream.Write(buffer,0,processXML.Length);  
				
			}

			/// <summary>
			/// prepares and sends the service list to server
			/// </summary>
			public void SendServiceList()
			{
				string serviceXML = "";
				serviceXML += "<result type=\"Service_List\">";
				IEnumerator en = services.GetEnumerator();
				while (en.MoveNext())
				{
					ServiceController service = (ServiceController) en.Current;
					serviceXML += "<params name=\""+service.DisplayName+"\" type=\""+service.ServiceType.ToString()+"\" status=\""+service.Status.ToString()+"\" />";
				}
				serviceXML += "</result>$";
				byte[] buffer = new byte[3000];
				buffer = Encoding.ASCII.GetBytes(serviceXML);  
				networkStream.Write(buffer,0,serviceXML.Length);
			}

			/// <summary>
			/// sends the machine list to server
			/// </summary>
			public void sendMachineName()
			{
			
				string machineNameXML;
				machineNameXML = "<result type=\"Machine_Name\">";
				machineNameXML += "<params name=\"" + machineName + "\" />";
				machineNameXML += "</result>$";

				byte[] buffer = new byte[1024];
				buffer = Encoding.ASCII.GetBytes(machineNameXML);  
				networkStream.Write(buffer,0,machineNameXML.Length);

				
			}

			/// <summary>
			/// sends the username to server
			/// </summary>
			public void sendUserName()
			{
				string userNameXML ;
				userNameXML = "<result type=\"User_Name\">";
				userNameXML += "<params name=\"" + userName + "\" />";
				userNameXML += "</result>$";

				byte[] buffer = new byte[1024];
				buffer = Encoding.ASCII.GetBytes(userNameXML);  
				networkStream.Write(buffer,0,userNameXML.Length);
				
			}

			/// <summary>
			/// gets the system services list
			/// </summary>
			private void refreshServiceList()
			{
				services = ServiceController.GetServices();
			}
			
			/// <summary>
			/// gets the system processes list
			/// </summary>
			private void refreshProcessList()
			{
				processes = Process.GetProcesses();
			}

			/// <summary>
			/// Constructor which initializes 
			/// </summary>
			/// <param name="ipaddr"></param>
			/// <param name="prt"></param>
			public netclient(string ipaddr, int prt)
			{
				//setting server parameters
				serverPort=prt;
				serverIp=ipaddr;

				//getting services list
				services = new ServiceController[50];
				refreshServiceList();
				

				//getting process list
				processes = new Process[20];
				refreshProcessList(); 
				

				//getting computer name
				machineName = SystemInformation.ComputerName; 	
				
				//getting username
				userName = SystemInformation.UserName;  
				
				//intializing TCPClient and sending request for connection
				clientSocket=new TcpClient();
				clientSocket.Connect(serverIp,serverPort); 
				Console.WriteLine("Client Connected to Server");
				
				clientSocket.ReceiveBufferSize = 3000;
				clientSocket.SendBufferSize = 3000;
				//Getting Network stream 
				networkStream = clientSocket.GetStream();

				//Process to handle server instructions
				if(networkStream.CanWrite && networkStream.CanRead)
				{	
					try
					{
						while (running)
						{
						

							Byte[] recBytes = new Byte[1024];
					
							int a= networkStream.Read(recBytes,0,1024);
							string buffer = Encoding.ASCII.GetString(recBytes);
							buffer = buffer.Substring(0,buffer.IndexOf('$'));
 
							XmlDocument doc = new XmlDocument();
							doc.LoadXml(buffer);
						
							XmlNode node = doc.FirstChild;
							XmlNode childNode;
 
							string commandType = node.Attributes.GetNamedItem("type").Value;
 
							switch (commandType)
							{
								case "User_Name":
									sendUserName();
									break;
								case "Machine_Name":
									sendMachineName();
									break;
								case "Service_List":
									SendServiceList();
									break;
								case "Process_List":
									sendProcessList();
									break;
								
								case "Pause_Service":
									childNode = node.FirstChild;
									pauseService(childNode.Attributes.GetNamedItem("name").Value);
									break;
								case "Stop_Service":
									childNode = node.FirstChild;
									stopService(childNode.Attributes.GetNamedItem("name").Value);
									break;
								case "Resume_Service":
									childNode = node.FirstChild;
									resumeService(childNode.Attributes.GetNamedItem("name").Value);
									break;
							}
						}
					}
					catch(Exception e)
					{
						Console.WriteLine(e.Message);
					}
				} 
				Console.WriteLine("Press any key to continue.."); 
				Console.Read();
			}
 		}
	}

