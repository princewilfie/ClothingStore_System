<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shirts.aspx.cs" Inherits="CLOTHING_STORE.Shirts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid mt-5">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-success" Visible="false" />
        <div class="row">
            <!-- Left vertical advertisement column -->
            <div class="col-lg-2 d-none d-lg-block">
                <img src="images/advertise1.png" class="img-fluid h-100" alt="Vertical Advertisement Left">
            </div>
            <!-- T-Shirts section -->
            <div class="col-lg-8">
                <h2 class="text-center mt-4 mb-4">T-Shirts</h2>
                <div class="row" id="productsContainer">
                    <!-- T-Shirts will be populated here -->
                    <asp:Repeater ID="TshirtsRepeater" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-4 mb-4">
                                <div class="card h-100">
                                    <!-- Product image (if available) -->
                                    <img class="card-img-top" src='<%# "images/tshirt" + Eval("Tshirt_Id") + ".jpg" %>' alt="Product Image" style="width: 100%; height: 300px;" />
                                    <div class="card-body">
                                        <!-- Product name -->
                                        <h5 class="card-title"><%# Eval("TshirtName") %></h5>
                                        <!-- Product price -->
                                        <p class="card-text">Price: P<%# string.Format("{0:N0}", Eval("UnitPrice")) %></p>
                                        <!-- Quantity input field -->
                                        <input type="number" id='quantity_<%# Eval("Tshirt_Id") %>' min="1" value="1" />
                                        <!-- Add to Cart button -->
                                        <asp:Button runat="server" ID='btnAddToCart' Text="Add to Cart" CssClass="btn btn-primary mt-2 addToCartBtn" OnClientClick='<%# "addToCart(" + Eval("Tshirt_Id") + ")" %>' />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <!-- Right vertical advertisement column -->
            <div class="col-lg-2 d-none d-lg-block">
                <img src="images/advertise1.png" class="img-fluid h-100" alt="Vertical Advertisement Right">
            </div>
        </div>
    </div>

    <!-- Include jQuery and Bootstrap JavaScript -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <script>
        function addToCart(tshirtId) {
            var quantityInput = document.getElementById('quantity_' + tshirtId);
            var quantity = quantityInput.value;

            // Send the tshirt ID and quantity to the server
            __doPostBack('addToCart', tshirtId + '|' + quantity);
        }
    </script>
</asp:Content>
