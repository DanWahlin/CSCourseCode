using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Configuration;
using System.Web;
using Model;

namespace Data
{
    public abstract class CustomerDBBase : DBBase
    {
        //Dynamically creates CustomerDB class (LINQ, Lambda or Sprocs) by reading from web.config file <appSettings>
        public static CustomerDBBase Create()
        {
            string typeString = ConfigurationManager.AppSettings["CustomerDBType"];
            Type dbType = Type.GetType(typeString);
            return (CustomerDBBase)Activator.CreateInstance(dbType);
        }

        #region Get Methods

        public abstract Customer GetCustomer(string custID);

        public abstract int GetCustomerOrdersCount(string custID);

        public abstract IEnumerable<Customer> GetCustomers();

        public abstract IEnumerable<Customer> GetCustomersByCountry(string country);

        public abstract IEnumerable<string> GetCountries();

        #endregion

        #region Update Methods

        public virtual OperationStatus UpdateCustomer(Customer cust)
        {
            NorthwindDataContext context = DataContext;
            try
            {
                context = DataContext;
                context.Customers.Attach(cust, true);
                context.SubmitChanges();
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

        public virtual OperationStatus DeleteCustomer(Customer cust)
        {
            NorthwindDataContext context = null;
            try
            {
                context = DataContext;
                context.Customers.Attach(cust, true);
                context.Customers.DeleteOnSubmit(cust);
                context.SubmitChanges();
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

        public virtual OperationStatus InsertCustomer(Customer cust)
        {
            NorthwindDataContext context = null;
            try
            {
                context = DataContext;
                context.Customers.InsertOnSubmit(cust);
                context.SubmitChanges();
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
