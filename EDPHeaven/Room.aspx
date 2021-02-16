<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Room.aspx.cs" Inherits="EDPHeaven.Room" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="Scripts/VideoScript.js"></script>
    <div id="videoDiv">
        <script>
            window.addEventListener("load", function (evt) {
                playVideoFromCamera();
            });
        </script>
    </div>
    <div>
        <button type="button" id="callButton" onclick="call()">Join Call</button>
        <button type="button"s id="hangupButton" onclick="hangup()">Hang Up</button>
        <asp:Button ID="Disconnect" runat="server" Text="Disconnect" OnClick="Disconnect_Click" />
    </div>
    <div>
        <asp:Label ID="RoomID" runat="server"></asp:Label><br />
        <asp:Label ID="RoomPassword" runat="server"></asp:Label>
    </div>
</asp:Content>
