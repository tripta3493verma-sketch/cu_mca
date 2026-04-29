using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentProject.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Enter your Full Name")]
        [Display(Name ="Full Name")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Please enter email address")]
        [Display(Name = "Email address")]
        [EmailAddress(ErrorMessage = "Enter valid email address")]

        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter strong password")]
        [Display(Name = "Password")]
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
