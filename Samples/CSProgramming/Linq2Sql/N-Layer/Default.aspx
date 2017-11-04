<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>N-Layer using LINQ Example</title>
    <style type="text/css">
        th { text-align:left;vertical-align:top;background-color:Navy;color:White;font-family:Arial;}
        td { text-align:left;vertical-align:top;font-family:Arial;font-size:10pt;padding:2px 4px 4px 2px;}
        .tdControls { }
        input 		
        {
        	border:1px solid black;
		    font-size: 10pt; 
		    font-family: arial; 
		    color:#000000;	
		    width:100px;
		    background:white;
		}
		.odd {background-color:#eaeaea;}
		.even {}
    </style>
</head>
<body>
    <form runat="server">
        <asp:ScriptManager id="sm" runat="server" EnablePartialRendering="true" />
        <h2>N-Layer Example (Model, Data, Business, Presentation) using LINQ</h2>
        <div style="width:75%;border:1px solid black;background-color:#eaeaea;padding:4px 4px 4px 4px;">
            This example demonstrates how LINQ to SQL can be used in an N-Layer environment 
            to query a SQL database. The techniques demonstrated include using LINQ syntax, 
            Lambda expressions and LINQ with stored procedures. The technique used to query 
            the database can be changed in web.config.<br />
           </div>
        <p>
            <strong>Select a Country:</strong>
            <asp:DropDownList ID="ddCountries" runat="server" DataSourceID="odsCountries" AutoPostBack="True">
            </asp:DropDownList>
            <asp:ObjectDataSource ID="odsCountries" runat="server" SelectMethod="GetCountries"
                TypeName="Biz.CustomerBO"></asp:ObjectDataSource>
        </p>
        <p>
            <asp:UpdatePanel ID="up" runat="server">
                <ContentTemplate>                        
                    <asp:Label ID="lblError" runat="server" ForeColor="Red" EnableViewState="false" />
                    <br />
                    <asp:ListView ID="lvCustomers" runat="server" 
                        DataSourceID="odsCustomersByCountry" 
                        DataKeyNames="CustomerID,DateTimeStamp" 
                        onitemcreated="lvCustomers_ItemCreated" onitemcommand="lvCustomers_ItemCommand">
                        <LayoutTemplate>
                            <table style="width:1000px;" cellpadding="4">
                                <tr>
                                    <td>
                                        <table style="width:100%;">
                                            <tr>
                                                <th style="background-color:White;width:12%;"></th>
                                                <th style="width:11%;">ID</th>
                                                <th style="width:11%;">Company</th>
                                                <th style="width:11%;">Name</th>
                                                <th style="width:11%;">Title</th>
                                                <th style="width:11%;">Address</th>
                                                <th style="width:11%;">City</th>
                                                <th style="width:11%;">Country</th>
                                                <th style="width:11%;">Orders</th>
                                            </tr>
                                            <tr ID="itemPlaceholder" runat="server"></tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr runat="server">
                                    <td runat="server">
                                        <asp:LinkButton ID="lbNew" runat="server" Text="New Record" OnClick="lbButton_Click" />
                                    </td>
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr class='<%# (Container.DataItemIndex % 2 == 0)?"even":"odd" %>'>
                                <td class="tdControls">
                                    <asp:LinkButton ID="EditButton" CommandName="Edit" runat="server" Text="Edit"></asp:LinkButton>
                                    <asp:LinkButton ID="DeleteButton"  OnClientClick="return confirm('Delete Record?');" CommandName="Delete" CommandArgument='<%# Eval("CustomerID")%>' runat="server" Text="Delete"></asp:LinkButton>
                                </td>
                                <td>
                                    <%# Eval("CustomerID") %>
                                </td>
                                <td>
                                    <%# Eval("CompanyName") %>
                                </td>
                                <td>
                                    <%# Eval("ContactName") %>
                                </td>
                                <td>
                                    <%# Eval("ContactTitle") %>
                                </td>
                                <td>
                                    <%# Eval("Address") %>
                                </td>
                                <td>
                                    <%# Eval("City") %>
                                </td>
                                <td>
                                    <%# Eval("Country") %>
                                </td>
                                <td>
                                    <asp:LinkButton ID="lbOrders" runat="server" Text="Orders" CommandName="ViewOrders" CommandArgument='<%#Eval("CustomerID") %>' />
                                </td>
                            </tr>
                            <tr id="trOrders" runat="server" visible="false">
                                <td>&nbsp;</td>
                                <td colspan="8">
                                    <asp:GridView id="gvOrders" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
                                        CellPadding="3" ForeColor="Black" 
                                        GridLines="Vertical" Width="500px" EnableViewState="false">
                                            <FooterStyle BackColor="#CCCCCC" />
                                            <Columns>
                                                <asp:BoundField DataField="OrderID" HeaderText="OrderID" 
                                                    SortExpression="OrderID" />
                                                <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" 
                                                    SortExpression="OrderDate" HtmlEncode="false" DataFormatString="{0:d}" />
                                                <asp:BoundField DataField="RequiredDate" HeaderText="RequiredDate" 
                                                    SortExpression="RequiredDate"  HtmlEncode="false" DataFormatString="{0:d}" />
                                                <asp:BoundField DataField="ShippedDate" HeaderText="ShippedDate" 
                                                    SortExpression="ShippedDate" HtmlEncode="false" DataFormatString="{0:d}" />
                                                <asp:HyperLinkField DataNavigateUrlFormatString="OrderDetails.aspx?id={0}" 
                                                     DataNavigateUrlFields="OrderID" Text="More Details" />
                                            </Columns>
                                            <AlternatingRowStyle BackColor="#eaeaea" />                                        
                                     </asp:GridView>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <InsertItemTemplate>
                            <tr style="background-color:#eaeaea;">
                                <td colspan="9">
                                    <table width="40%">
                                        <tr>
                                            <td>Customer ID:</td>
                                            <td>
                                                <asp:TextBox ID="CustomerID" runat="server" 
                                                Text='<%# Bind("CustomerID") %>' />
                                                <asp:RequiredFieldValidator ID="valCustomerID" runat="server" ControlToValidate="CustomerID" ErrorMessage="*"  />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Company Name:</td>
                                            <td>
                                                <asp:TextBox ID="CompanyName" runat="server" Text='<%# Bind("CompanyName") %>' />
                                                <asp:RequiredFieldValidator ID="valCompanyName" runat="server" ControlToValidate="CompanyName" ErrorMessage="*"  />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Contact Name</td>                                
                                            <td>
                                                <asp:TextBox ID="ContactName" runat="server" 
                                                    Text='<%# Bind("ContactName") %>' />
                                                <asp:RequiredFieldValidator ID="valContactName" runat="server" ControlToValidate="ContactName" ErrorMessage="*"  />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Contact Title:</td>
                                            <td>
                                                <asp:TextBox ID="ContactTitle" runat="server" 
                                                    Text='<%# Bind("ContactTitle") %>' />
                                                <asp:RequiredFieldValidator ID="valContactTitle" runat="server" ControlToValidate="ContactTitle" ErrorMessage="*"  />
                                            </td>                            
                                        </tr>
                                        <tr>
                                            <td>Address:</td>
                                            <td>
                                                <asp:TextBox ID="Address" runat="server" Text='<%# Bind("Address") %>' />
                                                <asp:RequiredFieldValidator ID="valAddress" runat="server" ControlToValidate="Address" ErrorMessage="*"  />
                                            </td>                                
                                        </tr>
                                        <tr>
                                            <td>City:</td>
                                            <td>
                                                <asp:TextBox ID="City" runat="server" Text='<%# Bind("City") %>' />
                                                <asp:RequiredFieldValidator ID="valCity" runat="server" ControlToValidate="City" ErrorMessage="*"  />
                                            </td>                                
                                        </tr>
                                        <tr>
                                            <td>Country:</td>
                                            <td>
                                                <asp:DropDownList ID="Country" runat="server"  />
                                            </td>                            
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:LinkButton ID="InsertButton" runat="server" CommandName="Insert" 
                                                   Text="Insert" />
                                                <asp:LinkButton ID="CancelButton" runat="server" CommandName="CancelInsert" 
                                                   Text="Cancel" CausesValidation="false" />
                                            </td>
                                        </tr>                        
                                    </table> 
                                </td>
                            </tr>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <tr style="background-color:yellow">
                                <td class="tdControls">
                                    <asp:LinkButton ID="UpdateButton" runat="server" CommandName="Update" 
                                        Text="Update" /><br />
                                    <asp:LinkButton ID="CancelButton" runat="server" CommandName="Cancel" 
                                        Text="Cancel" />
                                </td>
                                <td>
                                    <asp:Label ID="CustomerID" runat="server" 
                                        Text='<%# Bind("CustomerID") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="CompanyName" runat="server" 
                                        Text='<%# Bind("CompanyName") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="ContactName" runat="server" 
                                        Text='<%# Bind("ContactName") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="ContactTitle" runat="server" 
                                        Text='<%# Bind("ContactTitle") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="Address" runat="server" Text='<%# Bind("Address") %>' />
                                </td>
                                <td>
                                    <asp:TextBox ID="City" runat="server" Text='<%# Bind("City") %>' />
                                </td>
                                <td>
                                    <asp:DropDownList ID="Country" runat="server" DataSourceID="odsCountries" SelectedValue='<%# Bind("Country") %>' />
                                </td>   
                                <td>&nbsp;</td> 
                            </tr>
                        </EditItemTemplate>
                    </asp:ListView>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="ddCountries" EventName="SelectedIndexChanged" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:ObjectDataSource ID="odsCustomersByCountry" runat="server" SelectMethod="GetCustomersByCountry"
                TypeName="Biz.CustomerBO" OldValuesParameterFormatString="original_{0}" 
                DataObjectTypeName="Model.Customer" UpdateMethod="UpdateCustomer" 
                DeleteMethod="DeleteCustomer" ondeleted="odsCustomersByCountry_OperationPerformed" 
                InsertMethod="InsertCustomer" 
                oninserted="odsCustomersByCountry_OperationPerformed" 
                oninserting="odsCustomersByCountry_Inserting">
                <SelectParameters>
                    <asp:ControlParameter ControlID="ddCountries" Name="Country" PropertyName="SelectedValue"
                        Type="String" DefaultValue="NULL" />
                </SelectParameters>                
            </asp:ObjectDataSource>

    </form>
</body>
</html>
