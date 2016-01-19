using System.Collections.Generic;
using VV.DataObjects;

namespace VV.Web.DataAccess
{
    public interface IDataAccess
    {
        List<UsersDataObject> GetUserList(string filter);

        UsersDataObject GetUserByID(int userID);

        UsersDataObject GetUserByExternalID(string externalID);

        List<ReadersStubDataObject> GetReadersStubs(string filterStr);

        ReadersDataObject GetReaderByID(int readerID);

        ReadersDataObject GetReaderDetailsByDeviceID(long readerID);

        int InsertUser(string externalID, string name, bool bDeviceAdministrator);

        void InsertUserCard(string cardExternalId, string badgeNumber, bool isActive, string PIN, int userId);

        void DeleteUserByExternalID(string externalID);

        void UpdateUser(UsersDataObject usersDO);

        void UpdateCard(CardDataObject cardDO);

        void DeleteCardByExternalID(string externalID);
        List<Messages> GetMessages(string userName, int numOfRecords);
    }
}