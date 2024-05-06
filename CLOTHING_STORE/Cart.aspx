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
            <asp:Button runat="server" Text="Checkout" CssClass="btn btn-primary" data-toggle="modal" data-target="#checkoutModal" />
        </div>
    </div>

    <!-- Checkout Modal -->
    <div class="modal fade" id="checkoutModal" tabindex="-1" role="dialog" aria-labelledby="checkoutModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="checkoutModalLabel">Checkout Summary</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body" id="checkoutModalBody">
                    <!-- Checkout summary details will be dynamically populated here -->
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <!-- Checkout button -->
                    <button type="button" class="btn btn-primary" id="checkoutButton">Checkout</button>
                </div>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script>
        // Function to populate the checkout modal with product details
        function populateCheckoutModal() {
            var modalBody = document.getElementById('checkoutModalBody');
            var rows = document.querySelectorAll('#<%= gvCart.ClientID %> tbody tr');

            // Initialize total price
            var totalPrice = 0;

            // Clear modal body
            modalBody.innerHTML = '';

            // Loop through each row in the GridView
            rows.forEach(function (row) {
                var productName = row.cells[0].innerText;
                var unitPrice = parseFloat(row.cells[1].innerText.replace('$', '').replace(',', '')); // Parse float from unit price
                var quantity = parseInt(row.cells[2].innerText); // Parse int from quantity
                var rowTotalPrice = parseFloat(row.cells[3].innerText.replace('$', '').replace(',', '')); // Parse float from total price

                // Check if parsing is successful
                if (!isNaN(unitPrice) && !isNaN(quantity) && !isNaN(rowTotalPrice)) {
                    // Append product details to modal body
                    modalBody.innerHTML += '<p><strong>' + productName + '</strong><br>Unit Price: $' + unitPrice.toFixed(2) + '<br>Quantity: ' + quantity + '<br>Total Price: $' + rowTotalPrice.toFixed(2) + '</p>';

                    // Update total price
                    totalPrice += rowTotalPrice;
                }
            });

            // Append total price to modal body
            modalBody.innerHTML += '<hr><p><strong>Total Price: $' + totalPrice.toFixed(2) + '</strong></p>';
        }

        // Event listener for modal show event
        $('#checkoutModal').on('show.bs.modal', function (e) {
            populateCheckoutModal();
        });

        // Event listener for checkout button click
        $('#checkoutButton').click(function () {
            // Redirect to Order.aspx page
            window.location.href = 'Order.aspx';
        });
    </script>
</asp:Content>
