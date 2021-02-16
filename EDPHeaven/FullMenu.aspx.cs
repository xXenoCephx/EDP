using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDPHeaven
{
    public partial class FullMenu : System.Web.UI.Page
    {
        MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                GridView1.Visible = true;
                GridView1.DataSource = client.GetItemList(1);
                GridView1.DataBind();
            }
            catch (Exception)
            {
                Label1.Text = "An Error has occurred. Please contact Administration.";
                Label1.Visible = true;
                Label1.ForeColor = Color.Red;
            }
        }
        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.CompareTo("UpdBtn") == 0)
            {
                Response.Redirect("Room.aspx");

            }
        }

        protected void EditBtn_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "EditModal", "$('#EditModal').modal('show')", true);
            LinkButton btn = (LinkButton)sender;
            int itemId = Convert.ToInt32(btn.CommandArgument);
            string[] item = client.SelectItem(itemId);
            lbl_itemId.Text = Convert.ToInt32(btn.CommandArgument).ToString();
            tb_itemName.Text = item[0];
            tb_itemPrice.Text = item[1].ToString();
            tb_itemDesc.Text = item[2].ToString();
            cb_isRec.Checked = Convert.ToBoolean(Convert.ToInt32(item[3]));
        }
        protected void EditItem(object sender, EventArgs e)
        {
            if (client.UpdateItem(Convert.ToInt32(lbl_itemId.Text), tb_itemName.Text, Convert.ToDouble(tb_itemPrice.Text), tb_itemDesc.Text, cb_isRec.Checked) == 1)
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "Edit Success", "alert('Edit Successfully')", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, GetType(), "Edit Failure", "alert('Edit Failed')", true);
            }
        }
    }
}