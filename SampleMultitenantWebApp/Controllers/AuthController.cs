using BioConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace BioConnect.Controllers
{
    public class AuthController : Controller
    {
          // GET: Auth
          public ActionResult Login()
          {
               var model = new LoginModel();
               return View(model);
          }

          [HttpPost]
          public ActionResult Login(LoginModel model)
          {
               if (model.username.Trim() == "Entertech" && model.password.Trim() == "Bobcat")
               {
                    var identity = new ClaimsIdentity("AuthenticationCookie");
                    identity.AddClaims(new List<Claim>
                    {
                         new Claim(ClaimTypes.NameIdentifier, model.username),
                         new Claim(ClaimTypes.Name, model.username)
                    });
                    HttpContext.GetOwinContext().Authentication.SignIn(identity);

               }

               return View(model);
          }


          public ActionResult Logout(LoginModel model)
          {
               HttpContext.GetOwinContext().Authentication.SignOut();
               return Redirect("/");
          }
     }
}