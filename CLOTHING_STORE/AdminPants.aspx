<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPants.aspx.cs" Inherits="CLOTHING_STORE.AdminPants" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Pants</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet">
    <style>
        body {
            background-color: lightgray; /* Set the background color to gray */
        }
        .container {
            margin-top: 50px;
        }
        .modal-title {
            color: #333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navbar -->
        <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
            <div class="container">
                <a class="navbar-brand" href="~/">
                    <img src="images/FashionFusionLogo.png" alt="Fashion Fusion Logo" width="150" height="50" />
                </a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent"
                    aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav ml-auto">
                        <li class="nav-item">
                            <a class="nav-link" href="~/AdminUsers"><span style="font-size: 18px;">Users</span></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="~/AdminPants"><span style="font-size: 18px;">Pants</span></a>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <!-- End Navbar -->

        <!-- Main Content -->
        <div class="container">
            <!-- Button to trigger modal -->
            <button type="button" class="btn btn-primary mt-3" data-toggle="modal" data-target="#addItemModal">
                Add New Pants
            </button>

            <!-- Modal -->
            <div class="modal fade" id="addItemModal" tabindex="-1" role="dialog" aria-labelledby="addItemModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="addItemModalLabel">Add New Pants</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <!-- Form to add new Pants -->
                            <div class="form-group">
                                <label for="PantsName">Pants Name:</label>
                                <asp:TextBox ID="PantsNameTextBox" runat="server" CssClass="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="UnitPrice">Unit Price:</label>
                                <asp:TextBox ID="UnitPriceTextBox" runat="server" CssClass="form-control" />
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                            <asp:Button ID="btnAddPants" runat="server" Text="Add Pants" OnClick="btnAddPants_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- GridView to display Pants -->
            <asp:GridView ID="GridViewPants" runat="server" CssClass="table table-bordered table-striped mt-3" AutoGenerateColumns="False" OnRowCommand="GridViewPants_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Pants_Id" HeaderText="Pants ID" />
                    <asp:BoundField DataField="PantsName" HeaderText="Pants Name" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server" CommandName="DeletePants" CommandArgument='<%# Eval("Pants_Id") %>' Text="Delete" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want to delete this Pants?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <!-- End Main Content -->

    </form>

    <!-- Scripts -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
