using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsForms
{
	/// <summary>
	/// Summary description for GDIplus.
	/// </summary>
	public class GDIplus : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GDIplus()
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
			// GDIplus
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(118, 115);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "GDIplus";
			this.Text = "GDI+ Demo";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.GDIplus_Paint);
		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new GDIplus());
		}

		private void GDIplus_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			Graphics g = e.Graphics;
			// draw left eye
			g.DrawEllipse(Pens.Blue, new Rectangle(10, 10, 30, 30));
			g.FillEllipse(Brushes.Blue, new Rectangle(15, 15, 10, 10));
			// draw right eye
			g.DrawEllipse(Pens.Blue, new Rectangle(60, 10, 30, 30));
			g.FillEllipse(Brushes.Blue, new Rectangle(65, 15, 10, 10));
			// draw nose
			g.FillEllipse(Brushes.Green, new Rectangle(35, 40, 30, 30));
			// draw mouth
			Point[] pts = {new Point(10, 70), new Point(20, 80), new Point(30, 90), 
				new Point(45, 100), new Point(70, 90), new Point(80, 80), new Point(90, 70)};
			g.DrawCurve(Pens.Red, pts);
		
		}
	}
}
