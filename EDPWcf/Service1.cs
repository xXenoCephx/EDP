using EDPWcf.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EDPWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public int CreateRoom(string id, string pwd, string host)
        {
            Room room = new Room(id, pwd, host);
            return room.Insert();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public int Validate(string JRoomID, string JRoomPassword)
        {
            Room room = new Room();
            return room.Validate(JRoomID, JRoomPassword);
        }

        public int ValidateRoomID(string RoomID)
        {
            Room room = new Room();
            return room.ValidateID(RoomID);
        }
        public string Get_Room_Password(string RoomID)
        {
            Room room = new Room();
            return room.Get_Room_password(RoomID);
        }
        //Dine
        public List<List<string>> GetItems(int outletId)
        {
            OutletItem outletItem = new OutletItem();
            return outletItem.getItem(outletId);

        }
        public string GetOutletName(int outletId)
        {
            Outlet outlet = new Outlet();
            return outlet.getName(outletId);
        }
        public string GetOutletDesc(int outletId)
        {
            Outlet outlet = new Outlet();
            return outlet.getDesc(outletId);
        }
        public List<Outlet> GetOutlets()
        {
            Outlet outlet = new Outlet();
            return outlet.getOutlets();
        }
        public List<OutletItem> GetItemList(int outletId)
        {
            OutletItem outletItem = new OutletItem();
            return outletItem.GetItemList(outletId);
        }

        public int AddMenuItem(int outletId, string itemName, double itemPrice, string itemDesc, bool isRecommend)
        {
            OutletItem outletItem = new OutletItem(outletId, itemName, itemPrice, itemDesc, isRecommend);
            return outletItem.Insert();
        }

        public List<string> SelectItem(int ItemId)
        {
            OutletItem outletItem = new OutletItem();
            return outletItem.SelectItem(ItemId);
        }

        public int UpdateItem(int ItemId, string itemName, double itemPrice, string itemDesc, bool isRecommend)
        {
            OutletItem outletItem = new OutletItem();
            return outletItem.updateItem(ItemId, itemName, itemPrice, itemDesc, isRecommend);
        }
        public bool ValidateUser(string email)
        {
            User user = new User();
            return user.ValidateUser(email);
        }

        public int SignUp(string Name, string Password, string Email)
        {
            User user = new User(Name, Password, Email);
            return user.Insert();
        }

        public bool ValidateLogin(string Email, string Password)
        {
            User user = new User();
            return user.Login(Email, Password);
        }
        public int CreateOrder(string email, string contactNum, string deliverAdd, string cardNum, string secNum, string cardExp, byte[] ki, byte[] iv)
        {
            Order order = new Order(email, contactNum, deliverAdd, cardNum, secNum, cardExp, ki, iv);
            return order.CreateOrder();
        }
    }
}
