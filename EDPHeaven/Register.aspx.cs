using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDPHeaven
{
    public partial class Register : System.Web.UI.Page
    {
        MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RegBtn_Click(object sender, EventArgs e)
        {
            if (client.ValidateUser(Email.Text))
            {
                Email.Text = "";
                Password.Text = "";
                ScriptManager.RegisterStartupScript(Page, GetType(), "User in Database", "alert('This email has already been used. Please try again.')", true);
            }
            else
            {
                if (client.SignUp(userName.Text, Password.Text, Email.Text) == 1)
                {
                    ScriptManager.RegisterStartupScript(Page, GetType(), "User Created", "alert('Account successfully created')", true);
                    Response.Redirect("Login");
                }
            }
        }
    }
}