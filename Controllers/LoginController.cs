using Firebase.Auth;
using HManAPI.BusinessLogic;
using HManAPI.BusinessLogic.Interfaces;
using HManAPI.Domain;
using HManAPI.Domain.Entities.User;
using HManAPI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Owin.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HManAPI.Controllers
{
    public class LoginController : Controller
    {
          private readonly ISessionBL _session;
          public LoginController()
          {
               _session = new BussinesLogic().GetSessionBL();
          }

          // GET: Login
          [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Login
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Index(string returnUrl)
        {
            try
            {
                // Verification.
                if (this.Request.IsAuthenticated)
                {

                    return this.RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // Info.
            return this.View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(ULoginData model, string returnUrl)
        {

            try
            {
                // Verification.
                if (ModelState.IsValid)
                {
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(WebApiConfig.getApiKey()));
                    var ab = await auth.SignInWithEmailAndPasswordAsync(model.Email, model.Password);
                    //ClaimIdentities(model.Email,false);
                    string token = ab.FirebaseToken;
                    var user = ab.User;
                    if (token != "")
                    {

                        this.SignInUser(user.Email, token, false);
                        return this.RedirectToAction("Index", "Home");

                    }
                    else
                    {
                        // Setting.
                        ModelState.AddModelError(string.Empty, "Invalid username or password.");
                    }
                }
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }

            // If we got this far, something failed, redisplay form
            return this.View(model);
        }
        private void SignInUser(string email, string token, bool isPersistent)
        {
            // Initialization.
            var claims = new List<Claim>();

            try
            {
                // Setting
                claims.Add(new Claim(ClaimTypes.Name, email));
                claims.Add(new Claim(ClaimTypes.Email, email));
                claims.Add(new Claim(ClaimTypes.UserData, email));
                claims.Add(new Claim(ClaimTypes.Authentication, token));
                var claimIdenties = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
                var ctx = Request.GetOwinContext();
                var authenticationManager = ctx.Authentication;
                // Sign In.
                authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, claimIdenties);
            }
            catch (Exception ex)
            {
                // Info
                throw ex;
            }
        }
    }
}