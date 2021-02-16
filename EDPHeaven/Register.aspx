<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EDPHeaven.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table>
            <tr>
                <td><asp:Label ID="lbluserName" runat="server" Text="Username: "></asp:Label></td>
                <td><asp:TextBox ID="userName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblPass" runat="server" Text="Password: "></asp:Label></td>
                <td><asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td><asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label></td>
                <td><asp:TextBox ID="Email" runat="server" TextMode="Email"></asp:TextBox></td>
            </tr>
        </table>
        <asp:Button ID="RegBtn" runat="server" OnClick="RegBtn_Click" Text="Sign Up" />
    </div>
</asp:Content>
