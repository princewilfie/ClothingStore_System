<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="CLOTHING_STORE.Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Your Orders</h2>
        <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="false" CssClass="table" GridLines="None">
            <Columns>
                <asp:BoundField DataField="OrderId" HeaderText="Order ID" />
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Size" HeaderText="Size" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkOrderDetails" runat="server" NavigateUrl='<%# Eval("OrderId", "OrderDetails.aspx?OrderId={0}") %>' Text="View Details"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-muted"></asp:Label>
    </div>
</asp:Content>
