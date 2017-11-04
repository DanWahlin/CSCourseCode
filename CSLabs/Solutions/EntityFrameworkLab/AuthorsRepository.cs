using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkLab
{
    public interface IAuthorsRepository
    {
        List<Author> GetAuthors();
    }

    public class AuthorsRepository : IAuthorsRepository
    {
        public List<Author> GetAuthors()
        {
            using (var context = new PUBSEntities())
            {
                return context.Authors.OrderBy(a => a.Au_lname).ToList();
            }
        }
    }
}
