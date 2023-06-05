using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using HManAPI.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System;

namespace HManAPI.Controllers
{
    public class ServerController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "yXdIGF85q8DxR6OJSGyTh9MwzLvqrcxSHrsBU6pJ",
            BasePath = "https://hman-ram212-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;
        List<ServerModel> list;
        // GET: Server
        [Authorize]
        public ActionResult Index()
        {
            list = updateServers();
            return View(list);
        }
       
        [HttpGet]
        public ActionResult CreateServer()
        {

            return View();
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateServer(ServerModel server)
        {

            try
            {
                // Verification.
                if (ModelState.IsValid)
                {
                    client = new FireSharp.FirebaseClient(config);
                    list = updateServers();
                    SetResponse response = client.Set("Servers/" + list.Count, server);
                    var newsession = new Session();
                    Users newUser = new Users{
                        name = User.Identity.GetUserName(),
                        role = "Owner"
                    };
                    newsession.serverName = server.name;
                    newsession.users = new List<Users>
                    {
                        newUser
                    };
                    client.Set("Session/" + list.Count, newsession);
                    return RedirectToAction("Index", "Game",new { serverName = server.name});
                }
            }
            catch (Exception ex)
            {
                // Info
                Console.Write(ex);
            }
            ModelState.AddModelError(string.Empty, "Error.");
            // If we got this far, something failed, redisplay form
            return this.View(server);
        }
        public List<ServerModel> updateServers()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Servers");
            return JsonConvert.DeserializeObject<List<ServerModel>>(response.Body);
        }
        
    }
}
