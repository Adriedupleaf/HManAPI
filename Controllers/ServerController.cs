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
        public ServerController() {
            updateServers();
        }
        // GET: Server
        [Authorize]
        public ActionResult Index()
        {
            
            return View(list);
        }
        public ActionResult Play()
        {
            
            return View();
        }
        public ActionResult CreateServer()
        {
            
            return View();
        }
        public void updateServers()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Servers");
            dynamic data = JsonConvert.DeserializeObject<dynamic>(response.Body);
            list = JsonConvert.DeserializeObject<List<ServerModel>>(response.Body);
        }
        
    }
}