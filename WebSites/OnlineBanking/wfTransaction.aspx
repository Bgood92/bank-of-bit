<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfTransaction.aspx.cs" Inherits="wfTransaction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Account Number: "></asp:Label>
    <asp:Label ID="lblAccountNumber" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Balance: "></asp:Label>
    <asp:Label ID="lblBalance" runat="server" Text="Label"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Transaction Type: "></asp:Label>
    <asp:DropDownList ID="ddTransactionType" runat="server" AutoPostBack="True" 
        onselectedindexchanged="ddTransactionType_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Amount: "></asp:Label>
    <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
    <asp:RangeValidator ID="amountRangeValidator" runat="server" 
        ControlToValidate="txtAmount" 
        ErrorMessage="*Must be a numeric value between 0.01 and 10,000.00" 
        ForeColor="Red" Type="Double" MaximumValue="10000.00" MinimumValue="0.01"></asp:RangeValidator>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="To: "></asp:Label>
    <asp:DropDownList ID="ddAccount" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnCompleteTransaction" runat="server" 
        onclick="btnCompleteTransaction_Click" Text="Complete Transaction" />
    <br />
    <br />
    <asp:Label ID="lblErrorException" runat="server" ForeColor="Red" 
        Text="To display error/exception messages" Visible="False"></asp:Label>
</asp:Content>

