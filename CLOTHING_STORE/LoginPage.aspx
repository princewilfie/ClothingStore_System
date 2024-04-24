<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="CLOTHING_STORE.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <!-- Bootstrap CSS -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <style>
        body, html {
            height: 100%; /* Set height to 100% for the entire page */
            margin: 0; /* Remove default margin */
            padding: 0; /* Remove default padding */
        }
        .background-img {
            position: fixed; /* Set position to fixed */
            top: 0; /* Set top position to 0 */
            left: 0; /* Set left position to 0 */
            width: 100%; /* Set width to cover the entire page */
            height: 100%; /* Set height to cover the entire page */
            z-index: -1; /* Set z-index to send it to the back */
        }
        .container {
            margin-top: 50px;
        }
        .card {
            border: none; /* No border for the card */
            border-radius: 15px; /* Rounded corners for the card */
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); /* Shadow for the card */
        }
        .card-title {
            color: #333; /* Card title color */
        }
        .form-control {
            border-radius: 10px; /* Rounded corners for form inputs */
        }
        .btn-primary {
            background-color: #007bff; /* Primary button color */
            border-color: #007bff; /* Border color */
            border-radius: 10px; /* Rounded corners for the button */
        }
        .btn-primary:hover {
            background-color: #0056b3; /* Darker color on hover */
            border-color: #0056b3; /* Darker border color on hover */
        }
        /* Adjust store logo size */
        .store-logo {
            width: 150px; /* Set the desired width */
            height: auto; /* Maintain aspect ratio */
        }
    </style>
</head>
<body>
    <form id="loginForm" runat="server">
        <div class="background-img">
            <img src="images/clothingstore_background.png" alt="Background Image" style="width: 100%; height: 100%;" />
        </div>

        <div class="container">
            <!-- Header section -->
            <div class="row justify-content-center mb-4">
                <div class="col-md-6 text-center">
                    <h1>Welcome to our Clothing Store</h1>
                    <img src="images/FashionFusionLogo.png" alt="Store Logo" class="store-logo mt-3 mb-3">
                </div>
            </div>
            <!-- Login form section -->
            <div class="row justify-content-center">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-body">
                            <h2 class="card-title text-center mb-4">Login</h2>
                            <div class="form-group">
                                <label for="email">Email:</label>
                                <input type="email" class="form-control" id="email" placeholder="Enter email" runat="server">
                            </div>
                            <div class="form-group">
                                <label for="password">Password:</label>
                                <input type="password" class="form-control" id="password" placeholder="Enter password" runat="server">
                            </div>
                            <asp:Button ID="LoginButton" runat="server" Text="Login" CssClass="btn btn-primary btn-block" OnClick="LoginButton_Click" />
                            <hr>
                                <asp:Label ID="errorMessage" runat="server" Text="" CssClass="text-danger"></asp:Label> <!-- Ensure this line is present -->

                            <p class="text-center">Don't have an account? <a href="RegistrationPage.aspx">Create Account</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
