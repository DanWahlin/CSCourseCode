using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using Model;

namespace Data
{
    public abstract class OrderDBBase : DBBase
    {
        //Dynamically creates OrderDB class (LINQ, Lambda or Sprocs) by reading from web.config file <appSettings>
        public static OrderDBBase Create()
        {
            string typeString = ConfigurationManager.AppSettings["OrderDBType"];
            Type dbType = Type.GetType(typeString);
            return (OrderDBBase)Activator.CreateInstance(dbType);
        }

        public abstract IEnumerable<Order> GetOrders(string custID);

        public abstract IEnumerable<OrderDescription> GetOrderDetails(int orderID);
    }
}
