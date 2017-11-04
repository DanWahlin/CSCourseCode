using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsForms
{
	/// <summary>
	/// Summary description for FileDialogDemo.
	/// </summary>
	public partial class FileDialogDemo : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FileDialogDemo()
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
			// FileDialogDemo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(264, 181);
			this.Name = "FileDialogDemo";
			this.Text = "FileDialog Demonstration";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FileDialogDemo_MouseDown);
		}
		#endregion

		private void FileDialogDemo_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "JPEG files (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
				"BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*";
			ofd.FilterIndex = 2;
			if (ofd.ShowDialog() == DialogResult.OK)
			{
				string msg = String.Format("{0} selected", ofd.FileName);
				MessageBox.Show(msg, "FileDialog Demo", 
					MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		[STAThread]
		static void Main() 
		{
			Application.Run(new FileDialogDemo());
		}
	}
}
