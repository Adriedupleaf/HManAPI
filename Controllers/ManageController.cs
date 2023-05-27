using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using HManAPI.Models;
using System.Web.UI.WebControls;
using Firebase.Auth;
using HManAPI.Domain.Entities.User;
using User = Firebase.Auth.User;

namespace HManAPI.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        public ManageController()
        {
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(UChangePasswordData Model, string returnUrl)
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(WebApiConfig.getApiKey()));
            var cp = auth.SignInWithEmailAndPasswordAsync(Model.Email, Model.OldPassword);
            
            return View();
        }


        //
        // GET: /Manage/SetPassword
        public ActionResult SetPassword()
        {
            return View();
        }


        //
        // GET: /Manage/Index
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            return View();
        }

        /*
        // POST: /Manage/SetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await UserManager.AddPasswordAsync(User.Identity.GetUserId(), model.NewPassword);
                if (result.Succeeded)
                {
                    var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                    if (user != null)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                    }
                    return RedirectToAction("Index", new { Message = ManageMessageId.SetPasswordSuccess });
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }*/


    }
}