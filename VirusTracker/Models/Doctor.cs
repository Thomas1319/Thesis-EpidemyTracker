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


        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string firstName { get; set; }


        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string lastName { get; set; }


       /* [Required]
        [StringLength(13, MinimumLength = 9)]

        public string phoneNumber { get; set; }*/


        /*[Required]
        [StringLength(60)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string emailAddress { get; set; }*/


        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string password { get; set; }

        public ICollection<Patient> patients { get; set; }
    }
}
