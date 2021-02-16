<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RestaurantDashboard.aspx.cs" Inherits="EDPHeaven.RestaurantDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col col-mb-4">
            <asp:Label ID="LbOutletName" runat="server"></asp:Label>
            <br />
            <asp:Label ID="LBSales" runat="server">Sales Today</asp:Label>
        
        </div>
        <div class="col col-mb-4">
            <div>
                <div>
                    <asp:Label ID="LbDisplayImage" runat="server" Text="Display Photo"></asp:Label><br />
                    <asp:Button ID="BtnChgImg" runat="server" Text="Change" />
                </div>
                <div>
                    <asp:Image ID="OutletImg" runat="server" Width="300px" Height="214px" AlternateText="Nothing right now" />
                </div>
            </div>
            <div class="justify-content-between">
                <asp:Label ID="LbDescTitle" runat="server" Text="Description"></asp:Label><br />
                <asp:PlaceHolder ID="PHolderDesc" runat="server"></asp:PlaceHolder><br />
                <asp:Button ID="BtnEditDesc" runat="server" Text="Edit" OnClick="BtnEditDesc_Click" />
                <div class="modal fade" id="DescModal" tabindex="-1" aria-labelledby="DescModLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h2 class="modal-title" id="DescModLabel">Change Description</h2>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            </div>
                            <div class="modal-body">
                                <div>
                                    <asp:Label ID="Label1" runat="server" Text="Description (No more than 250 characters): " ></asp:Label>
                                </div>
                                <div>
                                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" MaxLength="250"></asp:TextBox>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="Button1" runat="server" OnClick="Description_Click" Text="Save" />
                                <asp:Button ID="Button2" runat="server" data-dismiss="modal" Text="Cancel" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col col-mb-4">
            <asp:Label ID="LbMenu" runat="server" Text="Menu:"></asp:Label>
            <asp:Button ID="BtnAddNew" runat="server" Text="Add New Item" OnClick="BtnAddNew_Click" />
            <asp:Button ID="BtnViewAll" runat="server" Text="View All" OnClick="BtnViewAll_Click" />
            <br />
            <div>
                <asp:PlaceHolder ID="PHolderMenuItems" runat="server"></asp:PlaceHolder>
            </div>
            <div class="modal fade" id="menuModal" tabindex="-1" aria-labelledby="menuModLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h2 class="modal-title" id="menuModLabel">Add New Item</h2>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        </div>
                        <div class="modal-body">
                            <div>
                                <asp:Label ID="lbl_itemName" runat="server" Text="Item Name: " ></asp:Label>
                                <asp:TextBox ID="tb_itemName" runat="server"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lbl_itemPrice" runat="server" Text="Item Price: " ></asp:Label>
                                <asp:TextBox ID="tb_itemPrice" runat="server"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lbl_itemDesc" runat="server" Text="Item Description: " ></asp:Label>
                                <asp:TextBox ID="tb_itemDesc" runat="server"></asp:TextBox>
                            </div>
                            <div>
                                <asp:Label ID="lbl_isRec" runat="server" Text="Is Recommended: " ></asp:Label>
                                <asp:CheckBox ID="cb_isRec" runat="server"></asp:CheckBox>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:Button ID="AddBtn" runat="server" OnClick="AddBtn_Click" Text="Add Item" />
                            <asp:Button ID="cancel" runat="server" data-dismiss="modal" Text="Cancel" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
