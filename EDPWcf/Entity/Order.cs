using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace EDPWcf.Entity
{
    public class Order
    {
        public string Email { get; set; }
        public string ContactNum { get; set; }
        public string BillAdd { get; set; }
        public string DeliverAdd { get;set; }
        public DateTime OrderTime { get; set; }
        public string CardNum { get; set; }
        public string CardSecNum { get; set; }
        public string CardExp { get; set; }
        public byte[] Ki { get; set; }
        public byte[] IV { get; set; }


        public Order() { }
        public Order(string email,string contactNum, string deliverAdd,string cardNum,string secNum,string cardExp,byte[] ki,byte[] iv)
        {
            Email = email;
            ContactNum = contactNum;
            BillAdd = deliverAdd;
            DeliverAdd = deliverAdd;
            OrderTime = DateTime.Now;
            CardNum = cardNum;
            CardSecNum = secNum;
            CardExp = cardExp;
            Ki = ki;
            IV = iv;
        }
        protected byte[] Encrypt(string data)
        {
            byte[] cipherText = null;
            try
            {
                RijndaelManaged ciph = new RijndaelManaged();
                ciph.GenerateKey();
                Ki = ciph.Key;
                IV = ciph.IV;
                ICryptoTransform encryptTransform = ciph.CreateEncryptor();
                //ICryptoTransform decryptTransform = cipher.CreateDecryptor();
                byte[] plainText = Encoding.UTF8.GetBytes(data);
                cipherText = encryptTransform.TransformFinalBlock(plainText, 0, plainText.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { }
            return cipherText;
        }
        public int CreateOrder()
        {
            int result = 0;
            string dbConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection dbConn = new SqlConnection(dbConnStr);
            try
            {
                using (dbConn)
                {
                    string cmdStr = "INSERT INTO Orders(Email,ContactNum,BillingAdd,DeliveryAdd,OrderDatetime,CardNum,CardSecNum,CardExp,Ki,IV) VALUES (@Email, @ContactNum, @BillAdd, @DeliverAdd, @OrderTime, @CardNum, @CardSecNum, @CardExp, @Ki, @IV)";
                    using (SqlCommand cmd = new SqlCommand(cmdStr))
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@Email", Email);
                        cmd.Parameters.AddWithValue("@ContactNum", ContactNum);
                        cmd.Parameters.AddWithValue("@BillAdd", BillAdd);
                        cmd.Parameters.AddWithValue("@DeliverAdd", DeliverAdd);
                        cmd.Parameters.AddWithValue("@OrderTime", DateTime.Now);
                        cmd.Parameters.AddWithValue("@CardNum", Encrypt(CardNum));
                        cmd.Parameters.AddWithValue("@CardSecNum", Encrypt(CardSecNum));
                        cmd.Parameters.AddWithValue("@CardExp", Encrypt(CardExp));
                        cmd.Parameters.AddWithValue("@Ki", Convert.ToBase64String(Ki));
                        cmd.Parameters.AddWithValue("@IV", Convert.ToBase64String(IV));

                        cmd.Connection = dbConn;
                        dbConn.Open();
                        result=cmd.ExecuteNonQuery();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                dbConn.Close();
            }
            return result;
        }
    }
}
