using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirusTracker.Models
{
    public class EnrollModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First name cannot be empty")]
        [StringLength(40, MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "This field accepts only upper and lower case letters.")]
        public string firstName { get; set; }


        [Required(ErrorMessage = "Last name cannot be empty")]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "This field accepts only upper and lower case letters.")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "E-mail address cannot be empty")]
        [RegularExpression(@"[^@]+@[^\.]+\..+", ErrorMessage = "E-mail address must have the format example@company.domain")]
        public string emailAddress { get; set; }
        public string status { get; set; }
    }
}
