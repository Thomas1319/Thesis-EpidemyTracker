using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using VirusTracker.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace VirusTracker.Data
{
    public class VirusTrackerContext : IdentityDbContext<Doctor>
    {
        public VirusTrackerContext(DbContextOptions<VirusTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<VirusTracker.Models.Doctor> Doctor { get; set; }
        public DbSet<VirusTracker.Models.Patient> Patient { get; set; }
        public DbSet<VirusTracker.Models.Message> Message { get; set; }
        public DbSet<VirusTracker.Models.Codes> Codes { get; set; }
        public DbSet<VirusTracker.Models.EnrollModel> Enroll { get; set; }
        public DbSet<VirusTracker.Models.EmailsModel> Emails { get; set; }
        public DbSet<VirusTracker.Models.PatientUpdateModel> PatientUpdates { get; set; }
        public DbSet<VirusTracker.Models.SentimentModel> Sentiment { get; set; }
    }
}
