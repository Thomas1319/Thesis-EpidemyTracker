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
        [Required(ErrorMessage = "First name cannot be empty")]
        [StringLength(40, MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "This field accepts only upper and lower case letters.")]
        public string firstName { get; set; }
        [Required(ErrorMessage = "Last name cannot be empty")]
        [StringLength(20, MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "This field accepts only upper and lower case letters.")]
        public string lastName { get; set; }
        [Required(ErrorMessage = "Address cannot be empty")]
        [StringLength(60, MinimumLength = 0, ErrorMessage = "Length is invalid")]
        public string address { get; set; }
        [Required(ErrorMessage = "Phone number cannot be empty")]
        [StringLength(13, MinimumLength = 9, ErrorMessage = "Length of the phone number is invalid")]
        [RegularExpression(@"^[+][0-9]+$", ErrorMessage = "Phone number can only have the format +12345678910")]
        public string phoneNumber { get; set; }
        [Required(ErrorMessage = "E-mail address cannot be empty")]
        [RegularExpression(@"[^@]+@[^\.]+\..+", ErrorMessage = "E-mail address must have the format example@company.domain")]
        public string emailAddress { get; set; }



        [StringLength(40, MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "This field accepts only upper and lower case letters.")]
        public string contactFirstName { get; set; }

        [StringLength(20, MinimumLength = 2)]
        [RegularExpression(@"^[A-Za-z]+$", ErrorMessage = "This field accepts only upper and lower case letters.")]
        public string contactLastName { get; set; }

        [StringLength(60, MinimumLength = 0, ErrorMessage = "Length is invalid")]
        public string contactAddress { get; set; }

        [StringLength(13, MinimumLength = 9, ErrorMessage = "Length of the phone number is invalid")]
        [RegularExpression(@"^[+][0-9]+$", ErrorMessage = "Phone number can only have the format +12345678910")]
        public string contactPhoneNumber { get; set; }
        [RegularExpression(@"[^@]+@[^\.]+\..+", ErrorMessage = "E-mail address must have the format example@company.domain")]
        public string contactEmailAddress { get; set; }


        [Required(ErrorMessage = "Field cannot be empty")]
        [Range(0, 100, ErrorMessage = "Field accepts values between 0 and 100")]
        public int age { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        public string gender { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        [Range(0, 201, ErrorMessage = "Field accepts values between 0 and 200")]
        public int weight { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        [Range(0, 201, ErrorMessage = "Field accepts values between 0 and 200")]
        public int height { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        [DataType(DataType.Date)]
        public DateTime symptomsDate { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        public string symptoms { get; set; }
        [StringLength(600)]
        public string additionalComments { get; set; }
        [DataType(DataType.Date)]
        public DateTime quarantineEndDate { get; set; }


        public string messages { get; set; }

        [ForeignKey("doctorId")]
        public string doctorId { get; set; }

        [StringLength(600)]
        public string treatment { get; set; }

        [StringLength(600)]
        public string treatmentComments { get; set; }

    }
}
