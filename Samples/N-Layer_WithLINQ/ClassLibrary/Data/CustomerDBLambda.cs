using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Data
{
    public class CustomerDBLambda : CustomerDBBase
    {

        #region Get Methods

        public override Model.Customer GetCustomer(string custID)
        {
            using (NorthwindDataContext context = DataContext)
            {
                return context.Customers.Where(c => c.CustomerID == custID).SingleOrDefault<Customer>();
            }
        }

        public override int GetCustomerOrdersCount(string custID)
        {
            using (NorthwindDataContext context = DataContext)
            {
                return context.Orders.Where(c => c.CustomerID == custID).Count();
            }
        }

        public override IEnumerable<Model.Customer> GetCustomers()
        {
            using (NorthwindDataContext context = DataContext)
            {
                return context.Customers.ToArray<Customer>();
            }
        }

        public override IEnumerable<Model.Customer> GetCustomersByCountry(string country)
        {
            using (NorthwindDataContext context = DataContext)
            {
                return context.Customers.Where(c => c.Country == country).ToArray<Customer>();
            }
        }

        public override IEnumerable<string> GetCountries()
        {
            using (NorthwindDataContext context = DataContext)
            {
                return context.Customers.Select(c => c.Country).Distinct<string>().ToArray<string>();
            }
        }

        #endregion
    }
}
