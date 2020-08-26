using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirusTracker.Models
{
    public class SentimentModel
    {
        public int Id { get; set; }
        [Required]
        public int patientId { get; set; }
        [Required]
        public DateTime timestamp { get; set; }
        [Required]
        public double sentiment { get; set; }
    }
}
