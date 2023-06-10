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
        [StringLength(50, ErrorMessage = "The {0} must be at least {4} characters long.", MinimumLength = 4)]

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
        [Range(1, 8, ErrorMessage = "Value for {0} must be between {1} and {8}.")]
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
