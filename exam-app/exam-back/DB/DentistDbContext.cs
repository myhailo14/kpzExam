using exam_back.Models;
using Microsoft.EntityFrameworkCore;

namespace exam_back.DB
{
    public class DentistDbContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalHistory> MedicalHistory { get; set; }


        public DentistDbContext(DbContextOptions<DentistDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            List<Patient> dataPatients = new List<Patient>()
            {
                new Patient(){Id = Guid.NewGuid() , Name = "Mykhailo", Surname = "Vovkanych", Birthday = new DateTime(2003, 3, 23)},
                new Patient(){Id = Guid.NewGuid() ,Name = "Taras", Surname = "Shevchenko", Birthday = new DateTime(2002, 4, 4)},
                new Patient(){Id = Guid.NewGuid(), Name = "Stepan", Surname = "Bandera", Birthday = new DateTime(1994, 1, 2)},
                new Patient(){Id = Guid.NewGuid(), Name = "Lesia", Surname = "Ukrainka", Birthday = new DateTime(1982, 8, 14)},

            };

            modelBuilder.Entity<Patient>().HasData(dataPatients);

            List<MedicalHistory> dataHistories = new List<MedicalHistory>()
            {
                new MedicalHistory() {Id = Guid.NewGuid(), VisitTime = DateTime.Now.AddDays(-5), PatientId = dataPatients[0].Id},
                new MedicalHistory() {Id = Guid.NewGuid(), VisitTime = DateTime.Now.AddDays(-3), PatientId = dataPatients[1].Id},
                new MedicalHistory() {Id = Guid.NewGuid(), VisitTime = DateTime.Now.AddDays(-1), PatientId = dataPatients[0].Id}
            };
            modelBuilder.Entity<MedicalHistory>().HasData(dataHistories);


            base.OnModelCreating(modelBuilder);
        }
    }



}
