using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Biz
{
    public class OrderBO
    {
        public IEnumerable<Order> GetOrders(string custID)
        {
            return Data.OrderDBBase.Create().GetOrders(custID);
        }

        public IEnumerable<OrderDescription> GetOrderDetails(int orderID)
        {
            return Data.OrderDBBase.Create().GetOrderDetails(orderID);
        }
    }
}
