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
        // Get Transferor and Transferee Sessions and their Account Balances and Transfer Amount
        string selectedTransferor = Session["SelectedTransferor"].ToString();

        //string selectedAccount = Session["rbtnAccount"].ToString();

        string transferedAmount = Session["TransferOutAmount"].ToString();

        string selectedTransferee = Session["SelectedTransferee"].ToString();

        string transferorAccountBalance = Session["TransferorBalance"].ToString();

        string transfereeAccountBalance = Session["TransfereeBalance"].ToString();

        foreach (Customer customer in Customer.GetAllCustomers())
        {
            // Display Transferor info
            if (customer.Id.ToString() == selectedTransferor.ToString())
            {
                lblTransferredAmount.Text += transferedAmount.ToString();
                lblTransferor.Text += customer.ToString();
                lblAccountFrom.Text += transferorAccountBalance.ToString();
               
            }
            // Display Transferee info
            else if (customer.Id.ToString() == selectedTransferee.ToString())
            {
                lblTransferee.Text += customer.ToString();
                lblAccountTo.Text += transfereeAccountBalance.ToString();
            }

        } 

    }

    protected void Restart_Click(object sender, EventArgs e)
    {
        Response.Redirect("FundTransferFrom.aspx");
    }
}