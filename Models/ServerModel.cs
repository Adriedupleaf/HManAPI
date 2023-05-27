using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HManAPI.Models
{
    public class ServerModel
    {
        //public int id { get; set; }
        public string password { get; set; }
        public bool isPublic { get; set; }
        public string word { get; set; }
        public string name { get; set; }
        public int players { get; set; }
    }
    public class Session
    {
        public string serverName { get; set; }
        public string user { get; set; }
    }
}