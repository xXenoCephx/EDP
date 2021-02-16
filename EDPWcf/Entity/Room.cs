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
    public class Room
    {
        public string Id { get; set; }
        public DateTime CRTime { get; set; }
        public string Host { get; set; }                                        //Replace object with entity class of User
        public string Password { get; set; }
        public List<object> Attendees { get; set; }                             //Replace object with entity class of User
        //public smth Recording { get; set; }
        public string finalHash { get; set; }

        public Room() { }
        public Room(string id, string pwd, string host)      //Replace object with entity class of User
        {
            Id = id;
            Password = pwd;
            CRTime = DateTime.Now;
            Host = host;
            Attendees = new List<object>();                                    //Replace object with entity class of User
        }
        public int Insert()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] saltbyte = new byte[8];
            rng.GetBytes(saltbyte);
            string salt = Convert.ToBase64String(saltbyte);

            SHA512Managed hashing = new SHA512Managed();

            string pwd = Password + salt;
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            string finalHash = Convert.ToBase64String(hashWithSalt);
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "INSERT INTO Room (RoomId, RoomPassword, RoomPasswordHash, CRTime, Host, Attendees) \nVALUES (@paraId, @paraPassword, @paraRoomPasswordHash, @paraCRTime, @paraHost, @paraAttendees)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraId", Id);
            sqlCmd.Parameters.AddWithValue("@paraPassword", salt);
            sqlCmd.Parameters.AddWithValue("@paraRoomPasswordHash", finalHash);
            sqlCmd.Parameters.AddWithValue("@paraCRTime", CRTime);
            sqlCmd.Parameters.AddWithValue("@paraHost", Host);
            sqlCmd.Parameters.AddWithValue("@paraAttendees", Attendees.ToString());

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
        public int Validate(string JRoomID, string JRoomPass)
        {
            int result = 0;
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "SELECT COUNT(*) FROM Room WHERE RoomID=@paraID";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraID", JRoomID);

            myConn.Open();
            if (validatePass(JRoomID, JRoomPass) == 1)
            {
                result = (int)sqlCmd.ExecuteScalar();
            }
            myConn.Close();
            return result;
        }
        public int ValidateID(string JRoomID)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand("SELECT COUNT(*) FROM Room WHERE RoomID=@paraID", myConn);

            sqlCmd.Parameters.AddWithValue("@paraID", JRoomID);

            myConn.Open();
            int result = (int)sqlCmd.ExecuteScalar();
            myConn.Close();
            return result;
        }
        public string Get_Room_passwordHash(string RoomID)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand("SELECT RoomPasswordHash FROM Room WHERE RoomID=@paraID", myConn);

            sqlCmd.Parameters.AddWithValue("@paraID", RoomID);

            string RoomPass = "";

            try
            {
                myConn.Open();
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["RoomPasswordHash"] != null)
                        {
                            if (reader["RoomPasswordHash"] != DBNull.Value)
                            {
                                RoomPass = reader["RoomPasswordHash"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                myConn.Close();
            }

            return RoomPass;
        }
        public string GetPasswordSalt(string RoomId)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand("SELECT RoomPassword FROM Room WHERE RoomID=@paraID", myConn);

            sqlCmd.Parameters.AddWithValue("@paraID", RoomId);

            string RoomPass = "";

            try
            {
                myConn.Open();
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["RoomPassword"] != null)
                        {
                            if (reader["RoomPassword"] != DBNull.Value)
                            {
                                RoomPass = reader["RoomPassword"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                myConn.Close();
            }

            return RoomPass;
        }
        public string Get_Room_password(string RoomId)
        {
            string result = "";
            string DBConnect = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand("SELECT RoomPassword FROM Room WHERE RoomID=@paraID", myConn);

            sqlCmd.Parameters.AddWithValue("@paraID", RoomId);

            try
            {
                myConn.Open();
                result = sqlCmd.ExecuteScalar().ToString();
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
        public int validatePass(string JRoomID, string JRoomPass)
        {
            int result = 0;
            SHA512Managed hashing = new SHA512Managed();
            string dbHash = Get_Room_passwordHash(JRoomID);
            string dbSalt = GetPasswordSalt(JRoomID);

            if (dbSalt != null && dbSalt.Length > 0 && dbHash != null && dbHash.Length > 0)
            {
                if (Convert.ToBase64String(hashing.ComputeHash(Encoding.UTF8.GetBytes(JRoomPass))) != dbHash)
                {
                    result = 1;
                }
                else
                {
                    string pwdWithSalt = JRoomPass + dbSalt;
                    byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
                    string userHash = Convert.ToBase64String(hashWithSalt);
                    if (userHash == dbHash)
                    {
                        result = 1;
                    }
                }
            }
            return result;
        }
    }
}
