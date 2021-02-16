<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FullMenu.aspx.cs" Inherits="EDPHeaven.FullMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="ItemName" HeaderText="Item Name" ReadOnly="True" />
                <asp:BoundField DataField="ItemPrice" HeaderText="Item Price" ReadOnly="True" DataFormatString="{0:0.00}" />
                <asp:BoundField DataField="ItemDesc" HeaderText="Item Description" ReadOnly="True" />
                <asp:CheckBoxField DataField="IsRecommend" HeaderText="Recommended" Text="Recommended" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="EditBtn" runat="server" CommandArgument='<%# Eval("ItemId") %>' OnClick="EditBtn_Click">Edit</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <div class="modal fade" id="EditModal" tabindex="-1" aria-labelledby="editModLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <h2 class="modal-title" id="editModLabel">Edit Item</h2>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    </div>
                    <div class="modal-body">
                        <div>
                            <asp:Label ID="lbl_itemId" runat="server"></asp:Label>
                        </div>
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
                        <asp:Button ID="AddBtn" runat="server" OnClick="EditItem" Text="Confirm Edit" />
                        <asp:Button ID="cancel" runat="server" data-dismiss="modal" Text="Cancel" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
