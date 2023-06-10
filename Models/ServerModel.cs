using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HManAPI.Models
{
    public class ServerModel
    {
        //public int id { get; set; }
        [Display(Name = "Password")]

        public string password { get; set; }
        [Display(Name = "Is public?")]

        public bool isPublic { get; set; }
        [Required]
        [Display(Name = "Word")]

        public string word { get; set; }
        [Required]
        [Display(Name = "Server Name")]

        public string name { get; set; }
        [Required]
        [Display(Name = "Number of Players")]

        public int players { get; set; }
    }
    public class Session
    {
        public string serverName { get; set; }
        public List<Users> users { get; set; }
    }
    public class Users
    {
        public string name { get; set; }
        public string role { get; set; }
    }
}
