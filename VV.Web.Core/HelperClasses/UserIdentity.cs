using Nancy.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

namespace VV.Web.Core.HelperClasses
{
    public class UserIdentity : IUserIdentity
    {
        private ClaimsPrincipal claimsPrincipal;

        public UserIdentity()
        {

        }

        public UserIdentity(ClaimsPrincipal claimsPrincipal)
        {
            this.claimsPrincipal = claimsPrincipal;
        }

        public IEnumerable<string> Claims
        {
            get
            {
                var claims = claimsPrincipal.Claims;
                var ListOfClaims = new List<string>();
                foreach (var cl in claims)
                {
                    ListOfClaims.Add(cl.Value);
                }
                return ListOfClaims;
            }
        }

        public string UserName
        {
            get
            {
                return claimsPrincipal.Identity.Name;
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return claimsPrincipal.Identity.IsAuthenticated;
            }
        }
        public string AuthenticationType
        {
            get
            {
                return claimsPrincipal.Identity.AuthenticationType;
            }
        }
    }
}
