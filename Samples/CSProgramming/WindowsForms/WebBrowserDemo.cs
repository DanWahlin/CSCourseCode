using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsForms
{
    public partial class WebBrowserDemo : Form
    {
        public WebBrowserDemo()
        {
            InitializeComponent();
        }

        [STAThread]
        public static void Main()
        {
            Application.Run(new WebBrowserDemo());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.webBrowser1.Navigate(this.textBox1.Text);
        }

        private void tslBack_Click(object sender, EventArgs e) {
            this.webBrowser1.GoBack();
        }

        private void tslForward_Click(object sender, EventArgs e) {
            this.webBrowser1.GoForward();
       
        }

        private void tslHome_Click(object sender, EventArgs e) {
            this.webBrowser1.GoHome();
        }

        private void tslRefresh_Click(object sender, EventArgs e) {
            this.webBrowser1.Refresh(WebBrowserRefreshOption.Normal);
        }

        private void WebBrowserDemo_Load(object sender, EventArgs e) {
            this.webBrowser1.GoHome();
        }

    }
}