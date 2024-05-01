<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="CLOTHING_STORE.AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        .navbar-brand {
            margin-right: 1rem;
        }
        .dashboard-title {
            text-align: center;
            margin-top: 20px;
            margin-bottom: 30px;
            font-size: 24px;
            color: #333;
        }
        .navbar-toggler {
            border: none;
            outline: none;
        }
        .navbar-nav .nav-link {
            color: white;
        }
        .navbar-nav .nav-link:hover {
            color: white;
            background-color: rgba(255, 255, 255, 0.2);
        }
        .navbar-collapse {
            justify-content: flex-end;
        }
        /* Style for the logout button */
        .logout-btn {
            margin-left: auto; /* Push the button to the right */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-dark" style="background-color: #ADD8E6;">
            <div class="container">
                <a class="navbar-brand" runat="server" href="~/">
                    <img src="images/FashionFusionLogo.png" alt="Fashion Fusion Logo" width="150" height="50" />
                </a>

                <button type="button" class="navbar-toggler" data-bs-toggle="collapse" data-bs-target=".navbar-collapse" title="Toggle navigation" aria-controls="navbarSupportedContent"
                    aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse d-sm-inline-flex justify-content-between">
                    <ul class="navbar-nav">
                        <li class="nav-item"><a class="nav-link" runat="server" href="~/AdminUsers"><span style="font-size: 18px; color: white;">Users</span></a></li>
                        <li class="nav-item"><a class="nav-link" runat="server" href="~/AdminProduct"><span style="font-size: 18px; color: white;">Shoes</span></a></li>
                        <li class="nav-item"><a class="nav-link" runat="server" href="~/AdminTshirt"><span style="font-size: 18px; color: white;">Tshirt</span></a></li>
                        <li class="nav-item"><a class="nav-link" runat="server" href="~/AdminPants"><span style="font-size: 18px; color: white;">Pants</span></a></li>
                    </ul>
                    <!-- Logout button -->
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger logout-btn" OnClick="btnLogout_Click" />
                </div>
            </div>
        </nav>

        <div class="container">
            <h2 class="dashboard-title">Admin Dashboard</h2>
            <!-- Your dashboard content goes here -->
        </div>
        
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
