<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CollabMain.aspx.cs" Inherits="EDPHeaven.CollabMain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="center">
        <tr>
            <td></td>
            <td>
                <asp:Button ID="CRoomBtn" runat="server" Height="38px" OnClick="CRoomBtn_Click" Text="Create A Room" Width="244px" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:button ID="JRoomBtn" runat="server" Height="38px" OnClick="JRoomBtn_Click" Text="Join A Room" Width="244px"/>
                <div class="modal fade" id="JRoomModal" tabindex="-1" aria-labelledby="JRoomModLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h2 class="modal-title" id="JRoomModLabel">Join A Room</h2>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>s
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lbl_JError" runat="server"></asp:Label>
                                <table border="0">
                                    <tr>
                                        <td><asp:Label ID="lbl_Name" runat="server" Text="Name:"></asp:Label></td>
                                        <td><asp:TextBox ID="tb_name" runat="server" ></asp:TextBox></td>
                                        </tr>
                                    <tr>
                                        <td><asp:Label ID="lbl_JRoomID" runat="server" Text="Room ID:"></asp:Label></td>
                                        <td><asp:TextBox ID="tb_JRoomID" runat="server"></asp:TextBox></td>
                                        </tr>
                                    <tr>
                                        <td><asp:Label ID="lbl_JRoomPass" runat="server" Text="Room Password:"></asp:Label></td>
                                        <td><asp:TextBox ID="tb_JRoomPass" runat="server" TextMode="Password"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="JoinRoomBtn" runat="server" OnClick="JoinRoomBtn_Click" Text="Join Room" />
                            </div>
                         </div>
                    </div>
                </div>
            </td>
            <td></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="DocumentBtn" runat="server" Height="38px" OnClick="DocumentBtn_Click" Text="Create A Document" Width="244px" />
            </td>
            <td></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
