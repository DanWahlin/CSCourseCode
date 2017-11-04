using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsForms
{
	/// <summary>
	/// Summary description for MenuDemo.
	/// </summary>
	public class MenuDemo : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.MainMenu MainMenu1;
		internal System.Windows.Forms.MenuItem fileMenu;
		internal System.Windows.Forms.MenuItem fileNewMenuItem;
		internal System.Windows.Forms.MenuItem fileOpenMenuItem;
		internal System.Windows.Forms.MenuItem fileSaveMenuItem;
		internal System.Windows.Forms.MenuItem fileMenuSep1;
		internal System.Windows.Forms.MenuItem fileExitMenuItem;
		internal System.Windows.Forms.MenuItem MenuItem7;
		internal System.Windows.Forms.MenuItem MenuItem8;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MenuDemo()
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
			this.MainMenu1 = new System.Windows.Forms.MainMenu();
			this.fileMenu = new System.Windows.Forms.MenuItem();
			this.fileNewMenuItem = new System.Windows.Forms.MenuItem();
			this.fileOpenMenuItem = new System.Windows.Forms.MenuItem();
			this.fileSaveMenuItem = new System.Windows.Forms.MenuItem();
			this.fileMenuSep1 = new System.Windows.Forms.MenuItem();
			this.fileExitMenuItem = new System.Windows.Forms.MenuItem();
			this.MenuItem7 = new System.Windows.Forms.MenuItem();
			this.MenuItem8 = new System.Windows.Forms.MenuItem();
			// 
			// MainMenu1
			// 
			this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.fileMenu,
																					  this.MenuItem7,
																					  this.MenuItem8});
			// 
			// fileMenu
			// 
			this.fileMenu.Index = 0;
			this.fileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.fileNewMenuItem,
																					 this.fileOpenMenuItem,
																					 this.fileSaveMenuItem,
																					 this.fileMenuSep1,
																					 this.fileExitMenuItem});
			this.fileMenu.Text = "&File";
			// 
			// fileNewMenuItem
			// 
			this.fileNewMenuItem.Index = 0;
			this.fileNewMenuItem.Text = "&New";
			// 
			// fileOpenMenuItem
			// 
			this.fileOpenMenuItem.Index = 1;
			this.fileOpenMenuItem.Text = "&Open...";
			// 
			// fileSaveMenuItem
			// 
			this.fileSaveMenuItem.Index = 2;
			this.fileSaveMenuItem.Text = "&Save...";
			// 
			// fileMenuSep1
			// 
			this.fileMenuSep1.Index = 3;
			this.fileMenuSep1.Text = "-";
			// 
			// fileExitMenuItem
			// 
			this.fileExitMenuItem.Index = 4;
			this.fileExitMenuItem.Text = "E&xit";
			this.fileExitMenuItem.Click += new System.EventHandler(this.fileExitMenuItem_Click);
			// 
			// MenuItem7
			// 
			this.MenuItem7.Index = 1;
			this.MenuItem7.Text = "&Edit";
			// 
			// MenuItem8
			// 
			this.MenuItem8.Index = 2;
			this.MenuItem8.Text = "&View";
			// 
			// MenuDemo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(352, 94);
			this.MaximizeBox = false;
			this.Menu = this.MainMenu1;
			this.Name = "MenuDemo";
			this.Text = "Creating Menus in Windows Forms";
		}
		#endregion

		private void fileExitMenuItem_Click(object sender, System.EventArgs e)
		{
        DialogResult ret = MessageBox.Show("Are you sure you want to exit?", "Menu Demo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (ret == DialogResult.Yes)
            Application.Exit();
		}

		[STAThread]
		static void Main() 
		{
			Application.Run(new MenuDemo());
		}
	}
}
