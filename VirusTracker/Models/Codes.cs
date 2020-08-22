using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VirusTracker.Models
{
    public class Codes
    {
        public int Id { get; set; }

        [Required]
        public string Code { get; set; }

        [ForeignKey("doctorId")]
        public string doctorId { get; set; }
    }
}
