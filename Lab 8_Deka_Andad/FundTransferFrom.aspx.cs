using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FundTransferFrom : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            // List customer options on initial display using GetAllCustomers() method

            foreach (Customer customer in Customer.GetAllCustomers())
            {
                // Create a drop down option for each transferor using ToString Method from Customer Class
                // Each item in drop down list will also have an id
                ListItem item = new ListItem(customer.ToString(), customer.Id.ToString());
                drpTransferor.Items.Add(item);
            }
        }
        
        // Display Account Balances when radio btn selected
        foreach (ListItem selectedTransferor in drpTransferor.Items)
        {
            if (selectedTransferor.Selected)
            {
                foreach (Customer customerName in Customer.GetAllCustomers())
                {
                    if (customerName.ToString() == selectedTransferor.Text)
                    {
                        RadioButtonListAccounts.Items[0].Text = customerName.Checking.ToString();
                        RadioButtonListAccounts.Items[1].Text = customerName.Saving.ToString();
                    }
                }
            }
        } // End of foreach
           
    } // End of Page_Load


    protected void RadioButtonListAccounts_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectedValue = drpTransferor.SelectedValue;

        // Create a Session of selected transferor
        Session["SelectedTransferor"] = selectedValue;

        int customerId = int.Parse(selectedValue);

        Customer customerSelected = Customer.GetCustomerById(customerId);

        if (RadioButtonListAccounts.Items[0].Selected)
        {
            // Create a Session of checked radio button
            Session["rbtnAccount"] = customerSelected.Checking.ToString();

            // Max Value for regular customers
            if (customerSelected.Status == CustomerStatus.REGULAR)
            {
                if (customerSelected.Checking.Balance > CheckingAccount.MaxTransferAmount)
                {
                    rvAmount.MaximumValue = CheckingAccount.MaxTransferAmount.ToString();
                }
                else
                {
                    rvAmount.MaximumValue = customerSelected.Checking.Balance.ToString();

                }
            }
            else
            {
                rvAmount.MaximumValue = customerSelected.Checking.Balance.ToString();

            }
        }
        else if (RadioButtonListAccounts.Items[1].Selected)
        {
            // Create a Session of checked radio button
            Session["rbtnAccount"] = customerSelected.Saving.ToString();

            rvAmount.MaximumValue = customerSelected.Saving.Balance.ToString();

        }
    }

    protected void Next_Click(object sender, EventArgs e)
    {
        // Create a Session of entered amount
        Session["TransferOutAmount"] = txtAmountFrom.Text;
        

        // Go to next page when valid;
        Response.Redirect("~/FundTransferTo.aspx");


    } // end of click next btn event
}