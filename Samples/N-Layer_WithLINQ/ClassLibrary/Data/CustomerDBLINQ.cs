using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Data
{
    public class CustomerDBLINQ : CustomerDBBase
    {

        #region Get Methods

        public override Model.Customer GetCustomer(string custID)
        {
            using (NorthwindDataContext context = DataContext)
            {
                Customer cust = (from c in context.Customers
                                 where c.CustomerID == custID
                                 select c).SingleOrDefault<Customer>();
                return cust;
            }
        }

        public override int GetCustomerOrdersCount(string custID)
        {
            using (NorthwindDataContext context = DataContext)
            {

                int count = (from c in context.Orders
                             where c.CustomerID == custID
                             select c).Count();
                return count;
            }
        }

        public override IEnumerable<Model.Customer> GetCustomers()
        {
            using (NorthwindDataContext context = DataContext)
            {

                IEnumerable<Customer> custs = (from c in context.Customers
                                              select c).ToArray<Customer>();
                return custs;
            }
        }

        public override IEnumerable<Model.Customer> GetCustomersByCountry(string country)
        {
            using (NorthwindDataContext context = DataContext)
            {

                IEnumerable<Customer> custs = (from c in context.Customers
                                              where c.Country == country
                                              select c).ToArray<Customer>();
                return custs;
            }
        }

        public override IEnumerable<string> GetCountries()
        {
            using (NorthwindDataContext context = DataContext)
            {
                IEnumerable<string> countries = (from c in context.Customers
                                                 select c.Country).Distinct<string>();

                return countries.ToList<string>();
            }
        }

        #endregion

    }
}
