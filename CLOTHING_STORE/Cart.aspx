<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="CLOTHING_STORE.Cart" %>
<%@ Import Namespace="System.Data" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Your Shopping Cart</h2>
        <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="false" CssClass="table" GridLines="None" OnRowCommand="gvCart_RowCommand">
            <Columns>
                <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Remove" CssClass="btn btn-danger btn-sm" CommandName="Remove" CommandArgument='<%# Container.DataItemIndex %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <div class="mt-3">
<asp:Button ID="btnCheckout" runat="server" Text="Checkout" CssClass="btn btn-primary" OnClick="Checkout_Click" OnClientClick="return confirmCheckout();" />
            <asp:Label ID="lblEmptyCartMessage" runat="server" Text=""></asp:Label>
        </div>
    </div>

    <script>
        // JavaScript function to confirm checkout before postback
        function confirmCheckout() {
            if (confirm('Are you sure you want to proceed with the checkout?')) {
                __doPostBack('<%= btnCheckout.ClientID %>', ''); // Trigger the server-side click event
            } else {
                return false; // Prevent default form submission
            }
        }
    </script>

</asp:Content>
