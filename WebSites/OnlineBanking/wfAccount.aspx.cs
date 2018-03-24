using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BankOfBIT.Models;

/// <summary>
/// wfAccount Class - Handles functionality for the Account web form
/// </summary>
public partial class wfAccount : System.Web.UI.Page
{
    BankOfBITContext db = new BankOfBITContext();

    /// <summary>
    /// Handles the page load event of the web page
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                lblClient.Text = Session["FullName"].ToString();

                lblAccountNumber.Text = Session["AccountNumber"].ToString();
                lblBalance.Text = Session["Balance"].ToString();

                long accountNumber = int.Parse(lblAccountNumber.Text);

                IQueryable<BankAccount> bankAccount = db.BankAccounts.Where(x => x.AccountNumber == accountNumber);

                Session["BankAccountId"] = bankAccount.Select(x => x.BankAccountId).SingleOrDefault();

                int bankAccountId = int.Parse(Session["BankAccountId"].ToString());

                gvTransaction.DataSource = db.Transactions.Where(x => x.BankAccountId == bankAccountId).ToList();

                this.DataBind();
            }
        }
        catch (Exception)
        {
            lblClient.Text = string.Empty;
            lblErrorException.Text = "Error fetching banking information from the database.";
            lblErrorException.Visible = true;
        }
    }

    /// <summary>
    /// Handles the lnkTransaction click event of the form
    /// </summary>
    protected void lnkTransaction_Click(object sender, EventArgs e)
    {
        Server.Transfer("wfTransaction.aspx");
    }
}