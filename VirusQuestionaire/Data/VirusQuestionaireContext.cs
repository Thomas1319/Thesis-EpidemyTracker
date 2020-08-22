using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VirusQuestionaire.Models;

namespace VirusQuestionaire.Data
{
    public class VirusQuestionaireContext : DbContext
    {
        public VirusQuestionaireContext (DbContextOptions<VirusQuestionaireContext> options)
            : base(options)
        {
        }

        public DbSet<VirusQuestionaire.Models.Patient> Patient { get; set; }
    }
}
