using EDPWcf.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace EDPWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        //User
        [OperationContract]
        int SignUp(string Name, string Password, string Email);
        [OperationContract]
        bool ValidateLogin(string Email, string Password);

        //Collab
        [OperationContract]
        int CreateRoom(string id, string password, string host);
        [OperationContract]
        int Validate(string JRoomID, string JRoomPassword);
        [OperationContract]
        int ValidateRoomID(string RoomID);
        [OperationContract]
        string Get_Room_Password(string RoomID);

        //Dine
        [OperationContract]
        List<List<string>> GetItems(int outletId);
        [OperationContract]
        string GetOutletName(int outletId);
        [OperationContract]
        string GetOutletDesc(int outletId);
        [OperationContract]
        List<Outlet> GetOutlets();
        [OperationContract]
        int CreateOrder(string email, string contactNum, string deliverAdd, string cardNum, string secNum, string cardExp, byte[] ki, byte[] iv);

        [OperationContract]
        List<OutletItem> GetItemList(int outletId);
        [OperationContract]
        int AddMenuItem(int outletId, string itemName, double itemPrice, string itemDesc, bool isRecommend);
        [OperationContract]
        List<string> SelectItem(int ItemId);
        [OperationContract]
        int UpdateItem(int ItemId, string itemName, double itemPrice, string itemDesc, bool isRecommend);
        [OperationContract]
        bool ValidateUser(string email);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "EDPWcf.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
