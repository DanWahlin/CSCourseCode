using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Model;
using Biz;

public partial class _Default : System.Web.UI.Page 
{

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void lvCustomers_ItemCreated(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.InsertItem)
        {
            DropDownList dd = this.lvCustomers.InsertItem.FindControl("Country") as DropDownList;
            if (dd != null)
            {
                //This is how you can get to the actual data when needed (typically in the ItemDataBound rather than ItemCreated)
                //ListViewDataItem dataItem = (ListViewDataItem)e.Item;
                //dd.SelectedValue = ((DataRowView)dataItem.DataItem)["Country"].ToString();
                dd.SelectedValue = this.ddCountries.SelectedValue;
                dd.DataSource = this.odsCountries;
                dd.DataBind();
            }
        }
    }

    protected void lvCustomers_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        switch (e.CommandName.ToLower())
        {
            case "vieworders":
                BindOrders(e.CommandArgument.ToString(),e.Item);
                break;
            case "cancelinsert":
                ClearControls();
                break;
        }
    }

    private void BindOrders(string custID,ListViewItem item)
    {
        LinkButton lb = (LinkButton)item.FindControl("lbOrders");
        lb.Text = (lb.Text == "Orders") ? "Hide Orders" : "Orders";
        HtmlTableRow tr = item.FindControl("trOrders") as HtmlTableRow;
        tr.Visible = !tr.Visible;
        GridView gvOrders = item.FindControl("gvOrders") as GridView;
        if (gvOrders != null)
        {
            if (tr.Visible)
            {
                gvOrders.DataSource = new OrderBO().GetOrders(custID);
                gvOrders.DataBind();
            }
        }
    }

    private void ClearControls()
    {
        lvCustomers.EditIndex = -1;
        lvCustomers.InsertItemPosition = InsertItemPosition.None;
        lvCustomers.FindControl("lbNew").Visible = true;
    }

    protected void odsCustomersByCountry_OperationPerformed(object sender, ObjectDataSourceStatusEventArgs e)
    {
        if (e.Exception != null)
        {
            e.ExceptionHandled = true;
            this.lblError.Text = (e.Exception.InnerException == null) ? e.Exception.Message : e.Exception.InnerException.Message;
        }
        ClearControls();
    }

    protected void odsCustomersByCountry_Inserting(object sender, ObjectDataSourceMethodEventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            //Grab country value from DropDownList control in InsertTemplate
            string country = ((DropDownList)lvCustomers.InsertItem.FindControl("Country")).SelectedValue;
            Customer cust = (Customer)e.InputParameters[0];
            cust.Country = country;
        }
        else
        {
            e.Cancel = true;
            this.lblError.Text = "All fields are required when inserting a record!";
        }
    }

    protected void lbButton_Click(object sender, EventArgs e)
    {
        this.lvCustomers.EditIndex = -1;
        this.lvCustomers.InsertItemPosition = InsertItemPosition.LastItem;
        ((LinkButton)sender).Visible = false;
    }
}
