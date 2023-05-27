using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace HManAPI.Models
{
    public class ServerModel
    {
        //public int id { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }
        [Display(Name = "Public?")]
        public bool isPublic { get; set; }
        [Display(Name = "Word")]
        public string word { get; set; }
        [Display(Name = "Server Name")]
        public string name { get; set; }
        [Display(Name = "Players Number")]
        public int players { get; set; }
    }
    public class Session
    {
        public string serverName { get; set; }
        public string user { get; set; }
    }
}
