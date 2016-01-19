using System.Collections.Generic;
using System.Threading.Tasks;
using VV.DataObjects;

namespace VV.Web.Core.Services
{
    public interface IMembershipService
    {
        Task<bool> IsUserNameAvailable(string username);
        Task<UsersAdminDataObject> LoginUser(string guid, string username, string password);
        Task<User> GetUser(string userGuid);
        User GetUserNonAsync(string userGuid);
        Task<List<string>> GetUser(string UserName, string password);
    }
}