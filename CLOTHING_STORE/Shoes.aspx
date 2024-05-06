<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shoes.aspx.cs" Inherits="CLOTHING_STORE.Shoes" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Web.Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid mt-5">
        <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-success" Visible="false" />
        <div class="row">
            <!-- Left vertical image column -->
            <div class="col-lg-2 d-none d-lg-block">
                <img src="images/advertise1.png" class="img-fluid h-100" alt="Vertical Advertisement Left">
            </div>
            <!-- Products section -->
            <div class="col-lg-8">
                <h2 class="text-center mt-4 mb-4">Shoes</h2>
                <div class="row" id="productsContainer">
                    <!-- Products will be populated here -->
                    <asp:Repeater ID="ProductsRepeater" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-4 mb-4">
                                <div class="card h-100">
                                    <!-- Product image (if available) -->
                                    <img class="card-img-top" src='<%# "images/shoes" + Eval("Product_Id") + ".jpg" %>' alt="Product Image" style="width: 100%; height: 300px;" />
                                    <div class="card-body">
                                        <!-- Product name -->
                                        <h5 class="card-title"><%# Eval("ProductName") %></h5>
                                        <!-- Product price -->
                                        <p class="card-text">Price: P<%# string.Format("{0:N0}", Eval("UnitPrice")) %></p>
                                        <!-- Quantity input field -->
                                        <input type="number" id="quantity_<%# Eval("Product_Id") %>" min="1" value="1" />
                                        <!-- Add to Cart button -->
                                        <asp:Button runat="server" ID='Button1' Text="Add to Cart" CssClass="btn btn-primary mt-2 addToCartBtn" OnClientClick='<%# "addToCart(" + Eval("Product_Id") + ")" %>' />
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
            <!-- Right vertical image column -->
            <div class="col-lg-2 d-none d-lg-block">
                <img src="images/advertise1.png" class="img-fluid h-100" alt="Vertical Advertisement Right">
            </div>
        </div>
    </div>

    <!-- Include jQuery and Bootstrap JavaScript -->
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <script>
        function addToCart(productId) {
            var quantityInput = document.getElementById('quantity_' + productId);
            var quantity = quantityInput.value;

            // Send the product ID and quantity to the server
            __doPostBack('addToCart', productId + '|' + quantity);
        }
    </script>
</asp:Content>
