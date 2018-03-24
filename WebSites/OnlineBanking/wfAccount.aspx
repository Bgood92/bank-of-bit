<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfAccount.aspx.cs" Inherits="wfAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Client:"></asp:Label>
    &nbsp;
    <asp:Label ID="lblClient" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Account Number:"></asp:Label>
    &nbsp;
    <asp:Label ID="lblAccountNumber" runat="server" Text="Label"></asp:Label>
    &nbsp;
    <asp:Label ID="Label3" runat="server" Text="Balance:"></asp:Label>
    &nbsp;
    <asp:Label ID="lblBalance" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:GridView ID="gvTransaction" runat="server" AutoGenerateColumns="False" 
        style="margin-top: 0px" Width="435px">
        <Columns>
            <asp:BoundField DataField="DateCreated" DataFormatString="{0:d}" 
                HeaderText="Date" />
            <asp:BoundField DataField="TransactionType.Description" 
                HeaderText="Transaction Type" />
            <asp:BoundField DataField="Deposit" DataFormatString="{0:c}" 
                HeaderText="Amount In">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Withdrawal" DataFormatString="{0:c}" 
                HeaderText="Amount Out">
            <ItemStyle HorizontalAlign="Right" />
            </asp:BoundField>
            <asp:BoundField DataField="Notes" HeaderText="Details" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:LinkButton ID="lnkTransaction" runat="server" 
        onclick="lnkTransaction_Click">Pay Bills and Transfer Funds</asp:LinkButton>
    <br />
    <br />
    <asp:Label ID="lblErrorException" runat="server" 
        Text="To display error/exception messages" Visible="False" ForeColor="Red"></asp:Label>
    </asp:Content>

