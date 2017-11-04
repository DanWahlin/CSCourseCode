using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsForms
{
	/// <summary>
	/// Summary description for StatusDemo.
	/// </summary>
	public class StatusDemo : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.TextBox TextBox1;
		internal System.Windows.Forms.Timer Timer1;
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.StatusBar StatusBar1;
		internal System.Windows.Forms.StatusBarPanel sbPnlText;
		internal System.Windows.Forms.StatusBarPanel sbPnlTime;
		internal System.Windows.Forms.StatusBarPanel sbPnlInsOvr;
		private System.ComponentModel.IContainer components;

		public StatusDemo()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.sbPnlText.Text = "Ready";
			this.sbPnlInsOvr.Text = "OVR";
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.components = new System.ComponentModel.Container();
			this.TextBox1 = new System.Windows.Forms.TextBox();
			this.Timer1 = new System.Windows.Forms.Timer(this.components);
			this.Button1 = new System.Windows.Forms.Button();
			this.StatusBar1 = new System.Windows.Forms.StatusBar();
			this.sbPnlText = new System.Windows.Forms.StatusBarPanel();
			this.sbPnlTime = new System.Windows.Forms.StatusBarPanel();
			this.sbPnlInsOvr = new System.Windows.Forms.StatusBarPanel();
			((System.ComponentModel.ISupportInitialize)(this.sbPnlText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbPnlTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbPnlInsOvr)).BeginInit();
			this.SuspendLayout();
			// 
			// TextBox1
			// 
			this.TextBox1.Location = new System.Drawing.Point(144, 8);
			this.TextBox1.Name = "TextBox1";
			this.TextBox1.TabIndex = 5;
			this.TextBox1.Text = "";
			this.TextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StatusDemo_KeyUp);
			// 
			// Timer1
			// 
			this.Timer1.Enabled = true;
			this.Timer1.Interval = 1000;
			this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			// 
			// Button1
			// 
			this.Button1.Location = new System.Drawing.Point(24, 8);
			this.Button1.Name = "Button1";
			this.Button1.TabIndex = 4;
			this.Button1.Text = "Update";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StatusDemo_KeyUp);
			// 
			// StatusBar1
			// 
			this.StatusBar1.Location = new System.Drawing.Point(0, 61);
			this.StatusBar1.Name = "StatusBar1";
			this.StatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.sbPnlText,
																						  this.sbPnlTime,
																						  this.sbPnlInsOvr});
			this.StatusBar1.ShowPanels = true;
			this.StatusBar1.Size = new System.Drawing.Size(264, 22);
			this.StatusBar1.TabIndex = 3;
			this.StatusBar1.Text = "StatusBar1";
			// 
			// sbPnlText
			// 
			this.sbPnlText.Text = "sbPnlText";
			// 
			// sbPnlTime
			// 
			this.sbPnlTime.Text = "sbPnlTime";
			// 
			// sbPnlInsOvr
			// 
			this.sbPnlInsOvr.Text = "sbPnlInsOvr";
			// 
			// StatusDemo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(264, 83);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Button1,
																		  this.StatusBar1,
																		  this.TextBox1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StatusDemo";
			this.Text = "Status Bar Demonstration";
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.StatusDemo_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.sbPnlText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbPnlTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbPnlInsOvr)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new StatusDemo());
		}

		private void StatusDemo_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Insert)
			{
				string s = this.sbPnlInsOvr.Text;
				if (s.Equals("INS") )
				{
					this.sbPnlInsOvr.Text = "OVR";
				} else {
					this.sbPnlInsOvr.Text = "INS";
				}
			}
		}

		private void Timer1_Tick(object sender, System.EventArgs e)
		{
			string s = DateTime.Now.ToLongTimeString();
			sbPnlTime.Text = s;
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
	        sbPnlText.Text = TextBox1.Text;
		}
	}
}
