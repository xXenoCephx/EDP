using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace EDPHeaven
{
    public partial class RestaurantDashboard : System.Web.UI.Page
    {
        MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            //OutletName
            LbOutletName.Text = client.GetOutletName(1);
            //OutletDesc
            Label label = new Label();
            label.Text = client.GetOutletDesc(1);
            PHolderDesc.Controls.Add(label);

            //MenuItems
            HtmlButton button = new HtmlButton();
            HtmlTable menu = new HtmlTable();
            HtmlTableRow theadrow = new HtmlTableRow();
            HtmlTableCell theadcell = new HtmlTableCell();
            HtmlTableCell theadcell1 = new HtmlTableCell();
            HtmlTableCell theadcell2 = new HtmlTableCell();
            theadcell.InnerText = "Name";
            theadcell1.InnerText = "Price";
            theadcell2.InnerText = "Description";
            theadrow.Cells.Add(theadcell);
            theadrow.Cells.Add(theadcell1);
            theadrow.Cells.Add(theadcell2);
            menu.Rows.Add(theadrow);
            foreach (string[] itemList in client.GetItems(1))
            {
                HtmlTableRow row = new HtmlTableRow();

                foreach (string item in itemList)
                {
                    HtmlTableCell cell = new HtmlTableCell();
                    if (item == itemList[1])
                    {
                        string.Format("{0:0.00}", item);
                    }
                    cell.InnerText = item;

                    row.Cells.Add(cell);
                }
                menu.CellPadding = 15;
                menu.Rows.Add(row);
            }
            PHolderMenuItems.Controls.Add(menu);
        }

        protected void BtnViewAll_Click(object sender, EventArgs e)
        {
            Response.Redirect("FullMenu.aspx", false);
        }

        protected void BtnAddNew_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "addNewItem", "$('#menuModal').modal('show')", true);
        }

        protected void AddBtn_Click(object sender, EventArgs e)
        {
            int result = client.AddMenuItem(1, tb_itemName.Text, Convert.ToDouble(tb_itemPrice.Text), tb_itemDesc.Text, cb_isRec.Checked);
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "success", "alert('Item Added Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "failure", "alert('Failed to Add Item')", true);
            }
        }

        protected void BtnEditDesc_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "Description", "$('#DescModal').modal('show')", true);
        }
        protected void Description_Click(object sender, EventArgs e)
        {

        }
    }
}