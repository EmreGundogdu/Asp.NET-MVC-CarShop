using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Car.Models
{
    public class Register
    {
        [Required]
        [DisplayName("Your Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Your Surname")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Your Username")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Your Email")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }
        [Required]
        [DisplayName("Your Password")]
        public string Password { get; set; }
        [Required]
        [DisplayName("Your RePassword")]
        [Compare("Password",ErrorMessage ="Passwords Are Different")]
        public string RePassword { get; set; }

    }
}