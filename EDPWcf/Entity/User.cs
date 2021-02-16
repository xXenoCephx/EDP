using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EDPWcf.Entity
{
    public class User
    {
        private object hashing;

        int id { get; set; }
        string name { get; set; }
        string password { get; set; }
        string email { get; set; }

        public User() { }
        public User(string Name, string Password, string Email)
        {
            name = Name;
            password = Password;
            email = Email;
        }
        public int getId()
        {
            int result;
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Reg_User;", myConn);

            try
            {
                myConn.Open();
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                myConn.Close();
            }
            return result;
        }
        public int Insert()
        {

            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] saltbyte = new byte[8];
            rng.GetBytes(saltbyte);
            string salt = Convert.ToBase64String(saltbyte);

            SHA512Managed hashing = new SHA512Managed();

            string pwd = password + salt;
            byte[] plainHash = hashing.ComputeHash(Encoding.UTF8.GetBytes(password));
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            string finalHash = Convert.ToBase64String(hashWithSalt);

            string sqlStmt = "INSERT INTO User (Username, Email, PSalt, PHash) \nValues (@paraUsername, @paraEmail, @paraSalt, @paraHash)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraUsername", name);
            sqlCmd.Parameters.AddWithValue("@paraEmail", email);
            sqlCmd.Parameters.AddWithValue("@paraSalt", salt);
            sqlCmd.Parameters.AddWithValue("@paraHash", finalHash);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }
        public bool ValidateUser(string email)
        {
            bool result;
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Reg_User WHERE Email=@paraEmail", myConn);

            cmd.Parameters.AddWithValue("@paraEmail", email);

            myConn.Open();
            result = cmd.ExecuteNonQuery() == 1 ? true : false;

            myConn.Close();
            return result;
        }
        public bool Login(string email, string password)
        {
            bool result = false;
            if (ValidateUser(email))
            {
                SHA512Managed hashing = new SHA512Managed();
                string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                SqlConnection myConn = new SqlConnection(DBConnect);
                SqlCommand cmd = new SqlCommand("SELECT PSalt, PHash FROM Reg_User WHERE Email=@paraEmail", myConn);

                cmd.Parameters.AddWithValue("@paraEmail", email);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["PSalt"] != null && reader["PSalt"].ToString().Length > 0 && reader["PHash"] != null && reader["PHash"].ToString().Length > 0)
                        {
                            string pwdWithSalt = password + reader["PSalt"].ToString();
                            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
                            string userHash = Convert.ToBase64String(hashWithSalt);
                            if (userHash == reader["PHash"].ToString())
                            {
                                result = true;
                            }
                            else
                            {
                                result = false;
                            }
                        }
                        else
                        {
                            result = false;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
            return result;
        }
    }
}
