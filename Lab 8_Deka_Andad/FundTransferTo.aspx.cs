using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FundTransfer : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            // Get previous session of transferor 
            string selectedTransferor = Session["SelectedTransferor"].ToString();

            foreach (Customer customer in Customer.GetAllCustomers())
            {
                // Create a drop down option without the transferor displayed                
                if (customer.Id.ToString() != selectedTransferor)
                {
                    ListItem item = new ListItem(customer.ToString(), customer.Id.ToString());
                    drpTransferee.Items.Add(item);
                }
            }
        }

        // Display Account balance when radio button is selected
        foreach (ListItem selectedTransferee in drpTransferee.Items)
        {
            if (selectedTransferee.Selected)
            {
                foreach (Customer customerName in Customer.GetAllCustomers())
                {
                    if (customerName.ToString() == selectedTransferee.Text)
                    {
                        RadioButtonList2.Items[0].Text = customerName.Checking.ToString();
                        RadioButtonList2.Items[1].Text = customerName.Saving.ToString();
                    }
                }
            }
        }

    } // End of Page_Load

    protected void btnBack_Click(object sender, EventArgs e)
    {
        // Go to first page
        Response.Redirect("~/FundTransferFrom.aspx");
    }

    protected void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedValue = drpTransferee.SelectedValue;

        // Create a Session of selected transferee
        Session["SelectedTransferee"] = selectedValue;

        int customerId = int.Parse(selectedValue);

        Customer customerSelected = Customer.GetCustomerById(customerId);
        
        if (RadioButtonList2.Items[0].Selected)
        {
            // Create a Session of checked radio button
            Session["rbtnAccountTo"] = customerSelected.Checking.ToString();
           
        }
        else if (RadioButtonList2.Items[1].Selected)
        {
            // Create a Session of checked radio button
            Session["rbtnAccountTo"] = customerSelected.Saving.ToString();
        }
    }
    protected void btnNext_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FundTransferConfirmation.aspx");
    }
}