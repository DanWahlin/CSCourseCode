using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
 

namespace NetAdminServer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class server : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox clientListBox;

		//private TcpListener list;
		
		private ArrayList  clientInformation = new ArrayList();
		private serverListener listener;
		private clientInfo selectedClient;
		private ProcessObject selectedProcess;
		private ServiceObject selectedService;

		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox serviceListBox;
		private System.Windows.Forms.TextBox serviceNameTextBox;
		private System.Windows.Forms.TextBox serviceStatusTextBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox protocolTextBox;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox portTextBox;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox ipAddressTextBox;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox machineNameTextBox;
		private System.Windows.Forms.ToolBarButton stopClientButton;
		private System.Windows.Forms.ToolBarButton pauseServiceButton;
		private System.Windows.Forms.ToolBarButton stopServiceButton;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton resumeServiceButton;
		private System.Windows.Forms.TextBox userNameTextBox;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.Label lbllist;
		private System.Windows.Forms.Label lblname;
		private System.Windows.Forms.TextBox serviceTypeTextBox;
		private System.Windows.Forms.Label lbltype;
		private System.Windows.Forms.Label lblstatus;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton killprocessbutton;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public server()
		{
			
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			
			//listener.close(); 
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.clientListBox = new System.Windows.Forms.ListBox();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.stopClientButton = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.pauseServiceButton = new System.Windows.Forms.ToolBarButton();
			this.resumeServiceButton = new System.Windows.Forms.ToolBarButton();
			this.stopServiceButton = new System.Windows.Forms.ToolBarButton();
			this.label1 = new System.Windows.Forms.Label();
			this.serviceListBox = new System.Windows.Forms.ListBox();
			this.lbllist = new System.Windows.Forms.Label();
			this.serviceNameTextBox = new System.Windows.Forms.TextBox();
			this.serviceTypeTextBox = new System.Windows.Forms.TextBox();
			this.serviceStatusTextBox = new System.Windows.Forms.TextBox();
			this.lblname = new System.Windows.Forms.Label();
			this.lbltype = new System.Windows.Forms.Label();
			this.lblstatus = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label10 = new System.Windows.Forms.Label();
			this.protocolTextBox = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.portTextBox = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.userNameTextBox = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.ipAddressTextBox = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.machineNameTextBox = new System.Windows.Forms.TextBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.killprocessbutton = new System.Windows.Forms.ToolBarButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// clientListBox
			// 
			this.clientListBox.Location = new System.Drawing.Point(32, 80);
			this.clientListBox.Name = "clientListBox";
			this.clientListBox.Size = new System.Drawing.Size(248, 420);
			this.clientListBox.TabIndex = 0;
			this.clientListBox.SelectedIndexChanged += new System.EventHandler(this.clientListBox_SelectedIndexChanged);
			// 
			// toolBar1
			// 
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.stopClientButton,
																						this.toolBarButton1,
																						this.pauseServiceButton,
																						this.resumeServiceButton,
																						this.stopServiceButton,
																						this.toolBarButton3,
																						this.killprocessbutton});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(794, 39);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolbarClicked);
			// 
			// stopClientButton
			// 
			this.stopClientButton.Text = "Stop Client";
			this.stopClientButton.ToolTipText = "Stop/Disconnect Client";
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// pauseServiceButton
			// 
			this.pauseServiceButton.Text = "Pause Service";
			this.pauseServiceButton.ToolTipText = "Pause Service";
			// 
			// resumeServiceButton
			// 
			this.resumeServiceButton.Text = "Resume Service";
			this.resumeServiceButton.ToolTipText = "Resume Service";
			// 
			// stopServiceButton
			// 
			this.stopServiceButton.Text = "Stop Service";
			this.stopServiceButton.ToolTipText = "Stop Service";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(32, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Clients Connected";
			// 
			// serviceListBox
			// 
			this.serviceListBox.Location = new System.Drawing.Point(320, 288);
			this.serviceListBox.Name = "serviceListBox";
			this.serviceListBox.Size = new System.Drawing.Size(232, 212);
			this.serviceListBox.TabIndex = 3;
			this.serviceListBox.SelectedIndexChanged += new System.EventHandler(this.serviceListBox_SelectedIndexChanged);
			// 
			// lbllist
			// 
			this.lbllist.AutoSize = true;
			this.lbllist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbllist.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbllist.Location = new System.Drawing.Point(320, 264);
			this.lbllist.Name = "lbllist";
			this.lbllist.Size = new System.Drawing.Size(99, 16);
			this.lbllist.TabIndex = 4;
			this.lbllist.Text = "List of Process";
			// 
			// serviceNameTextBox
			// 
			this.serviceNameTextBox.Location = new System.Drawing.Point(600, 312);
			this.serviceNameTextBox.Name = "serviceNameTextBox";
			this.serviceNameTextBox.Size = new System.Drawing.Size(160, 20);
			this.serviceNameTextBox.TabIndex = 5;
			this.serviceNameTextBox.Text = "";
			// 
			// serviceTypeTextBox
			// 
			this.serviceTypeTextBox.Location = new System.Drawing.Point(600, 392);
			this.serviceTypeTextBox.Name = "serviceTypeTextBox";
			this.serviceTypeTextBox.Size = new System.Drawing.Size(160, 20);
			this.serviceTypeTextBox.TabIndex = 6;
			this.serviceTypeTextBox.Text = "";
			this.serviceTypeTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// serviceStatusTextBox
			// 
			this.serviceStatusTextBox.Location = new System.Drawing.Point(600, 472);
			this.serviceStatusTextBox.Name = "serviceStatusTextBox";
			this.serviceStatusTextBox.Size = new System.Drawing.Size(160, 20);
			this.serviceStatusTextBox.TabIndex = 7;
			this.serviceStatusTextBox.Text = "";
			this.serviceStatusTextBox.Visible = false;
			// 
			// lblname
			// 
			this.lblname.AutoSize = true;
			this.lblname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblname.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblname.Location = new System.Drawing.Point(600, 288);
			this.lblname.Name = "lblname";
			this.lblname.Size = new System.Drawing.Size(96, 16);
			this.lblname.TabIndex = 8;
			this.lblname.Text = "Process Name";
			// 
			// lbltype
			// 
			this.lbltype.AutoSize = true;
			this.lbltype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lbltype.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbltype.Location = new System.Drawing.Point(600, 368);
			this.lbltype.Name = "lbltype";
			this.lbltype.Size = new System.Drawing.Size(126, 16);
			this.lbltype.TabIndex = 9;
			this.lbltype.Text = "Process Start Time";
			// 
			// lblstatus
			// 
			this.lblstatus.AutoSize = true;
			this.lblstatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lblstatus.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblstatus.Location = new System.Drawing.Point(600, 448);
			this.lblstatus.Name = "lblstatus";
			this.lblstatus.Size = new System.Drawing.Size(97, 16);
			this.lblstatus.TabIndex = 10;
			this.lblstatus.Text = "Service Status";
			this.lblstatus.Visible = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.label10,
																					this.protocolTextBox,
																					this.label9,
																					this.portTextBox,
																					this.label8,
																					this.userNameTextBox,
																					this.label7,
																					this.ipAddressTextBox,
																					this.label6,
																					this.machineNameTextBox});
			this.groupBox1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(320, 48);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(448, 208);
			this.groupBox1.TabIndex = 11;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Client Information";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label10.Location = new System.Drawing.Point(8, 152);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(162, 16);
			this.label10.TabIndex = 30;
			this.label10.Text = "Communication Protocol";
			// 
			// protocolTextBox
			// 
			this.protocolTextBox.Location = new System.Drawing.Point(8, 176);
			this.protocolTextBox.Name = "protocolTextBox";
			this.protocolTextBox.Size = new System.Drawing.Size(168, 26);
			this.protocolTextBox.TabIndex = 29;
			this.protocolTextBox.Text = "";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label9.Location = new System.Drawing.Point(272, 88);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(137, 16);
			this.label9.TabIndex = 28;
			this.label9.Text = "Service Access Point";
			// 
			// portTextBox
			// 
			this.portTextBox.Location = new System.Drawing.Point(272, 112);
			this.portTextBox.Name = "portTextBox";
			this.portTextBox.Size = new System.Drawing.Size(168, 26);
			this.portTextBox.TabIndex = 27;
			this.portTextBox.Text = "";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label8.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.Location = new System.Drawing.Point(8, 88);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 16);
			this.label8.TabIndex = 26;
			this.label8.Text = "UserName";
			// 
			// userNameTextBox
			// 
			this.userNameTextBox.Location = new System.Drawing.Point(8, 112);
			this.userNameTextBox.Name = "userNameTextBox";
			this.userNameTextBox.Size = new System.Drawing.Size(168, 26);
			this.userNameTextBox.TabIndex = 25;
			this.userNameTextBox.Text = "";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label7.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.Location = new System.Drawing.Point(272, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(76, 16);
			this.label7.TabIndex = 24;
			this.label7.Text = "IP Address";
			// 
			// ipAddressTextBox
			// 
			this.ipAddressTextBox.Location = new System.Drawing.Point(272, 48);
			this.ipAddressTextBox.Name = "ipAddressTextBox";
			this.ipAddressTextBox.Size = new System.Drawing.Size(168, 26);
			this.ipAddressTextBox.TabIndex = 23;
			this.ipAddressTextBox.Text = "";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label6.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.Location = new System.Drawing.Point(8, 24);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(109, 16);
			this.label6.TabIndex = 22;
			this.label6.Text = "Computer Name";
			// 
			// machineNameTextBox
			// 
			this.machineNameTextBox.Location = new System.Drawing.Point(8, 48);
			this.machineNameTextBox.Name = "machineNameTextBox";
			this.machineNameTextBox.Size = new System.Drawing.Size(168, 26);
			this.machineNameTextBox.TabIndex = 21;
			this.machineNameTextBox.Text = "";
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.radioButton1.Location = new System.Drawing.Point(320, 504);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.TabIndex = 12;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Process List";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// radioButton2
			// 
			this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.radioButton2.Location = new System.Drawing.Point(448, 504);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.TabIndex = 13;
			this.radioButton2.Text = "Service List";
			this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// killprocessbutton
			// 
			this.killprocessbutton.Text = "Stop Process";
			this.killprocessbutton.ToolTipText = "Kills Selected Process";
			// 
			// server
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(794, 535);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.radioButton2,
																		  this.radioButton1,
																		  this.groupBox1,
																		  this.lblstatus,
																		  this.lbltype,
																		  this.lblname,
																		  this.lbllist,
																		  this.label1,
																		  this.serviceStatusTextBox,
																		  this.serviceTypeTextBox,
																		  this.serviceNameTextBox,
																		  this.serviceListBox,
																		  this.toolBar1,
																		  this.clientListBox});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.Name = "server";
			this.Text = "Net Admin Server";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.server_closed);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.listener = new serverListener(1024);
			this.listener.onClientSignal += new serverListener.clientSignal(this.clientConnectionHandler);
		


		}
		#endregion

		//this.listener = new serverListener(1024);
		//this.listener.onClientSignal += new serverListener.clientSignal(this.clientConnectionHandler);
		
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new server());
		}
		
		/// <summary>
		/// Event handler for new client connection
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void clientConnectionHandler (object sender , serverListenerArgs e)
		{
			clientInfo c = e.ClientInfo;
			clientInformation.Add (c);
			//clientListBox.Items.Add(c.ConnectedSocket.RemoteEndPoint.ToString());
    

			clientListBox.Items.Add(c.MachineName );
			//c.getMachineName(); 
			
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			/*
		  	clientListBox.Items.Add("First");   
			while (true)
			{
				Socket s = list.AcceptSocket();
				clientListBox.Items.Add(s.RemoteEndPoint.ToString());
			}
			*/
		}

		private void server_closed(object sender, System.EventArgs e)
		{
		
			

		}

		private void textBox2_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void label9_Click(object sender, System.EventArgs e)
		{
		
		}

		private void toolbarClicked(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (e.Button.Equals(this.toolBar1.Buttons[0]))
			{
				MessageBox.Show("stop client"); 
			}
			else if (e.Button.Equals(this.toolBar1.Buttons[2]))
			{
				MessageBox.Show("Pause Service");
			}
			else if (e.Button.Equals(this.toolBar1.Buttons[3]))
			{
				MessageBox.Show("Resume Service");
			} 
			else if (e.Button.Equals(this.toolBar1.Buttons[4]))
			{
				//MessageBox.Show("Stop Service");
				if (selectedClient != null && selectedService != null)
				{
					bool result = selectedClient.stopService(selectedService.DisplayName);
					if (result)
					{
						selectedService.Status="Stopped";
						serviceListBox_SelectedIndexChanged(sender, e);
					}
					else
						MessageBox.Show("Operation Failed","Error Message");   
				}
				else
				{
					MessageBox.Show("No Service selected","Alert");
				}
                		

			} 
			else if (e.Button.Equals(this.toolBar1.Buttons[6]))
			{
				MessageBox.Show("Stop Process");
			} 

		}

		private void clientListBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
				selectedClient = (clientInfo) clientInformation[clientListBox.SelectedIndex];
				machineNameTextBox.Text = selectedClient.MachineName;
				userNameTextBox.Text = selectedClient.UserName;
				ipAddressTextBox.Text = selectedClient.IpAddress;
				portTextBox.Text = selectedClient.PortNumber.ToString() ;
				protocolTextBox.Text = selectedClient.ConnectedSocket.ProtocolType.ToString(); 
				
			if(radioButton1.Checked)
			{
				serviceListBox.Items.Clear();
				IEnumerator en = selectedClient.ProcessList.GetEnumerator();
 
				while (en.MoveNext())
				{
					ProcessObject processObject = (ProcessObject) en.Current;
					serviceListBox.Items.Add(processObject.ProcessName);
				}

			}
			else if (radioButton2.Checked)
			{
				serviceListBox.Items.Clear();
				IEnumerator en = selectedClient.ServiceList.GetEnumerator();  
 
				while (en.MoveNext())
				{
					ServiceObject serviceObject = (ServiceObject) en.Current;
					serviceListBox.Items.Add(serviceObject.DisplayName);
				}
			}
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioButton2.Checked)  
			{
				lbllist.Text = "List of Service";
				lblname.Text = "Service Name";
				lbltype.Text = "Service Type";

				serviceStatusTextBox.Visible = true;
				lblstatus.Visible = true; 
				if (clientListBox.SelectedIndex >= 0)
				{
					//clientInfo client = (clientInfo) clientInformation[clientListBox.SelectedIndex];
					//serviceListBox.DataSource = client.ServiceList;
					//serviceListBox.DisplayMember = "DisplayName";  
					serviceListBox.Items.Clear();
					IEnumerator en = selectedClient.ServiceList.GetEnumerator();  
 
					while (en.MoveNext())
					{
						ServiceObject serviceObject = (ServiceObject) en.Current;
						serviceListBox.Items.Add(serviceObject.DisplayName);
						
					}
				}

			}
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (radioButton1.Checked)  
			{
				lbllist.Text = "List of Process";
				lblname.Text = "Process Name";
				lbltype.Text = "Process Type";

				serviceStatusTextBox.Visible = false;
				lblstatus.Visible = false; 

				if (clientListBox.SelectedIndex >= 0)
				{
					//clientInfo client = (clientInfo) clientInformation[clientListBox.SelectedIndex];
					//serviceListBox.DataSource = client.ProcessList;
					//serviceListBox.DisplayMember = "ProcessName";
  
					serviceListBox.Items.Clear();
					IEnumerator en = selectedClient.ProcessList.GetEnumerator();
 
					while (en.MoveNext())
					{
						ProcessObject processObject = (ProcessObject) en.Current;
						serviceListBox.Items.Add(processObject.ProcessName);
					}
				}

			}
		}

		private void serviceListBox_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//clientInfo client = (clientInfo) clientInformation[clientListBox.SelectedIndex];
			 
			if (radioButton1.Checked)
			{	

				selectedProcess  = (ProcessObject) selectedClient.ProcessList[serviceListBox.SelectedIndex];     
				serviceNameTextBox.Text = selectedProcess.ProcessName;
				serviceTypeTextBox.Text = selectedProcess.ProcessStartTime;  
			}
			else
			{
				//MessageBox.Show("Hello World"); 
				selectedService = (ServiceObject) selectedClient.ServiceList [serviceListBox.SelectedIndex];
				serviceNameTextBox.Text = selectedService.DisplayName;
				serviceTypeTextBox.Text = selectedService .ServiceType;
				serviceStatusTextBox.Text = selectedService.Status;  
			}
		}
	}
}
