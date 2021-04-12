using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Car.Models
{
    public class ChangePassword
    {
        [Required]
        [DisplayName("Old Password")]
        public string OldPassword { get; set; }
        [Required]
        [DisplayName("New Password")]
        [StringLength(100,MinimumLength =5,ErrorMessage ="Your password must be at least 5 chracter")]
        public string NewPassword { get; set; }
        [Required]
        [DisplayName("New Password")]
        [Compare("New Password",ErrorMessage ="Passwords are different")]
        public string ConNewPassword { get; set; }
    }
}