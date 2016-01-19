using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VV.DataObjects;
using VV.Web.Core.HelperClasses;

namespace VV.Web.Core.Services
{
    public class MembershipService : IMembershipService
    {
        public Task<UsersAdminDataObject> LoginUser(string guid, string username, string password)
        {
            if (username == "test@test.com")
                return Task.FromResult(new UsersAdminDataObject()
                {
                    Claims = new ObservableCollection<string>() { "Admin" },
                    Guid = "0308dd43-821d-4d2b-a500-fb0bd0dea3b6",
                    HashedPassword = Crypto.Encrypt(password),
                    UserName = username
                });
            else
                return Task.FromResult(new UsersAdminDataObject());
        }

        public Task<bool> IsUserNameAvailable(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return Task.FromResult(false);
            else if (username == "ppatel")
                return Task.FromResult<bool>(true);
            else
                return Task.FromResult(true);
        }
        

        public Task<User> GetUser(string userGuid)
        {
            return Task.FromResult(GetUserNonAsync(userGuid));
        }

        public User GetUserNonAsync(string userGuid)
        {
            if (userGuid == "0308dd43-821d-4d2b-a500-fb0bd0dea3b6")
                return new User()
                {
                    Credential = new UsersAdminDataObject()
                    {
                        Claims = new ObservableCollection<string>() { "Admin" },
                        Guid = "0308dd43-821d-4d2b-a500-fb0bd0dea3b6",
                        HashedPassword = "test",
                        UserName = "ppatel"
                    },
                    FirstName = "Pritesh",
                    LastName = "Patel"
                };
            else
                return new User()
                {
                    Credential = new UsersAdminDataObject()
                    {
                        Claims = new ObservableCollection<string>(),
                        Guid = "0308dd43-821d-4d2b-a500-fb0bd0dea3b6",
                    },
                };
        }

        public Task<List<string>> GetUser(string UserName, string password)
        {
            return Task.FromResult(new List<string> { "Admin" });
        }
        
    }
}
