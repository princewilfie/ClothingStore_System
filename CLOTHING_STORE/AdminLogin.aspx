<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CLOTHING_STORE.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Admin Login</title>
  <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
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
      <div class="row justify-content-center mb-4">
        <div class="col-md-6 text-center">
          <h1>Welcome to our Clothing Store</h1>
          <img src="images/FashionFusionLogo.png" alt="Store Logo" class="store-logo mt-3 mb-3">
        </div>
      </div>
      <div class="row justify-content-center">
        <div class="col-md-6">
          <div class="card">
            <div class="card-body">
              <h2 class="card-title text-center mb-4">Login</h2>
              <asp:Label ID="lblMessage" runat="server" Text="" CssClass="text-danger d-block mb-3"></asp:Label>
              <div class="form-group">
            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Placeholder="Enter Username"></asp:TextBox>
              </div>
              <div class="form-group">
                <label for="password">Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter password"></asp:TextBox>
              </div>
            <asp:Button ID="LoginButton <div class="form-group">
                            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary btn-block" OnClick="btnLogin_Click" />

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

