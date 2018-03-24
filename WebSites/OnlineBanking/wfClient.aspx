<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="wfClient.aspx.cs" Inherits="wfClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="Label" runat="server" Text="Client:"></asp:Label>
&nbsp;
<asp:Label ID="lblClient" runat="server" CssClass="bold">label</asp:Label>
    <br />
    <br />
<asp:GridView ID="gvClient" runat="server" AutoGenerateColumns="False" 
    Width="403px" onselectedindexchanged="gvClient_SelectedIndexChanged" 
        Height="210px">
    <Columns>
        <asp:CommandField ShowSelectButton="True" />
        <asp:BoundField DataField="AccountNumber" HeaderText="Account Number" />
        <asp:BoundField DataField="Notes" HeaderText="Account Notes" />
        <asp:BoundField DataField="Balance" DataFormatString="{0:c}" 
            HeaderText="Balance">
        <ItemStyle HorizontalAlign="Right" />
        </asp:BoundField>
    </Columns>
</asp:GridView>
    <br />
<asp:Label ID="lblExchangeRate" runat="server" 
    Text="To eventually display exchange rate"></asp:Label>
    <br />
<asp:Label ID="lblErrorException" runat="server" 
    Text="To display error/exception messages" Visible="False" ForeColor="Red"></asp:Label>
</asp:Content>

