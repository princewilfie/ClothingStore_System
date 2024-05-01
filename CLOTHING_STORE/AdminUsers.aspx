<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminUsers.aspx.cs" Inherits="CLOTHING_STORE.AdminUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Users</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body {
            background-color: lightgray; /* Set the background color to gray */
        }
        .container {
            margin-top: 20px; /* Adjusted margin top */
        }
        .btn-action {
            margin-right: 5px;
        }
        .dashboard-title {
            text-align: center;
            margin-top: 20px;
            margin-bottom: 30px;
            font-size: 24px;
            color: #333;
        }
        .navbar-brand {
            margin-right: 1rem;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-lg navbar-dark" style="background-color: #ADD8E6;">
            <div class="container">
                <a class="navbar-brand" runat="server" href="~/">
                    <img src="images/FashionFusionLogo.png" alt="Fashion Fusion Logo" width="150" height="50" />
                </a>

                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item">
                            <a class="nav-link" runat="server" href="~/AdminUsers"><span style="font-size: 18px;">Users</span></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" runat="server" href="~/AdminProduct"><span style="font-size: 18px;">Product</span></a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>

        <div class="container">
            <h2 class="dashboard-title">Users</h2>
            <asp:GridView ID="UsersGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" OnRowCommand="UsersGridView_RowCommand">
                <Columns>
                    <asp:BoundField DataField="UserId" HeaderText="User ID" InsertVisible="False" ReadOnly="True" />
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <a href='<%# "EditUser.aspx?id=" + Eval("UserId") %>' class="btn btn-primary btn-action">Edit</a>
                            <asp:LinkButton ID="DeleteLinkButton" runat="server" Text="Delete" CssClass="btn btn-danger btn-action" OnClientClick='<%# "return confirm(\"Are you sure you want to delete this user?\")" %>' CommandName="Delete" CommandArgument='<%# Eval("UserId") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        
    </form>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
