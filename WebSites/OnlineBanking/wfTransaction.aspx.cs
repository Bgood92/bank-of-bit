using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BankOfBIT.Models;

/// <summary>
/// wfTransaction class - Handles functionality for the Client web form
/// </summary>
public partial class wfTransaction : System.Web.UI.Page
{
    BankOfBITContext db = new BankOfBITContext();

    /// <summary>
    /// Handles the page load event
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            /*
             * Populating the label controls and binding the drop down lists
             */
            if (!IsPostBack)
            {
                txtAmount.Style.Add("text-align", "right");
                lblAccountNumber.Text = Session["AccountNumber"].ToString();
                lblBalance.Text = Session["Balance"].ToString();

                bindTransactionDropDownList();
                bindAccountDropDownList();
            }
        }
        catch (Exception)
        {
            lblAccountNumber.Text = string.Empty;
            lblErrorException.Text = "Error fetching banking information from the database.";
            lblErrorException.Visible = true;
        }
    }

    /// <summary>
    /// Handles the click event of the btnCompleteTransaction
    /// </summary>
    protected void btnCompleteTransaction_Click(object sender, EventArgs e)
    {
        lblErrorException.Visible = false;
        long accountNumber = int.Parse(lblAccountNumber.Text);
        int accountId = int.Parse(Session["BankAccountId"].ToString());
        double accountBalance = double.Parse(Session["Balance"].ToString().Substring(1));

        try
        {
            //Throw an exception if the text amount entered is greater than the current balance of the bank account
            if (double.Parse(txtAmount.Text) > accountBalance)
            {
                throw new Exception("Error - Insufficient funds.");
            }

            //Create an instance of the WCF Bank Service Reference
            BankServiceReference.TransactionManagerClient clientEndPoint = new BankServiceReference.TransactionManagerClient();

            //Selected value is Bill Payment
            if (ddTransactionType.SelectedIndex == -1 || ddTransactionType.SelectedIndex == 0)
            {
                double? newBalance = clientEndPoint.BillPayment(accountId, double.Parse(txtAmount.Text), "Bill Payment to " + ddAccount.SelectedItem.Text);

                updateBalance(newBalance);
            }
            //Selected value is Transfer
            else if (ddTransactionType.SelectedIndex == 1)
            {
                int toAccountId = int.Parse(ddAccount.SelectedValue);
                double? newBalance = clientEndPoint.Transfer(accountId, toAccountId, double.Parse(txtAmount.Text), "Transfer");

                updateBalance(newBalance);
            }
            else
            {
                throw new Exception("Error - Could not complete transaction");
            }
        }
        catch (Exception ex)
        {
            lblErrorException.Visible = true;
            lblErrorException.Text = ex.Message;
        }
    }
   
    /// <summary>
    /// Handles the Selected Index Changed event
    /// </summary>
    protected void ddTransactionType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddTransactionType.SelectedIndex == -1 || ddTransactionType.SelectedIndex == 0)
        {
            clearDatabindings();
            bindAccountDropDownList();
        }
        else
        {
            int sessionClientId = int.Parse(Session["ClientId"].ToString());
            int accountNumber = int.Parse(lblAccountNumber.Text);
            clearDatabindings();
            ddAccount.DataSource =
                db.BankAccounts.Where(x => x.ClientId == sessionClientId && x.AccountNumber != accountNumber).ToList();
            ddAccount.DataTextField = "AccountNumber";
            ddAccount.DataValueField = "BankAccountId";
            this.DataBind();
        }
    }

    /// <summary>
    /// Binds a data source to the Account drop down list
    /// </summary>
    protected void bindAccountDropDownList()
    {
        ddAccount.DataSource = db.Payees.ToList();
        ddAccount.DataValueField = "PayeeId";
        ddAccount.DataTextField = "Description";
        this.DataBind();
    }

    /// <summary>
    /// Binds a data source to the TransactionType drop down list
    /// </summary>
    protected void bindTransactionDropDownList()
    {
        ddTransactionType.DataSource = db.TransactionTypes.Where
                    (x => x.Description == "Bill Payment" || x.Description == "Transfer").ToList();
        ddTransactionType.DataValueField = "TransactionTypeId";
        ddTransactionType.DataTextField = "Description";
        this.DataBind();
    }

    /// <summary>
    /// Clears any previous databindings
    /// </summary>
    protected void clearDatabindings()
    {
        ddAccount.DataSource = null;
        ddAccount.DataTextField = null;
        ddAccount.DataValueField = null;
    }

    /// <summary>
    /// Outputs new balance to the balance label
    /// Stores new balance inside a session variable
    /// </summary>
    /// <param name="newBalance">The new balance of the bank account</param>
    private void updateBalance(double? newBalance)
    {
        if (newBalance != null)
        {
            lblBalance.Text = string.Format("{0:c}", newBalance);
            Session["Balance"] = lblBalance.Text;
            txtAmount.Text = string.Empty;
        }
        else
        {
            throw new Exception("Error - Could not complete transaction");
        }
    }
}