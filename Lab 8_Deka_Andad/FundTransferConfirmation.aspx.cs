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
        // Get sessions from last 2 pages to display confirmation info

        string selectedTransferor = Session["SelectedTransferor"].ToString();

        string selectedAccountFrom = Session["rbtnAccount"].ToString();

        string transferedAmount = Session["TransferOutAmount"].ToString();

        string selectedTransferee = Session["SelectedTransferee"].ToString();

        string selectedAccountTo = Session["rbtnAccountTo"].ToString();

        foreach (Customer customer in Customer.GetAllCustomers())
        {
            // Display Transferor info
            if (customer.Id.ToString() == selectedTransferor.ToString())
            {
                transferorName.Text += customer.ToString();
                transferorAccount.Text += selectedAccountFrom.ToString();
                transferorAmount.Text += transferedAmount.ToString();                
            }
            // Display Transferee info
            else if (customer.Id.ToString() == selectedTransferee.ToString())
            {
                transfereeName.Text += customer.ToString();
                transfereeAccount.Text += selectedAccountTo.ToString();
            }
        }

    }

    protected void Return_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FundTransferTo.aspx");
    }

    protected void Complete_Click(object sender, EventArgs e)
    {
        // if the user clicks complete, perform the account operations

        // transferred amount
        string transferedAmount = Session["TransferOutAmount"].ToString();

        // convert to double
        double transferOutAmount = double.Parse(transferedAmount);

        // Create a Transaction to withdraw
        Transaction tran = new Transaction(transferOutAmount);

        // transferor
        string selectedTransferor = Session["SelectedTransferor"].ToString();
        // transferor account
        string selectedAccountFrom = Session["rbtnAccount"].ToString();

        // transferee
        string selectedTransferee = Session["SelectedTransferee"].ToString();
        // transferee account
        string selectedAccountTo = Session["rbtnAccountTo"].ToString();

        foreach (Customer customer in Customer.GetAllCustomers())
        {
            // If the Transferor ID matches a customer ID
            if (customer.Id.ToString() == selectedTransferor.ToString())
            {
                // If checking account was selected, withdraw from the account
                if (selectedAccountFrom == customer.Checking.ToString())
                {
                    customer.Checking.Withdraw(tran);

                    // Create a Session of new transferor checking balance
                    Session["TransferorBalance"] = customer.Checking.ToString();
                }
                // Withdraw if saving was selected
                else if (selectedAccountFrom == customer.Saving.ToString())
                {
                    customer.Saving.Withdraw(tran);

                    // Create a Session of new transferor saving balance
                    Session["TransferorBalance"] = customer.Saving.ToString();
                }
            }
            // If the Transferee ID matches a customer ID
            else if (customer.Id.ToString() == selectedTransferee.ToString())
            {
                // Deposit into Transferee Checking
                if (selectedAccountTo == customer.Checking.ToString())
                {
                    customer.Checking.Deposit(tran);

                    // Create a Session of new transferee checking balance
                    Session["TransfereeBalance"] = customer.Checking.ToString();
                }
                // Deposit into Saving
                else if (selectedAccountTo == customer.Saving.ToString())
                {
                    customer.Saving.Deposit(tran);

                    // Create a Session of new transferee saving balance
                    Session["TransfereeBalance"] = customer.Saving.ToString();
                }
            }

        } //End of foreach customer

        // Go to last page
        Response.Redirect("~/FundTransferResult.aspx");
    }

}