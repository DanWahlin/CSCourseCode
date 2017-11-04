using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsForms
{
	/// <summary>
	/// Summary description for MessageBox.
	/// </summary>
	public class MsgBoxForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MsgBoxForm()
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
			// 
			// MessageBox
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(264, 181);
			this.Name = "MessageBox";
			this.Text = "Message Box Form";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MessageBox_MouseDown);
			this.Load += new System.EventHandler(this.MessageBox_Load);
		}
		#endregion

		private void MessageBox_Load(object sender, System.EventArgs e)
		{
			System.Windows.Forms.DialogResult result;
			result = System.Windows.Forms.MessageBox.Show("This is a simple message box", 
				"MessageBox Demo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (result == DialogResult.OK)
			{
				// Take action based on the button clicked
			}
		}

		private void MessageBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Windows.Forms.DialogResult result;
			result = System.Windows.Forms.MessageBox.Show(
				"Mouse Clicked at (" + e.X + " ," + e.Y + ")", 
				"MessageBox Demo", MessageBoxButtons.OK, MessageBoxIcon.Question);
			if (result == DialogResult.OK)
			{
				// Take action based on the button clicked
			}
		}

		[STAThread]
		static void Main() 
		{
			Application.Run(new MsgBoxForm());
		}
	}
}
