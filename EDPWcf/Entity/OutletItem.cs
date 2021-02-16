using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EDPWcf.Entity
{
    public class OutletItem
    {
        public int ItemId { get; set; }
        public int ItemOutletId { get; set; }
        public string ItemName { get; set; }
        public double ItemPrice { get; set; }
        public string ItemDesc { get; set; }
        public bool IsRecommend { get; set; }
        private static List<OutletItem> itemList;
        public OutletItem() { }

        public OutletItem(int itemOutletId, string itemName, double itemPrice, string itemDesc, bool isRecommend)
        {
            ItemOutletId = itemOutletId;
            ItemName = itemName;
            ItemPrice = itemPrice;
            ItemDesc = itemDesc;
            IsRecommend = isRecommend;
        }
        public int getItemId()
        {
            int result;
            string myDb = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(myDb);
            SqlCommand sqlCmd = new SqlCommand("SELECT COUNT(*) FROM OutletItem;", connection);

            try
            {
                connection.Open();
                result = (int)sqlCmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public List<List<string>> getItem(int OutletId)
        {
            string myDb = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(myDb);
            SqlCommand getItem = new SqlCommand("SELECT ItemName,ItemPrice,ItemDesc,ItemImg FROM OutletItem WHERE OutletId=@paraOutletId;", connection);
            getItem.Parameters.AddWithValue("@paraOutletId", OutletId);

            connection.Open();


            List<List<string>> mylist = new List<List<string>>();
            using (SqlDataReader reader = getItem.ExecuteReader())
            {
                while (reader.Read())
                {
                    List<string> itemSpec = new List<string>();
                    itemSpec.Add(reader["ItemName"].ToString());
                    itemSpec.Add(reader["ItemPrice"].ToString());
                    itemSpec.Add(reader["ItemDesc"].ToString());
                    itemSpec.Add(reader["ItemImg"].ToString());
                    mylist.Add(itemSpec);
                }
            }
            connection.Close();
            return mylist;
        }
        public int Insert()
        {
            this.ItemId = getItemId() + 1;
            int result = 0;
            string myDB = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(myDB);
            SqlCommand sqlCmd = new SqlCommand("INSERT INTO OutletItem (OutletId, ItemName, ItemPrice, ItemDesc, isRecommend) VALUES (@OutletId, @ItemName, @ItemPrice, @ItemDesc, @isRecommend)", sqlConn);

            sqlCmd.Parameters.AddWithValue("@OutletId", ItemOutletId);
            sqlCmd.Parameters.AddWithValue("@ItemName", ItemName);
            sqlCmd.Parameters.AddWithValue("@ItemPrice", ItemPrice);
            sqlCmd.Parameters.AddWithValue("@ItemDesc", ItemDesc);
            sqlCmd.Parameters.AddWithValue("@isRecommend", Convert.ToInt16(IsRecommend));

            try
            {
                sqlConn.Open();
                result = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                sqlConn.Close();
            }
            return result;
        }
        public List<OutletItem> GetItemList(int outletId)
        {
            itemList = new List<OutletItem>();
            string myDB = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(myDB);
            SqlCommand sqlCmd = new SqlCommand("SELECT ItemName, ItemPrice, ItemDesc, isRecommend FROM OutletItem WHERE OutletId=@OutletId;", myConn);

            sqlCmd.Parameters.AddWithValue("@OutletId", outletId);

            try
            {
                myConn.Open();
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        itemList.Add(new OutletItem(outletId, reader["ItemName"].ToString(), Convert.ToDouble(reader["ItemPrice"]), reader["ItemDesc"].ToString(), Convert.ToBoolean(reader["isRecommend"])));
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
            return itemList;
        }
        public List<string> SelectItem(int itemId)
        {
            List<string> items = new List<string>();
            string myDb = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(myDb);
            SqlCommand sqlCmd = new SqlCommand("SELECT ItemName, ItemPrice, ItemDesc, isRecommend FROM OutletItem WHERE Id=Id;", connection);

            sqlCmd.Parameters.AddWithValue("@Id", itemId);

            try
            {
                connection.Open();
                using (SqlDataReader reader = sqlCmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        items.Add(reader["ItemName"].ToString());
                        items.Add(reader["ItemPrice"].ToString());
                        items.Add(reader["ItemDesc"].ToString());
                        items.Add(reader["isRecommend"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return items;
        }
        public int updateItem(int itemid, string itemName, double itemPrice, string itemDesc, bool isRecommend)
        {
            int result;
            string myDb = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            SqlConnection connection = new SqlConnection(myDb);
            SqlCommand sqlCmd = new SqlCommand("UPDATE OutletItem SET ItemName=@ItemName, ItemPrice=@ItemPrice, ItemDesc=@ItemDesc, isRecommend=@isRecommend WHERE Id=@ItemId;", connection);

            sqlCmd.Parameters.AddWithValue("@ItemName", itemName);
            sqlCmd.Parameters.AddWithValue("@ItemPrice", itemPrice);
            sqlCmd.Parameters.AddWithValue("@ItemDesc", itemDesc);
            sqlCmd.Parameters.AddWithValue("@isRecommend", Convert.ToInt16(isRecommend));
            sqlCmd.Parameters.AddWithValue("@ItemId", itemid);

            try
            {
                connection.Open();
                result = sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}
