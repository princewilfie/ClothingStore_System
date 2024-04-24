<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pants.aspx.cs" Inherits="CLOTHING_STORE.Pants" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <h2 class="text-center mt-4 mb-4">Pants</h2> <!-- Add this line for the "Shoes" text -->
        <div class="row">
            <!-- Left vertical image column -->
            <div class="col-lg-2 d-none d-lg-block">
                <img src="images/advertise1.png" class="img-fluid h-100" alt="Vertical Advertisement Left">
            </div>
            <div class="col-lg-8">
                <div class="row">
                    <div class="col-lg-4 col-md-6 mt-4 mb-3">
                        <div class="card h-100">
                            <img class="card-img-top" src="https://via.placeholder.com/300" alt="">
                            <div class="card-body">
                                <h4 class="card-title">Product 1</h4>
                                <p class="card-text">Description of producta 1.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 mt-4 mb-3">
                        <div class="card h-100">
                            <img class="card-img-top" src="https://via.placeholder.com/300" alt="">
                            <div class="card-body">
                                <h4 class="card-title">Product 2</h4>
                                <p class="card-text">Description of product 2.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 mt-4 mb-3">
                        <div class="card h-100">
                            <img class="card-img-top" src="https://via.placeholder.com/300" alt="">
                            <div class="card-body">
                                <h4 class="card-title">Product 3</h4>
                                <p class="card-text">Description of product 3.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 mb-3">
                        <div class="card h-100">
                            <img class="card-img-top" src="https://via.placeholder.com/300" alt="">
                            <div class="card-body">
                                <h4 class="card-title">Product 4</h4>
                                <p class="card-text">Description of product 4.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 mb-3">
                        <div class="card h-100">
                            <img class="card-img-top" src="https://via.placeholder.com/300" alt="">
                            <div class="card-body">
                                <h4 class="card-title">Product 5</h4>
                                <p class="card-text">Description of product 5.</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-6 mb-3">
                        <div class="card h-100">
                            <img class="card-img-top" src="https://via.placeholder.com/300" alt="">
                            <div class="card-body">
                                <h4 class="card-title">Product 6</h4>
                                <p class="card-text">Description of product 6.</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- Right vertical image column -->
            <div class="col-lg-2 d-none d-lg-block">
                <img src="images/advertise1.png" class="img-fluid h-100" alt="Vertical Advertisement Right">
            </div>
        </div>
    </div>

</asp:Content>
