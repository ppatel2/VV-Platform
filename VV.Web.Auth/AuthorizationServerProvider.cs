using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VV.Web.DataAccess;
using VV.Proxy;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;

namespace VV.Web.Auth
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            BioConnectAPIProxy proxy = new BioConnectAPIProxy();

            if (!proxy.AuthenticateUser(context.UserName, context.Password))
            {
                context.SetError("invalid_grant", "The user name or password is incorrect.");
                return;
            }

            VV.Proxy.BioConnectAPI.SecurityTokenDto token = proxy.RetrieveSecurityToken(context.UserName, context.Password);

            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, token.UserName));
            identity.AddClaim(new Claim(ClaimTypes.Role, token.Level));
            //identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, token.Id.ToString()));
            
            context.Validated(identity);
        }
    }
}
