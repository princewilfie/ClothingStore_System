<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="CLOTHING_STORE.Cart" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cart</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body {
            background-color: #f8f9fa; /* Set a light background color */
        }
        .container {
            margin-top: 50px; /* Add some space from the top */
        }
        .cart-header {
            background-color: #007bff; /* Set the header background color */
            color: #fff; /* Set text color to white */
            padding: 10px; /* Add padding */
            margin-bottom: 20px; /* Add some space at the bottom */
        }
        .btn-checkout {
            background-color: #28a745; /* Set the checkout button color */
            border-color: #28a745; /* Set border color */
        }
        .btn-checkout:hover {
            background-color: #218838; /* Change color on hover */
            border-color: #218838; /* Change border color on hover */
        }
        /* Styling for GridView */
        .table-cart {
            width: 100%;
            border-collapse: collapse;
            margin-bottom: 20px;
        }
        .table-cart th,
        .table-cart td {
            padding: 10px;
            border-bottom: 1px solid #dee2e6;
            vertical-align: middle;
        }
        .table-cart th {
            background-color: #f8f9fa;
            color: #495057;
            font-weight: 500;
            text-align: left;
        }
        .table-cart tbody tr:nth-child(even) {
            background-color: #f2f2f2;
        }
        .table-cart tbody tr:hover {
            background-color: #e2e6ea;
        }
        .btn-remove {
            padding: 5px 10px;
            font-size: 14px;
            border: none;
            background-color: transparent;
            color: #dc3545;
        }
        .btn-remove:hover {
            color: #c82333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <h1 class="cart-header">Your Shopping Cart</h1>
                    <asp:GridView ID="gvCart" runat="server" CssClass="table-cart" AutoGenerateColumns="False" OnRowCommand="gvCart_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="ProductName" HeaderText="Product Name" />
                            <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:C}" />
                            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price" DataFormatString="{0:C}" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Button ID="btnRemove" runat="server" Text="Remove" CommandName="Remove" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-remove" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                    <asp:Label ID="lblEmptyCartMessage" runat="server" ForeColor="Red" Visible="false"></asp:Label>

                    <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="Checkout_Click" CausesValidation="false" CssClass="btn btn-checkout" />

                    <!-- Continue Shopping Button -->
                    <asp:HyperLink ID="lnkContinueShopping" runat="server" NavigateUrl="~/Default.aspx" CssClass="btn btn-secondary ml-2">Continue Shopping</asp:HyperLink>
                </div>
            </div>
        </div>
    </form>

    


</body>
</html>
