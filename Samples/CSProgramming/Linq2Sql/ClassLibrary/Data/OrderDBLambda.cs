using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;

namespace Data
{
    public class OrderDBLambda : OrderDBBase
    {

        public override IEnumerable<Model.Order> GetOrders(string custID)
        {
            using (NorthwindDataContext context = DataContext)
            {
                return context.Orders.Where(o => o.CustomerID == custID).ToArray<Order>();
            }
        }

        public override IEnumerable<OrderDescription> GetOrderDetails(int orderID)
        {
            //The following query tries to mirror the query in OrderDBLINQ but doesn't leverage data relationships
            //in the object model.  A simplified query is shown below.

            //IEnumerable<OrderDescription> orders =
            //    context.Orders.Where(order => order.OrderID == orderID).
            //    Join(context.Shippers, o => o.ShipVia, s => s.ShipperID, 
            //      (o, s) => new { o.OrderID, ShipCompanyName = s.CompanyName }).
            //    Join(context.OrderDetails, o => o.OrderID, od => od.OrderID, 
            //      (o, od) => new {o.ShipCompanyName, od.ProductID, od.Quantity, od.UnitPrice }).
            //    Join(context.Products, od => od.ProductID, p => p.ProductID, 
            //      (OrderDetails, p) => new { OrderDetails, p.ProductName, p.SupplierID }).
            //    Join(context.Suppliers, p => p.SupplierID, s => s.SupplierID, 
            //      (OrderData, s) => new { OrderData, SupplierName = s.CompanyName}).
            //    Select(o => new OrderDescription
            //    {
            //        Product = o.OrderData.ProductName,
            //        Quantity = o.OrderData.OrderDetails.Quantity,
            //        ShipperName = o.OrderData.OrderDetails.ShipCompanyName,
            //        Total = o.OrderData.OrderDetails.Quantity * o.OrderData.OrderDetails.UnitPrice,
            //        UnitPrice = o.OrderData.OrderDetails.UnitPrice,
            //        SupplierName = o.SupplierName
            //    });

            using (NorthwindDataContext context = DataContext)
            {
                IEnumerable<OrderDescription> orders =
                  context.Orders.Where(order => order.OrderID == orderID).
                  Join(context.OrderDetails, o => o.OrderID, od => od.OrderID,
                  (o, od) => new
                  {
                      ShipCompanyName = o.Shipper.CompanyName,
                      od.ProductID,
                      ProductName = od.Product.ProductName,
                      Quantity = od.Quantity,
                      UnitPrice = od.UnitPrice,
                      SupplierName = od.Product.Supplier.CompanyName
                  }).

                             Select(o => new OrderDescription
                             {
                                 Product = o.ProductName,
                                 Quantity = o.Quantity,
                                 ShipperName = o.ShipCompanyName,
                                 Total = o.Quantity * o.UnitPrice,
                                 UnitPrice = o.UnitPrice,
                                 SupplierName = o.SupplierName
                             }).ToArray<OrderDescription>();
                return orders;
            }
        }
    }
}
