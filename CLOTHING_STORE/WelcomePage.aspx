<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WelcomePage.aspx.cs" Inherits="CLOTHING_STORE.WelcomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome Page</title>
    <!-- Bootstrap CSS -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <style>
        body {
            background-color: #f8f9fa; /* Light gray background */
        }
        .container {
            margin-top: 50px;
        }
        .carousel-item img {
            height: 500px; /* Adjust height of carousel images */
            object-fit: cover; /* Maintain aspect ratio */
        }
        .card {
            border: none; /* No border for the card */
            border-radius: 15px; /* Rounded corners for the card */
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); /* Shadow for the card */
        }
        .card-title {
            color: #333; /* Card title color */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Header section -->
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="container">
                <!-- Logo -->
                <a class="navbar-brand" href="#">
                    <img src="images/FashionFusionLogo.png" alt="Store Logo" height="50">
                </a>
                <!-- Login Button -->
                <asp:LinkButton ID="lnkLogin" runat="server" CssClass="btn btn-primary ml-auto" PostBackUrl="~/LoginPage.aspx">Login</asp:LinkButton>
            </div>
        </nav>

        <!-- Content section -->
        <div class="container-fluid">
            <!-- Use container-fluid class -->
            <!-- Add padding to the carousel -->
            <div id="carouselExampleControls" class="carousel slide" data-ride="carousel" data-interval="3000">
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img class="d-block w-100" src="images/carousel_3.png" alt="First slide">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="images/carousel_1.png" alt="Second slide">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="images/carousel_2.png" alt="Third slide">
                    </div>
                    <div class="carousel-item">
                        <img class="d-block w-100" src="images/carousel_4.png" alt="Fourth Slide">
                    </div>
                </div>
                <a class="carousel-control-prev" href="#carouselExampleControls" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Previous</span>
                </a>
                <a class="carousel-control-next" href="#carouselExampleControls" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Next</span>
                </a>
            </div>
        </div>

        <!-- Trending now section -->
        <div class="container-fluid mt-5 pt-3">
    <h1 class="text-center mt-0">TRENDING NOW</h1>
    <div class="row justify-content-center mt-5">
        <div class="col-lg-4 col-md-6 mb-4">
            <div class="card h-100">
                <img class="card-img-top" src="images/shoes1.jpg" alt="Card image cap" style="height: 500px; object-fit: cover;">
                <!-- Adjust height and object-fit as needed -->
                <div class="card-body text-center">
                    <h4 class="card-title">Card title</h4>
                    <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-6 mb-4">
            <div class="card h-100">
                <img class="card-img-top" src="images/tshirt1.jpg" alt="Card image cap" style="height: 500px; object-fit: cover;">
                <!-- Adjust height and object-fit as needed -->
                <div class="card-body text-center">
                    <h4 class="card-title">Card title</h4>
                    <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-6 mb-4">
            <div class="card h-100">
                <img class="card-img-top" src="images/shorts1.jpg" alt="Card image cap" style="height: 500px; object-fit: cover;">
                <!-- Adjust height and object-fit as needed -->
                <div class="card-body text-center">
                    <h4 class="card-title">Card title</h4>
                    <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-6 mb-4">
            <div class="card h-100">
                <img class="card-img-top" src="images/shorts2.jpg" alt="Card image cap" style="height: 500px; object-fit: cover;">
                <!-- Adjust height and object-fit as needed -->
                <div class="card-body text-center">
                    <h4 class="card-title">Card title</h4>
                    <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-6 mb-4">
            <div class="card h-100">
                <img class="card-img-top" src="images/tshirt2.jpg" alt="Card image cap" style="height: 500px; object-fit: cover;">
                <!-- Adjust height and object-fit as needed -->
                <div class="card-body text-center">
                    <h4 class="card-title">Card title</h4>
                    <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-6 mb-4">
            <div class="card h-100">
                <img class="card-img-top" src="images/shoes2.jpg" alt="Card image cap" style="height: 500px; object-fit: cover;">
                <!-- Adjust height and object-fit as needed -->
                <div class="card-body text-center">
                    <h4 class="card-title">Card title</h4>
                    <p class="card-text">Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>
                </div>
            </div>
        </div>
    </div>
</div>
    </form>

    <!-- Bootstrap JS -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
