using Kidney.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Kidney.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
            :base(options) {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hospital>()
                .HasMany(ll => ll.dialysisUnit)
                .WithOne(l => l.hospital)
                .HasForeignKey(e => e.HospitalId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            //////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////


            //////////////////////////////////////////////////////////////

            modelBuilder.Entity<PatientDoctor>().HasKey(x => new { x.PatientId, x.DoctorID });
            modelBuilder.Entity<Doctor>()
                .HasMany(dos => dos.patientDoctors)
                .WithOne(sou => sou.Doctor)
                .OnDelete(DeleteBehavior.Restrict);
            //////////////////////////////////////////////////////////////
            modelBuilder.Entity<PatientNurse>().HasKey(x => new { x.PatientId, x.NurseId });
            modelBuilder.Entity<Nurse>()
                .HasMany(x => x.patientNurses)
                .WithOne(x => x.nurse)
                .HasForeignKey(l => l.NurseId)
                .OnDelete(DeleteBehavior.Restrict);
            //////////////////////////////////////////////////////////////

            modelBuilder.Entity<PatientDrug>().HasKey(x => new { x.PatientId, x.DrugId });
            modelBuilder.Entity<Drug>()
                .HasMany(v => v.patientDrugs)
                .WithOne(n => n.drug)
                .HasForeignKey(l => l.DrugId)
                .OnDelete(DeleteBehavior.Restrict);
            //////////////////////////////////////////////////////////////

            modelBuilder.Entity<Patient>()
                .HasMany(ll => ll.patientDoctors)
                .WithOne(l => l.Patient)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
            //////////////////////////////////////////////////////////////

            modelBuilder.Entity<Patient>()
                .HasMany(x => x.patientNurses)
                .WithOne(s => s.patient)
                .HasForeignKey(p => p.PatientId)
                .OnDelete(DeleteBehavior.Restrict);
            //////////////////////////////////////////////////////////////
            modelBuilder.Entity<Patient>()
                 .HasMany(l => l.patientDrugs)
                 .WithOne(l => l.patient)
                 .HasForeignKey(p => p.PatientId)
                 .OnDelete(DeleteBehavior.Restrict);
            //////////////////////////////////////////////////////////////

            base.OnModelCreating(modelBuilder);
        }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<DialysisUnit> DialysisUnits { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Nurse> Nurses { get; set; }
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportFiles> ReportFiles { get; set; }

        public virtual DbSet<Schedule> Schedule { get; set; }


        
        public virtual DbSet<PatientDoctor> PatientDoctors { get; set; }
        public virtual DbSet<PatientNurse> PatientNurses { get; set; }
        public virtual DbSet<PatientDrug> PatientDrugs { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }






    }

}

