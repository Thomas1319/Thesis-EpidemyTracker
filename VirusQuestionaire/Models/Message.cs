using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VirusQuestionaire.Models
{
    public class Message
    {
        public int ID { get; set; }

        public string doctorId { get; set; }
        [Required(ErrorMessage = "Field cannot be empty" )]
        [StringLength(60, ErrorMessage = "Invalid length")]
        [RegularExpression(@"^[A-Z a-z]+$", ErrorMessage = "This field accepts only upper and lower case letters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        [StringLength(60, ErrorMessage = "Invalid length")]
        [RegularExpression(@"[^@]+@[^\.]+\..+", ErrorMessage = "E-mail must have the format example@company.domain")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Invalid length")]
        [RegularExpression(@"^[A-Z a-z0-9]+$", ErrorMessage = "This field accepts only upper and lower case letters and numbers.")]
        public string subject { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        [StringLength(400, MinimumLength = 3, ErrorMessage = "Invalid length")]
        [RegularExpression(@"^[A-Za-z0-9 .,?!]+$", ErrorMessage = "This field accepts only upper, lower case letters, numbers and punctuation(.,?!).")]
        public string messageContent { get; set; }

        [StringLength(400, MinimumLength = 3)]
        public string answer { get; set; }
        [Required]
        public DateTime timestamp { get; set; }
        [Required]
        public string type { get; set; }

    }
}
