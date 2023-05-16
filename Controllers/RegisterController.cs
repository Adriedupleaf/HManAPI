using Firebase.Auth;
using HManAPI.Domain.Entities.User;
using HManAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HManAPI.Controllers
{
    public class RegisterController : Controller
    {
        public RegisterController()
        {
        }

        // GET: Register
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Index(URegisterData model)
        {
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(WebApiConfig.getApiKey()));
                var a = await auth.CreateUserWithEmailAndPasswordAsync(model.Email, model.Password, model.Email, false);
                return RedirectToAction("Index", "Login");
                //ModelState.AddModelError(string.Empty, "Please Verify your email then login Plz.");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View();
        }
    }
}