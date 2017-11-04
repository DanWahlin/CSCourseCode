using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Model;

namespace Data
{
    public class OrderDBLINQ : OrderDBBase
    {
        public override IEnumerable<Model.Order> GetOrders(string custID)
        {
            using (NorthwindDataContext context = DataContext)
            {
                IEnumerable<Order> orders = (from o in context.Orders
                                            where o.CustomerID == custID
                                            select o).ToArray<Order>();
                return orders;
            }
        }



        public override IEnumerable<OrderDescription> GetOrderDetails(int orderID)
        {

            //SQL-ish way of doing it that's a little more complex than it should be
            //IEnumerable<OrderDescription> orders =
            //    from o in context.Orders
            //    where o.OrderID == orderID
            //    join s in context.Shippers on o.ShipVia equals s.ShipperID
            //    join od in context.OrderDetails on o.OrderID equals od.OrderID
            //    join p in context.Products on od.ProductID equals p.ProductID
            //    join supplier in context.Suppliers on p.SupplierID equals supplier.SupplierID
            //    let total = od.Quantity * od.UnitPrice
            //    select new OrderDescription
            //    {
            //        Product = p.ProductName,
            //        Quantity = od.Quantity,
            //        ShipperName = s.CompanyName,
            //        Total = total,
            //        UnitPrice = od.UnitPrice,
            //        SupplierName = supplier.CompanyName
            //    };

            using (NorthwindDataContext context = DataContext)
            {
                IEnumerable<OrderDescription> orderDetails =
                  (from o in context.Orders
                  where o.OrderID == orderID
                  from od in o.OrderDetails
                  let total = od.Quantity * od.UnitPrice
                  select new OrderDescription
                  {
                      Product = od.Product.ProductName,
                      Quantity = od.Quantity,
                      ShipperName = o.Shipper.CompanyName,
                      Total = total,
                      UnitPrice = od.UnitPrice,
                      SupplierName = od.Product.Supplier.CompanyName
                  }).ToArray<OrderDescription>();
                return orderDetails;
            }
        }

    }
}
