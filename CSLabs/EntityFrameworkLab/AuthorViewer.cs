using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EntityFrameworkLab
{
    public partial class AuthorViewer : Form
    {
        public AuthorViewer()
        {
            InitializeComponent();
        }

        public static void Main()
        {
            Application.Run(new AuthorViewer());
        }
    }
}