using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Data
{
    public class CustomerDBSprocs : CustomerDBBase
    {

        #region Get Methods

        public override Customer GetCustomer(string custID)
        {
            using (NorthwindDataContext context = DataContext)
            {
                return context.ap_GetCustomer(custID).SingleOrDefault<Customer>();
            }
        }

        public override int GetCustomerOrdersCount(string custID)
        {
            using (NorthwindDataContext context = DataContext)
            {
                return (int)(from c in context.ap_GetCustomerOrdersCount(custID)
                             select c.Count).SingleOrDefault<int?>();
            }
        }

        public override IEnumerable<Customer> GetCustomers()
        {
            using (NorthwindDataContext context = DataContext)
            {
                return context.ap_GetCustomers().ToArray<Customer>();
            }
        }

        public override IEnumerable<Customer> GetCustomersByCountry(string country)
        {
            using (NorthwindDataContext context = DataContext)
            {
                return context.ap_GetCustomersByCountry(country).ToArray<Customer>();
            }
        }

        public override IEnumerable<string> GetCountries()
        {
            using (NorthwindDataContext context = DataContext)
            {
                IEnumerable<string> countries = (from c in context.ap_GetCountries()
                                                select c.Country).ToArray<string>();
                return countries;
            }
        }

        #endregion

        #region Update Methods

        public override OperationStatus UpdateCustomer(Customer cust)
        {
            NorthwindDataContext context = null;
            try
            {
                context = DataContext;
                context.ap_UpdateCustomer(
                   cust.CustomerID,
                   cust.CompanyName,
                   cust.ContactName,
                   cust.ContactTitle,
                   cust.Address,
                   cust.City,
                   cust.Region,
                   cust.PostalCode,
                   cust.Country,
                   cust.Phone,
                   cust.Fax);
            }
            catch (Exception exp)
            {
                return new OperationStatus(false, exp.Message, exp);
            }
            finally
            {
                if (context != null) context.Dispose();
            }
            return new OperationStatus(true, null, null);
        }

        #endregion

        #region Delete Methods

        public override OperationStatus DeleteCustomer(Customer cust)
        {
            NorthwindDataContext context = null;
            try
            {
                context = DataContext;
                context.ap_DeleteCustomer(cust.CustomerID);
            }
            catch (Exception exp)
            {
                return new OperationStatus(false, exp.Message, exp);
            }
            finally
            {
                if (context != null) context.Dispose();
            }
            return new OperationStatus(true, null, null);
        }

        #endregion

        #region Insert methods

        public override OperationStatus InsertCustomer(Customer cust)
        {
            NorthwindDataContext context = null;
            try
            {
                context = DataContext;
                context.ap_InsertCustomer(
                    cust.CustomerID,
                    cust.CompanyName,
                    cust.ContactName,
                    cust.ContactTitle,
                    cust.Address,
                    cust.City,
                    cust.Region,
                    cust.PostalCode,
                    cust.Country,
                    cust.Phone,
                    cust.Fax);
            }
            catch (Exception exp)
            {
                return new OperationStatus(false, exp.Message, exp);
            }
            finally
            {
                if (context != null) context.Dispose();
            }
            return new OperationStatus(true, null, null);
        }

        #endregion

    }
}
