<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EDPHeaven.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <asp:Label ID="error_lbl" runat="server" Visible="false" ForeColor="Red"></asp:Label>
        </div>
        <table>
            <tr>
                <td><asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label></td>
                <td><asp:TextBox ID="Email" runat="server" TextMode="Email"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblPass" runat="server" Text="Password: "></asp:Label></td>
                <td><asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
        </table>
    </div>
    <div>
        <asp:Button ID="LoginBtn" runat="server" OnClick="Login_Click" Text="Log In" />
    </div>
</asp:Content>
