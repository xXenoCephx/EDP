using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDPHeaven
{
    public partial class DinePayment : System.Web.UI.Page
    {
        MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
        byte[] Key;
        byte[] IV;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        protected void CreateOrder()
        {
            
        }
        private bool Validate_CardAndSec(string cardNum,string secNum) {
            if (cardNum.Length!=16 || secNum.Length != 3)
            {
                LbError.Text = "Please check you have entered your card number and security number correctly";
                LbError.Visible = true;
                return false;

            } else {
                bool validCard = Int64.TryParse(cardNum, out Int64 result1);
                bool validSec = Int32.TryParse(secNum, out int result2);
                if (!validCard||!validSec)
                {
                    LbError.Text = "Please enter a valid card number and security number correctly";
                    LbError.Visible = true;
                    return false;
                }
            }
            return true;
        }
        protected void BtnPay_Click(object sender, EventArgs e)
        {
            string inpCardNum = TbCardNum.Text;
            string inpSecNum = TbSecNum.Text;
            if (Validate_CardAndSec(inpCardNum, inpSecNum))
            {
                RijndaelManaged ciph = new RijndaelManaged();
                ciph.GenerateKey();
                Key = ciph.Key;
                IV = ciph.IV;
                //storeOrder
                client.CreateOrder(TbEmail.Text.Trim(), TbContactNum.Text.Trim(), TbDeliveryAdd.Text.Trim(), TbCardNum.Text.Trim(), TbSecNum.Text.Trim(), TbExpDate.Text, Key, IV);
                Response.Redirect("DinePayed.aspx", false);
            }

        }
    }
}