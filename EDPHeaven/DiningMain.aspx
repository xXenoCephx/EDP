<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DiningMain.aspx.cs" Inherits="EDPHeaven.DiningMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex flex-row justify-content-between" style="width:80%; color:#f9f3eb;">
        <h2>Outlets available</h2>
        <div class="card" style="width:20rem; height:15rem; border:solid; margin=20px;">
            <div class="card-body">
                <asp:Label CssClass="card-title" ForeColor="Black" ID="LbOutlet1Name" runat="server" Text="" Font-Size="Larger"></asp:Label>
                <br />
                <asp:Label CssClass="card-text" ForeColor="Black" ID="LbOutlet1Desc" runat="server" Text=""></asp:Label>
                <br /><br />
                <asp:Button CssClass="btn" ID="ViewOutlet1" runat="server" Text="View" BackColor="#FF593E" OnClick="ViewOutlet1_Click" />
            </div>
        </div>
        <div class="card" style="width:20rem; height:15rem; border:solid; margin=2rem;">
            <div class="card-body">
                <asp:Label CssClass="card-title" ForeColor="Black" ID="LbOutlet2Name" runat="server" Text="" Font-Size="Larger"></asp:Label>
                <br />
                <asp:Label CssClass="card-text" ForeColor="Black" ID="LbOutlet2Desc" runat="server" Text=""></asp:Label>
                <br /><br />
                <asp:Button CssClass="btn" ID="ViewOutlet2" runat="server" Text="View" BackColor="#FF593E" OnClick="ViewOutlet2_Click" />
            </div>
        </div>
    </div>
</asp:Content>
