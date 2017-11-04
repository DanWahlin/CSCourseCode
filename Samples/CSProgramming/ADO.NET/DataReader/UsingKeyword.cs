using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace ADO.NET.DataReader
{
    class UsingKeyword
    {
        public static void Main()
        {
            string connString = ConfigurationManager.ConnectionStrings["NorthwindSqlExpress"].ConnectionString;
            string sql = "SELECT * FROM Customers";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {  //Read through first results in batch
                        Console.WriteLine(reader["CustomerID"] + ", " +
                            reader["ContactName"]);
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
