using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDPHeaven
{
    public partial class DiningMain : System.Web.UI.Page
    {
        MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            foreach (Outlet outlet in client.GetOutlets())
            {
                PHolderCards.Controls.Add(new LiteralControl("<div class='card' style='width:200px'>"));
                PHolderCards.Controls.Add(new LiteralControl("<div class='card-body'>"));
                class="card-title" outlet.name;
                class="card-text" outlet.description;
                PHolderCards.Controls.Add(new LiteralControl("</div>"));
                PHolderCards.Controls.Add(new LiteralControl("</div>"));
            }*/
            
            LbOutlet1Name.Text = client.GetOutletName(1);
            LbOutlet1Desc.Text = client.GetOutletDesc(1);

            LbOutlet2Name.Text = client.GetOutletName(2);
            LbOutlet2Desc.Text = client.GetOutletDesc(2);
        }
        protected void ViewOutlet1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Outlet.aspx?O=1");
        }
        protected void ViewOutlet2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Outlet.aspx?O=2");
        }

        
    }
}