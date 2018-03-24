using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BankOfBIT.Models;

/// <summary>
/// wfClient class - Handles functionality for the Client web form
/// </summary>
public partial class wfClient : System.Web.UI.Page
{
    BankOfBITContext db = new BankOfBITContext();
    
    /// <summary>
    /// Handles the page load event of the form
    /// </summary>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                //Create an instance of the external web service
                net.webservicex.www.CurrencyConvertor currencyConverter = new net.webservicex.www.CurrencyConvertor();

                //Display the current exchange rate
                lblExchangeRate.Text = string.Format("The exchange rate between Canada and the United States is currently {0}", 
                    currencyConverter.ConversionRate(net.webservicex.www.Currency.USD, net.webservicex.www.Currency.CAD));

                long clientNumber = long.Parse(Page.User.Identity.Name);

                Client client = db.Clients.Where(x => x.ClientNumber == clientNumber).SingleOrDefault();

                lblClient.Text = client.FullName;

                int clientId = client.ClientId;

                Session["ClientId"] = clientId;
                Session["FullName"] = lblClient.Text;

                IQueryable<BankAccount> query = db.BankAccounts.Where(x => x.ClientId == clientId);

                gvClient.DataSource = query.ToList();

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
    /// Handles the Selected Index Changed event
    /// </summary>
    protected void gvClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        long accountNumber = long.Parse(gvClient.Rows[gvClient.SelectedIndex].Cells[1].Text);

        //Sets the value of the Account Number column to a session variable
        Session["AccountNumber"] = accountNumber;

        //Sets the value of the Balance column to a session variable
        Session["Balance"] = gvClient.Rows[gvClient.SelectedIndex].Cells[3].Text;

        Session["BankAccountId"] = db.BankAccounts.Where(x => x.AccountNumber == accountNumber).Select(x => x.BankAccountId);

        Server.Transfer("wfAccount.aspx");
    }
}