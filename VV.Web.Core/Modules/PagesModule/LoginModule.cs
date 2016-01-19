using Nancy;
using Nancy.Authentication.Forms;
using Nancy.ModelBinding;
using Nancy.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VV.DataObjects;
using VV.Web.Core.Models;
using VV.Web.Core.Services;

namespace VV.Web.Core.Modules
{
    public class LoginModule : NancyModule
    {
        private readonly IMembershipService _membership;

        public LoginModule(IMembershipService membership)
        {
            _membership = membership;

            Get["/pages/login"] = (parameters) =>
            {
                var model = new LoginModel() { Id = Guid.NewGuid().ToString() };
                return View["Login.cshtml", model];
            };

            Post["/login", true] = async (x, ct) =>
            {
                LoginModel registerAttempt = this.Bind<LoginModel>(); //model binding!
                return await LoginValidation(registerAttempt);

            };

            Get["pages/logout"] = LogOut;
        }

        private async Task<dynamic> LoginValidation(LoginModel registerAttempt)
        {
            var validationError = "";
            var failedValidation = false;

            if (string.IsNullOrEmpty(registerAttempt.Username))
            {
                failedValidation = true;
                validationError += string.Format("Must provide a username!<br>");
            }
            else
            {
                //check to see if a username is available
                var userNameAvailable = await _membership.IsUserNameAvailable(registerAttempt.Username);
                if (!userNameAvailable)
                {
                    validationError += string.Format("{0} is already taken. Please pick another username.<br>",
                        registerAttempt.Username);
                    failedValidation = true;
                }
            }

            if (string.IsNullOrEmpty(registerAttempt.Password))
            {
                failedValidation = true;
                validationError += string.Format("Must provide a password!<br>");
            }

            if (failedValidation)
            {
                ViewBag.ValidationError = validationError;
                var model = new LoginModel() { Id = Guid.NewGuid().ToString() };
                return View["Login.cshtml", model];
            }

            var registerResult = await _membership.LoginUser(
            registerAttempt.Id, registerAttempt.Username, registerAttempt.Password);

            //success!
            if (!string.IsNullOrWhiteSpace(registerResult.Guid) && registerResult.Claims.Count > 0)
            {

                var userDB = new UserDatabase();
                var guid = UserDatabase.ValidateUser(registerResult.UserName, "password");

                return this.LoginAndRedirect((Guid)guid, DateTime.Now.AddSeconds(30), "/pages");
            }
            else //failure!
            {
                ViewBag.ValidationError = string.Format("Unable to login as {0}, Please try again.",
                 registerAttempt.Username);
                var model = new LoginModel() { Id = Guid.NewGuid().ToString() };
                return View["Login.cshtml", model];
            }
        }

        public dynamic LogOut(dynamic parameters)
        {
            return this.LogoutAndRedirect("~/");
        }


    }
}
