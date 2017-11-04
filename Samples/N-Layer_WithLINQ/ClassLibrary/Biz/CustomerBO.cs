using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Model;

namespace Biz
{
    /// <summary>
    /// Summary description for BAL
    /// </summary>
    public class CustomerBO
    {

        #region Get Methods

        public Customer GetCustomer(string custID)
        {
            return Data.CustomerDBBase.Create().GetCustomer(custID);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return Data.CustomerDBBase.Create().GetCustomers();
        }

        public IEnumerable<Customer> GetCustomersByCountry(string country)
        {
            return Data.CustomerDBBase.Create().GetCustomersByCountry(country);
        }

        public IEnumerable<string> GetCountries()
        {
            IEnumerable<string> countries = Data.CustomerDBBase.Create().GetCountries();
            if (countries == null || countries.Count() == 0)
            {
                return new string[] { "USA" };
            }
            return countries;
        }

        #endregion

        #region Update Methods

        public void UpdateCustomer(Customer cust)
        {
            ApplyRules(cust);
            OperationStatus opStatus = Data.CustomerDBBase.Create().UpdateCustomer(cust);
            if (!opStatus.Status)
            {
                throw new ApplicationException(String.Format("Error occurred in Biz.CustomerRules.UpdateCustomer: {0}", opStatus.Exception.Message));
            }
        }

        #endregion

        #region Delete Methods

        public static void DeleteCustomer(Customer cust)
        {
            int count = Data.CustomerDBBase.Create().GetCustomerOrdersCount(cust.CustomerID);
            if (count == 0)
            {
                OperationStatus opStatus = Data.CustomerDBBase.Create().DeleteCustomer(cust);
                if (!opStatus.Status)
                {
                    throw new ApplicationException(String.Format("Error occurred in Biz.CustomerRules.DeleteCustomer: {0}", opStatus.Exception.Message));
                }
            }
            else
            {
                throw new ApplicationException(String.Format("Customer has {0} orders and therefore cannot be deleted!",count));
            }
        }

        #endregion

        #region Insert Methods

        public void InsertCustomer(Customer cust)
        {
            ApplyRules(cust);
            OperationStatus opStatus = Data.CustomerDBBase.Create().InsertCustomer(cust);
            if (!opStatus.Status)
            {
                throw new ApplicationException(String.Format("Error occurred in Biz.CustomerRules.InsertCustomer: {0}", opStatus.Exception.Message));
            }

        }

        #endregion

        #region Business Rules

        private static void ApplyRules(Customer cust)
        {
            //Business rule says that all sales titles must 
            //be stored as "Sales Staff" in database
            if (!String.IsNullOrEmpty(cust.ContactTitle) && cust.ContactTitle.ToLower().Contains("sales"))
            {
                cust.ContactTitle = "Sales Staff";
            }

            if (String.IsNullOrEmpty(cust.Region))
            {
                cust.Region = "No Region";
            }

            cust.Phone = ConvertPhoneToNumeric(cust.Phone);
            cust.Fax = ConvertPhoneToNumeric(cust.Fax);
           
        }

        private static string ConvertPhoneToNumeric(string phone)
        {
            if (String.IsNullOrEmpty(phone)) return null;
            StringBuilder sb = new StringBuilder();
            foreach (char c in phone)
            {
                if (char.IsNumber(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        #endregion
                
    }
}
