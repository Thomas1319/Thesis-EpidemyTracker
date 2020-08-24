using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VirusTracker.Models
{
    public class Patient
    {
        public int ID { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string firstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string lastName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 0)]
        public string address { get; set; }

        [Required]
        [StringLength(13, MinimumLength = 9)]
        public string phoneNumber { get; set; }

        [Required]
        [RegularExpression(@"[^@]+@[^\.]+\..+")]
        public string emailAddress { get; set; }

        [StringLength(60, MinimumLength = 0)]
        public string contactFirstName { get; set; }
        [StringLength(60, MinimumLength = 0)]
        public string contactLastName { get; set; }
        [StringLength(60, MinimumLength = 0)]
        public string contactAddress { get; set; }
        [StringLength(13, MinimumLength = 9)]
        public string contactPhoneNumber { get; set; }
        [RegularExpression(@"[^@]+@[^\.]+\..+")]
        public string contactEmailAddress { get; set; }


        [Required]
        [Range(0,100)]
        public int age { get; set; }

        [Required]
        public string gender { get; set; }

        [Required]
        [Range(0,201)]
        public int weight { get; set; }

        [Required]
        [Range(0,201)]
        public int height { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime symptomsDate { get; set; }

        [Required]
        public string symptoms { get; set; }

        [StringLength(600)]
        public string additionalComments { get; set; }

        [StringLength(600)]
        public string treatment { get; set; }

        [StringLength(600)]
        public string treatmentComments { get; set; }

        [DataType(DataType.Date)]
        public DateTime quarantineEndDate { get; set; }

        public string messages { get; set; }

        [ForeignKey("doctorId")]
        public string doctorId { get; set; }

    }
}
