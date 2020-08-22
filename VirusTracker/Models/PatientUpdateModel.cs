using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirusTracker.Models
{
    public class PatientUpdateModel
    {
        public int Id { get; set; }
        [Required]
        public int patientId { get; set; }
        [Required]
        public DateTime timestamp { get; set; }
        //[Required]
        //public DateTime currentQuarantineDate { get; set; }
        [Required]
        public string currentSymptoms { get; set; }
        [Required]
        public string currentTreatment { get; set; }
        [Required]
        public string currentTreatmentComments { get; set; }
    }
}
