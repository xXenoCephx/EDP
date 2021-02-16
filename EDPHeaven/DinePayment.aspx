<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DinePayment.aspx.cs" Inherits="EDPHeaven.DinePayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h3>Your Information</h3>
        <div>
            <asp:Label ID="LbEmail" runat="server" Text="Email"></asp:Label><br />
            <asp:TextBox ID="TbEmail" runat="server" TextMode="Email"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LbContactNum" runat="server" Text="Contact number"></asp:Label><br />
            <asp:TextBox ID="TbContactNum" runat="server" TextMode="Phone"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LbDeliveryAddress" runat="server" Text="Delivery Address"></asp:Label><br />
            <asp:TextBox ID="TbDeliveryAdd" runat="server"></asp:TextBox><br />
            <asp:Label ID="Lbaddressnote" runat="server" Text="Order will be billed to delivery address." Font-Size="Smaller"></asp:Label><br />
        </div>
        <br />
        <h3>Payment Details</h3>
        <asp:Label ID="LbError" runat="server" Text="Card Number" Visible="false"></asp:Label>
        <div>
            <asp:Label ID="LbCardNum" runat="server" Text="Card Number"></asp:Label><br />
            <asp:TextBox ID="TbCardNum" runat="server" TextMode="Password" MaxLength="16" ></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LbExpDate" runat="server" Text="Expiry Date"></asp:Label><br />
            <asp:TextBox ID="TbExpDate" runat="server" TextMode="Month"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LbSecNum" runat="server" Text="Security Number"></asp:Label><br />
            <asp:TextBox ID="TbSecNum" runat="server" TextMode="Password" MaxLength="3"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Button CssClass="btn" ID="BtnPay" runat="server" Text="Pay" OnClick="BtnPay_Click" BackColor="#3B4069" ForeColor="White" />
        </div>
    </div>
</asp:Content>
