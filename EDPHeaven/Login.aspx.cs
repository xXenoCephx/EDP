using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDPHeaven
{
    public partial class Login : System.Web.UI.Page
    {
        MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login_Click(object sender, EventArgs e)
        {
            if (client.ValidateLogin(Email.Text,Password.Text))
            {
                Response.Redirect("/");
            }
            else
            {
                error_lbl.Text = "Your Email or Password is Incorrect. Please Try Again.";
            }
        }
    }
}