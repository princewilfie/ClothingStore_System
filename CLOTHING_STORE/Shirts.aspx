<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Shirts.aspx.cs" Inherits="CLOTHING_STORE.Shirts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid mt-5">
        <div class="row">
            <!-- Left vertical advertisement column -->
            <div class="col-lg-2 d-none d-lg-block">
                <img src="images/advertise1.png" class="img-fluid h-100" alt="Vertical Advertisement Left">
            </div>
            <!-- T-Shirts section -->
            <div class="col-lg-8">
                <h2 class="text-center mt-4 mb-4">T-Shirts</h2>
                <div class="row">
                    <% foreach (System.Data.DataRow row in TshirtsDataTable.Rows) { %>
                        <div class="col-lg-4 mb-4">
                            <div class="card h-100">
                                <!-- Product image (if available) -->
                                <img class="card-img-top" src="<%= row["ImageUrl"] %>" alt="Product Image" style="width: 100%; height: 300px;" />
                                <div class="card-body">
                                    <!-- Product name -->
                                    <h5 class="card-title"><%= row["TshirtName"] %></h5>
                                    <!-- Product price -->
                                    <p class="card-text">Price: P<%= string.Format("{0:N0}", row["UnitPrice"]) %></p>
                                    <!-- Add to cart button or other actions -->
                                    <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="btn btn-primary btn-block" />
                                </div>
                            </div>
                        </div>
                    <% } %>
                </div>
            </div>
            <!-- Right vertical advertisement column -->
            <div class="col-lg-2 d-none d-lg-block">
                <img src="images/advertise1.png" class="img-fluid h-100" alt="Vertical Advertisement Right">
            </div>
        </div>
    </div>
</asp:Content>
