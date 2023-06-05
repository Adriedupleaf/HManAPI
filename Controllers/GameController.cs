using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using HManAPI.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HManAPI.Controllers
{
    public class GameController : Controller
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "yXdIGF85q8DxR6OJSGyTh9MwzLvqrcxSHrsBU6pJ",
            BasePath = "https://hman-ram212-default-rtdb.europe-west1.firebasedatabase.app/"
        };
        IFirebaseClient client;

        // GET: Game
        public ActionResult Index(string serverName)
        {
            var server = getServerbyName(serverName);
            if (checkSesion(serverName)!=null&&server!=null)
            {
                addUserToSession(serverName);
                ViewBag.word = server.word;
                return View();
            }
            else return this.RedirectToAction("Index", "Server");
        }
        public ActionResult leaveSession(string sv) {
            client = new FireSharp.FirebaseClient(config);
            var users = checkSesion(sv).users;
            var userid = getUserId(users);
            if (users[userid].role == "Owner")
            {
                var id = getSessionsId(sv);
                client.Delete("Session/" + id);
                client.Delete("Servers/" + id);

            }
            else client.Delete("Session/" + getSessionsId(sv) + "/users/" + getUserId(users));
            return this.RedirectToAction("Index", "Server");
        }
        public void addUserToSession(string serverName)
        {
            var session = checkSesion(serverName);
            if (session!=null&&!checkSesionUsers(session))
            {
                client = new FireSharp.FirebaseClient(config);
                Users newUser = new Users
                {
                    name = User.Identity.GetUserName(),
                    role = "Guesser"
                };
                client.Set("Session/"+getSessionsId(serverName)+"/users/"+session.users.Count(),newUser);
            }
        }
        public ServerModel getServerbyName(string serverName)
        {

            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Servers");
            var list= JsonConvert.DeserializeObject<List<ServerModel>>(response.Body);
            foreach(ServerModel server in list)
            {
                if(server.name == serverName)return server;
            }
            return null;
        }
        public List<Session> getSessions()
        {
            client = new FireSharp.FirebaseClient(config);
            FirebaseResponse response = client.Get("Session");
            var res1 = JsonConvert.DeserializeObject<List<Session>>(response.Body);
            return res1;
        }
        public int getSessionsId(string sv)
        {
            int id = 0;
            var res1 = getSessions();
            foreach (var item in res1)
            {
                
                if (item.serverName == sv) return id;
                id++;
            }
            return -1;
        }
        public int getUserId(List<Users> users)
        {
            int id = 0;
            foreach (var item in users)
            {
                if (item.name == User.Identity.GetUserName()) return id;
                id++;
            }
            return -1;
        }
        public Session checkSesion(string sv)
        {

            var res1 = getSessions();
            foreach (var item in res1)
            {
                if (item.serverName == sv) return item;
            }
            return null;

        }
        public bool checkSesionUsers(Session session)
        {
            foreach (var user in session.users)
            {
                if (user.name == User.Identity.GetUserName()) return true;
            }
            return false;

        }
        public void sleaveSession(string sv)
        {
            

        }
    }
}