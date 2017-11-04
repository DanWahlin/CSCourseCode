using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DBProviderFactoriesLab
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            PeopleList authors = AuthorsDB.GetAuthors();
            BindingSource bs = new BindingSource();
            bs.DataSource = authors;
            gvAuthors.DataSource = bs;
        }
    }
}