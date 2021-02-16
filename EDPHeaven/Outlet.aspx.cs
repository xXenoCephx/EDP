using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDPHeaven
{
    public partial class Outlet : System.Web.UI.Page
    {
        MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            int outletid = Convert.ToInt32(Request.QueryString["O"]);
            LbOutName.Text = client.GetOutletName(outletid);
            LbOutDesc.Text = client.GetOutletDesc(outletid);
        }
    }
}