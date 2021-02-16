using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDPHeaven
{
    public partial class Room : System.Web.UI.Page
    {
        MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Created Room"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("CollabMain.aspx");
                }
                else
                {
                    RoomID.Text = "Room ID: " + Request.QueryString["Id"];
                    RoomPassword.Text = "Room Password: " + client.Get_Room_Password(Request.QueryString["Id"]);
                    if (Request.QueryString["State"] == "Join")
                    {
                        RoomJoin();
                    }
                }
            }
            else
            {
                Response.Redirect("CollabMain.aspx");
            }
        }
        protected void RoomJoin()
        {
            ScriptManager.RegisterStartupScript(Page, GetType(), "call()", "<script>call()</script>", false);
        }

        protected void Disconnect_Click(object sender, EventArgs e)
        {
            Response.Redirect("CollabMain.aspx", true);
        }
    }
}