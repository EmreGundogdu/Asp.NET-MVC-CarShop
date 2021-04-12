using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Car.Models
{
    public class UpdateProfile
    {
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        public string Id { get; set; }
        [Required]
        [DisplayName("Surname")]
        public string Surname { get; set; }
        [Required]
        [DisplayName("Username")]
        public string Username { get; set; }
        [Required]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage ="Please enter valid email")]
        public string Email { get; set; }
    }
}