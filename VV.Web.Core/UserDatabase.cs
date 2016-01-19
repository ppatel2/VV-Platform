using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Security.Claims;
using System.Security.Principal;

using Nancy.Authentication.Forms;
using Nancy;
using Nancy.Security;
using VV.Web.Core.HelperClasses;

namespace VV.Web.Core
{
    public class UserDatabase : IUserMapper
    {
        private static List<Tuple<string, string, Guid>> users = new List<Tuple<string, string, Guid>>();

        /// <summary>
        /// Needs to be refactored to allow for DB direct usage.
        /// </summary>

        static UserDatabase()
        {
            users.Add(new Tuple<string, string, Guid>("admin@test.com", "password", new Guid("55E1E49E-B7E8-4EEA-8459-7A906AC4D4C0")));
            users.Add(new Tuple<string, string, Guid>("testUser@test.com", "password", new Guid("56E1E49E-B7E8-4EEA-8459-7A906AC4D4C0")));
            users.Add(new Tuple<string, string, Guid>("test@test.com", "password", new Guid("0308dd43-821d-4d2b-a500-fb0bd0dea3b6")));
        }

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            var userRecord = users.FirstOrDefault(u => u.Item3 == identifier);

            return userRecord == null
                       ? null
                       : new UserIdentity(new ClaimsPrincipal(new GenericIdentity(userRecord.Item1)));
        }

        public static Guid? ValidateUser(string username, string password)
        {
            var userRecord = users.FirstOrDefault(u => u.Item1 == username && u.Item2 == password);

            if (userRecord == null)
            {
                return null;
            }

            return userRecord.Item3;
        }
        
    }
}
