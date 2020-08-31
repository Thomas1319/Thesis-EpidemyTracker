using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace VirusTracker.Models
{
    public class Doctor: IdentityUser
    {
        /*[Key]
        public int doctorId { get; set; }*/


        [Required(ErrorMessage = "First name cannot be empty")]
        [StringLength(40, MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "This field accepts only upper and lower case letters.")]
        public string firstName { get; set; }


        [Required(ErrorMessage = "Last name cannot be empty")]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "This field accepts only upper and lower case letters.")]
        public string lastName { get; set; }


       /* [Required]
        [StringLength(13, MinimumLength = 9)]

        public string phoneNumber { get; set; }*/


        /*[Required]
        [StringLength(60)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string emailAddress { get; set; }*/


        [Required(ErrorMessage ="Password cannot be empty")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Invalid length")]
        public string password { get; set; }

        public ICollection<Patient> patients { get; set; }
    }
}
