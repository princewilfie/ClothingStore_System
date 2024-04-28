<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="CLOTHING_STORE.AdminPanel" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container py-5">
        <h2 class="text-center">Users</h2>
        <asp:GridView ID="UsersGridView" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped">
          <Columns>
            <asp:BoundField DataField="UserId" HeaderText="User ID" InsertVisible="False" ReadOnly="True" />
            <asp:BoundField DataField="FirstName" HeaderText="First Name" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="ContactNumber" HeaderText="Contact Number" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:TemplateField HeaderText="Actions">
              <ItemTemplate>
                <a href="EditUser.aspx?id=<%# Eval("UserId") %>">Edit</a>
                <a href="DeleteUser.aspx?id=<%# Eval("UserId") %>" onclick="return confirm('Are you sure you want to delete this user?')">Delete</a>
              </ItemTemplate>
            </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </div>
    </div>
  </div>
</asp:Content>