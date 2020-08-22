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
        [Required]
        [StringLength(60)]
        public string Name { get; set; }
        [Required]
        [StringLength(60)]
        [RegularExpression(@"[^@]+@[^\.]+\..+")]
        public string Email { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string subject { get; set; }
        [Required]
        [StringLength(400, MinimumLength = 3)]
        public string messageContent { get; set; }

        [StringLength(400, MinimumLength = 3)]
        public string answer { get; set; }
        [Required]
        public DateTime timestamp { get; set; }
        [Required]
        public string type { get; set; }

    }
}
