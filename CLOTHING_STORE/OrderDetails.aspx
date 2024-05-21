<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderDetails.aspx.cs" Inherits="CLOTHING_STORE.OrderDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Order Details</h2>
        <asp:GridView ID="gvOrderDetails" runat="server" AutoGenerateColumns="false" CssClass="table" GridLines="None">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Size" HeaderText="Size" />
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-muted"></asp:Label>
    </div>
</asp:Content>
