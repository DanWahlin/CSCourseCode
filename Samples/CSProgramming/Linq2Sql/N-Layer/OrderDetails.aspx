<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderDetails.aspx.cs" Inherits="OrderDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Order Details</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2>Order Details</h2>
        
    </div>
    <strong>Order Number:</strong> <asp:Label ID="lblOrderNumber" runat="server" />
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
        CellPadding="3" DataSourceID="odsOrderDetails" GridLines="Vertical" Width="600px">
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <Columns>
            <asp:BoundField DataField="ShipperName" HeaderText="ShipperName" 
                SortExpression="ShipperName" />
            <asp:BoundField DataField="Product" HeaderText="Product" 
                SortExpression="Product" />
            <asp:BoundField DataField="Total" DataFormatString="{0:c}" HeaderText="Total" 
                SortExpression="Total" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" 
                SortExpression="Quantity" />
            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" DataFormatString="{0:c}" 
                SortExpression="UnitPrice" />
            <asp:BoundField DataField="SupplierName" HeaderText="SupplierName" 
                SortExpression="SupplierName" />
        </Columns>
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="#DCDCDC" />
    </asp:GridView>
    <asp:ObjectDataSource ID="odsOrderDetails" runat="server" 
        SelectMethod="GetOrderDetails" TypeName="Biz.OrderBO">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="NULL" Name="orderID" 
                QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br /><br />
    <a href="Default.aspx">Back to Customers</a>
    </form>
</body>
</html>
