using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDPHeaven
{
    public partial class DinePayed : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnGoHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("DiningMain.apx", false);
        }
    }
}