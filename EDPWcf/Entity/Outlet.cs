using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDPWcf.Entity
{
    public class Outlet
    {
        public string OutletName { get; set; }
        public string OutletEmail { get; set; }
        public string OutletDescription { get; set; }
        public string OutletImg { get; set; }
        private static List<Outlet> outletList;

        public Outlet() { }
        public Outlet(string outletName, string outletEmail, string outletDesc, string imgPath)
        {
            OutletName = outletName;
            OutletEmail = outletEmail;
            OutletDescription = outletDesc;
            OutletImg = imgPath;
        }

        public string getDesc(int OutletId)
        {
            string myDb = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(myDb);
            SqlCommand getOutletDesc = new SqlCommand("SELECT Description FROM Outlet WHERE OutletId=@paraOutletId;", connection);
            getOutletDesc.Parameters.AddWithValue("@paraOutletId", OutletId);
            connection.Open();
            string result = getOutletDesc.ExecuteScalar().ToString();
            connection.Close();
            return result;
        }

        public string getName(int OutletId)
        {
            string myDb = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(myDb);
            SqlCommand getOutletName = new SqlCommand("SELECT Name FROM Outlet WHERE OutletId=@paraName;", connection);
            getOutletName.Parameters.AddWithValue("@paraName", OutletId);
            connection.Open();
            string result = getOutletName.ExecuteScalar().ToString();
            connection.Close();
            return result;
        }
        public List<Outlet> getOutlets()
        {
            outletList = new List<Outlet>();
            string myDB = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(myDB);
            SqlCommand sqlCmd = new SqlCommand("SELECT Name, Email, Description, Imgpath FROM Outlet;", myConn);

            try
            {
                myConn.Open();
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        outletList.Add(new Outlet(reader["Name"].ToString(), reader["Email"].ToString(), reader["Description"].ToString(), reader["Imgpath"] == null ? "" : reader["Imgpath"].ToString()));
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
            return outletList;
        }
    }
}
