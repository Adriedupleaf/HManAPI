using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using HManAPI.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using FireSharp.Extensions;

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
        //[HttpPost]
        public ActionResult Play(ServerModel sv)
        {
            if (checkSesion(sv, User.Identity.GetUserName()))
                return View();
            else return this.RedirectToAction("Index", "Server");
        }
        
        [HttpGet]
        public ActionResult CreateServer(string returnUrl)
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult CreateServer(ServerModel server, string returnUrl)
        {

            return View();
        }

        public List<ServerModel> updateServers()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Servers");
            return JsonConvert.DeserializeObject<List<ServerModel>>(response.Body);
        }
        public bool checkSesion(ServerModel sv,string user)
        {
            list = updateServers();
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Session");
            var res1 = JsonConvert.DeserializeObject<List<Session>>(response.Body);
            foreach (var item in res1)
            {
                if (item.serverName == sv.name) return true;
            }
            return false;
            
        }
    }
}
