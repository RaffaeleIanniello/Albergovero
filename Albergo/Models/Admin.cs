using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Albergo.Models
{
    public class Admin
    {
        public int IdAdmin { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        public int Password { get; set; }   
        public Admin() { }
        public Admin(string username, int password)
        {
            
            Username = username;
            Password = password;
        }   
    }
}