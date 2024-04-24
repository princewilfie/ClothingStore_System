<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="CLOTHING_STORE.RegistrationPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <!-- Bootstrap CSS -->
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <style>
        body {
            background-color: #f8f9fa; /* Light gray background */
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
        .form-group {
            margin-bottom: 20px; /* Bottom margin for form groups */
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
        <!-- Registration form section -->
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-body">
                        <h2 class="card-title text-center mb-4">Registration</h2>
                        <form id="registrationForm" runat="server">
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="firstName">First Name:</label>
                                    <asp:TextBox ID="firstName" runat="server" CssClass="form-control" placeholder="Enter first name"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="lastName">Last Name:</label>
                                    <asp:TextBox ID="lastName" runat="server" CssClass="form-control" placeholder="Enter last name"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="email">Email:</label>
                                    <asp:TextBox ID="email" runat="server" CssClass="form-control" placeholder="Enter email"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="contactNumber">Contact Number:</label>
                                    <asp:TextBox ID="contactNumber" runat="server" CssClass="form-control" placeholder="Enter contact number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="address">Address:</label>
                                    <asp:TextBox ID="address" runat="server" CssClass="form-control" placeholder="Enter address"></asp:TextBox>
                                </div>
                                <div class="form-group col-md-6">
                                    <label for="password">Password:</label>
                                    <asp:TextBox ID="password" runat="server" CssClass="form-control" placeholder="Enter password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-row">
                                <div class="form-group col-md-6">
                                    <label for="confirmPassword">Confirm Password:</label>
                                    <asp:TextBox ID="confirmPassword" runat="server" CssClass="form-control" placeholder="Confirm password"></asp:TextBox>
                                </div>
                            </div>
                            <asp:Button ID="RegisterButton" runat="server" Text="Register" CssClass="btn btn-primary btn-block" OnClick="RegisterButton_Click" />
                        </form>
                        <hr>
                        <p class="text-center">Already have an account? <a href="LoginPage.aspx">Login</a></p>
                    </div>
                </div>
            </div>
        </div>
    </div>

</body>
</html>
