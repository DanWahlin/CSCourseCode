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
        IAuthorsRepository _Repository;

        public AuthorViewer()
        {
            InitializeComponent();
            _Repository = new AuthorsRepository();
            gvAuthors.DataSource = _Repository.GetAuthors();
        }

        public static void Main()
        {
            Application.Run(new AuthorViewer());
        }
    }
}