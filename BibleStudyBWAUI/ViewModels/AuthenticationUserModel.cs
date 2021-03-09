using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BibleStudyBWAUI.ViewModels
{
    public class AuthenticationUserModel
    {   
        [Required(ErrorMessage="Email Address is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required.")]
        public string Password { get; set; }

    }
}
