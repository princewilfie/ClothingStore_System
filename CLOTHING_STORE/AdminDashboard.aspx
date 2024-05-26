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
        .logout-btn {
            margin-left: auto;
        }
        .export-btn {
            margin: 5px;
        }
        .export-btn-container {
            margin-top: 20px;
            display: flex;
            justify-content: center;
            flex-wrap: wrap;
        }
        .export-btn {
            margin: 10px;
            padding: 10px 20px;
            font-size: 18px;
            border-radius: 5px;
            background-color: #dc3545; /* Red color */
            color: #fff;
            border: none;
            cursor: pointer;
            transition: background-color 0.3s ease, transform 0.3s ease;
        }
        .export-btn:hover {
             background-color: #c82333; /* Darker red on hover */
            transform: scale(1.05);
        }
        .card {
            margin-bottom: 20px;
            border: none;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            transition: transform 0.3s ease;
        }
        .card:hover {
            transform: scale(1.02);
        }
        .card .card-body {
            text-align: center;
            background-color: #f8f9fa;
            border-radius: 10px 10px 0 0;
        }
        .card .card-body i {
            font-size: 40px;
            color: #007bff;
            margin-bottom: 10px;
        }
        .card-title {
            font-size: 22px;
            margin-bottom: 10px;
        }
        .card-text {
            font-size: 18px;
            color: #333;
        }
        .card-footer {
            background-color: #007bff;
            color: white;
            border-radius: 0 0 10px 10px;
        }
        .card-footer a {
            color: white;
            text-decoration: none;
            font-size: 16px;
            transition: color 0.3s ease;
        }
        .card-footer a:hover {
            color: #ffd700;
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
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="btn btn-danger logout-btn" OnClick="btnLogout_Click" />
                </div>
            </div>
        </nav>

        <div class="container">
            <h1 class="dashboard-title">REPORTS</h1>

            <!-- Display counts -->
            <div class="row">
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-body">
                            <i class="fas fa-users"></i>
                            <h5 class="card-title">Users</h5>
                            <p class="card-text"><asp:Label ID="lblUserCount" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="card-footer">
                            <a href="AdminUsers" class="btn btn-primary">Manage Users</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-body">
                            <i class="fas fa-boxes"></i>
                            <h5 class="card-title">Shoes</h5>
                            <p class="card-text"><asp:Label ID="lblProductCount" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="card-footer">
                            <a href="AdminProduct" class="btn btn-primary">Manage Shoes</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-body">
                            <i class="fas fa-trousers"></i>
                            <h5 class="card-title">Pants</h5>
                            <p class="card-text"><asp:Label ID="lblPantsCount" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="card-footer">
                            <a href="AdminPants" class="btn btn-primary">Manage Pants</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-body">
                            <i class="fas fa-receipt"></i>
                            <h5 class="card-title">Orders</h5>
                            <p class="card-text"><asp:Label ID="lblOrderCount" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="card-footer">
                            <a href="Order" class="btn btn-primary">Manage Orders</a>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-body">
                            <i class="fas fa-tshirt"></i>
                            <h5 class="card-title">T-shirts</h5>
                            <p class="card-text"><asp:Label ID="lblTshirtCount" runat="server" Text=""></asp:Label></p>
                        </div>
                        <div class="card-footer">
                            <a href="AdminTshirt" class="btn btn-primary">Manage T-shirts</a>
                        </div>
                    </div>
                </div>
            </div>

            <h1><center>EXPORTS</center></h1>
            <!-- Export buttons -->
            <div class="export-btn-container">
                <asp:Button ID="btnExportUsers" runat="server" Text="Export Users" CssClass="export-btn" OnClick="btnExportUsers_Click" />
                <asp:Button ID="btnExportProducts" runat="server" Text="Export Products" CssClass="export-btn" OnClick="btnExportProducts_Click" />
                <asp:Button ID="btnExportPants" runat="server" Text="Export Pants" CssClass="export-btn" OnClick="btnExportPants_Click" />
                <asp:Button ID="btnExportOrders" runat="server" Text="Export Orders" CssClass="export-btn" OnClick="btnExportOrders_Click" />
                <asp:Button ID="btnExportTshirt" runat="server" Text="Export Tshirt" CssClass="export-btn" OnClick="btnExportTshirt_Click" />
            </div>

            <asp:GridView ID="UsersGridView" runat="server" OnRowDeleting="UsersGridView_RowDeleting" OnRowEditing="UsersGridView_RowEditing"
                AutoGenerateColumns="False" DataKeyNames="UserId" CssClass="table table-striped table-bordered">
                <Columns>
                    <asp:BoundField DataField="UserId" HeaderText="User ID" ReadOnly="True" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:CommandField ShowEditButton="True" EditText="Edit" ShowDeleteButton="True" DeleteText="Delete" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://kit.fontawesome.com/a076d05399.js"></script> <!-- Font Awesome for icons -->
</body>
</html>
