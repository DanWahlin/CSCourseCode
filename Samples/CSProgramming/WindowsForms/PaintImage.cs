using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsForms
{
	/// <summary>
	/// Summary description for PaintImage.
	/// </summary>
	public class PaintImage : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PaintImage()
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
			// PaintImage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(300, 300);
			this.FormBorderStyle = FormBorderStyle.Fixed3D;
			this.MinimizeBox = false;
			this.MaximizeBox = false;
			this.Name = "PaintImage";
			this.Text = "Drawing Images using GDI+";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintImage_Paint);
		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new PaintImage());
		}

		private void PaintImage_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			Bitmap img = new Bitmap(@"D:\WinNT\winnt256.bmp");
			g.DrawImage(img, new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height));
		}
	}
}
