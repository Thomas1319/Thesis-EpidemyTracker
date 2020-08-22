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
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string firstName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string lastName { get; set; }
        [Required]
        [RegularExpression(@"[^@]+@[^\.]+\..+")]
        public string emailAddress { get; set; }
        public string status { get; set; }
    }
}
