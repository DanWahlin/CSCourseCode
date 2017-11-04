using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Data
{
    public class OrderDBSprocs : OrderDBBase
    {
        public override IEnumerable<Order> GetOrders(string custID)
        {
            using (NorthwindDataContext context = DataContext)
            {
                return context.ap_GetOrdersByCustomerID(custID).ToArray<Order>();
            }
        }

        public override IEnumerable<OrderDescription> GetOrderDetails(int orderID)
        {
            using (NorthwindDataContext context = DataContext)
            {
                return context.ap_GetOrderDetailsByOrderID(orderID).ToArray<OrderDescription>();
            }
        }
    }
}
