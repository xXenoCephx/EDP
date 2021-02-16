using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDPHeaven
{
    public partial class CollabMain : System.Web.UI.Page
    {
        MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void JRoomBtn_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "JRoomModal", "$('#JRoomModal').modal();", true);
        }

        protected void DocumentBtn_Click(object sender, EventArgs e)
        {

        }

        protected void CRoomBtn_Click(object sender, EventArgs e)
        {
            /*if (Session["User"] != null)
            {
                if (client.ValidateUser(Session["User"].ToString()))
                {*/
                    Random rand = new Random();
                    int id = rand.Next(100000, 999999);
                    while (client.ValidateRoomID(id.ToString()) != 0)
                    {
                        id = rand.Next(100000, 999999);
                    }
                    int length = rand.Next(10, 15);
                    string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!&%$";
                    StringBuilder pwd = new StringBuilder();
                    for (int i = 0; i < length; i++)
                    {
                        pwd.Append(valid[rand.Next(valid.Length)]);
                    }
                    int result = client.CreateRoom(id.ToString(), pwd.ToString(), "testmail@mail.net");
                    if (result == 1)
                    {
                        Session["Created Room"] = id.ToString();

                        string guid = Guid.NewGuid().ToString();
                        Session["AuthToken"] = guid;
                        Response.Cookies.Add(new HttpCookie("AuthToken", guid));

                        Response.Redirect("Room.aspx?Id=" + HttpUtility.HtmlEncode(id) + "&State=Create");                                     //Redirect to Correct Room Page
                    }
                    else
                    {
                        lblMessage.Visible = true;
                        lblMessage.Text = "SQL Error. Room Creation Unsuccessful.";
                        lblMessage.ForeColor = Color.Red;
                    }
                /*}
                else
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "Create Failed", "alert('You are not a registered user. Please Login')", true);
                }
            }*/
        }
        protected void JoinRoomBtn_Click(object sender, EventArgs e)
        {
            int result = client.Validate(tb_JRoomID.Text, tb_JRoomPass.Text);
            if (result == 1)
            {
                Session["Created Room"] = tb_JRoomID.Text.ToString();
                string guid = Guid.NewGuid().ToString();
                Session["AuthToken"] = guid;
                Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                Response.Redirect("Room.aspx?Id=" + HttpUtility.HtmlEncode(tb_JRoomID.Text) + "&State=Join");
            }
            else
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "JRoomModal", "$('#JRoomModal').modal('show');", true);
                tb_JRoomID.Text = "";
                tb_JRoomPass.Text = "";
                lbl_JError.Visible = true;
                lbl_JError.Text = "You have entered a wrong ID or password. Please try again.\nIf the issue persists, please contact administrators.";
                lbl_JError.ForeColor = Color.Red;
            }
        }
    }
}