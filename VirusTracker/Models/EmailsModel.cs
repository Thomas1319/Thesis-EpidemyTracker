using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirusTracker.Models
{
    public class EmailsModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string doctorId { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string patientId { get; set; }
        [Required]
        public string content { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 2)]
        public string subject { get; set; }

        [Required]
        [RegularExpression(@"[^@]+@[^\.]+\..+")]
        public string fromAddress { get; set; }
        [Required]
        [RegularExpression(@"[^@]+@[^\.]+\..+")]
        public string toAddress { get; set; }
        [Required]
        public DateTime date { get; set; }
    }
}
