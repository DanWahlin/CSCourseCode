using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;

namespace DBProviderFactoriesLab
{
    public class AuthorsDB
    {
        private static ConnectionStringSettings GetSettings()
        {
            return ConfigurationManager.ConnectionStrings["DBProviderFactoriesLab.DB.PubsConnStr"];
        }

        public static PeopleList GetAuthors()
        {
            ConnectionStringSettings cs = GetSettings();
            DbConnection conn = null;
            DbDataReader reader = null;
            try
            {
                DbProviderFactory f = DbProviderFactories.GetFactory(cs.ProviderName);
                conn = f.CreateConnection();
                conn.ConnectionString = cs.ConnectionString;
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = "GetAuthors";
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                reader = cmd.ExecuteReader();
                return BuildAuthorList(reader);
            }
            catch (Exception exp)
            {
                throw new ApplicationException("Error accessing Database", exp);
            }
            finally
            {
                if (reader != null) reader.Close();
                if (conn != null) conn.Close();
            }
        }

        private static PeopleList BuildAuthorList(DbDataReader reader)
        {
            if (reader != null && reader.HasRows)
            {
                PeopleList authors = new PeopleList();
                Random r = new Random();
                while (reader.Read())
                {
                    Author auth = new Author();
                    auth.ID = reader["au_ID"].ToString();
                    auth.FirstName = reader["au_fname"].ToString();
                    auth.LastName = reader["au_lname"].ToString();
                    auth.Age = r.Next(16,110); //Simulate age
                    auth.Phone = reader["phone"].ToString();
                    auth.Address = reader["address"].ToString();
                    auth.City = reader["city"].ToString();
                    auth.State = reader["state"].ToString();
                    auth.Zip = reader["zip"].ToString();
                    auth.HasContract = bool.Parse(reader["contract"].ToString());
                    authors.AddPerson(auth);
                }
                return authors;
            }
            return null;
        }
    }
}
