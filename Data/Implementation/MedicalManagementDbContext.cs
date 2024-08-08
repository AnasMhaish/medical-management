using Microsoft.EntityFrameworkCore;

namespace MedicalManagement.Data.Implementation
{
    public class MedicalManagementDbContext : DbContext
    {
        // Define your DbSet properties here
        public DbSet<Patient> Patients => base.Set<Patient>();
        public DbSet<Doctor> Doctors => base.Set<Doctor>();
        public DbSet<Medicine> Medicines => base.Set<Medicine>();
        public DbSet<Receipt> Receipts => base.Set<Receipt>();

        public MedicalManagementDbContext(DbContextOptions<MedicalManagementDbContext> options) 
            : base(options)
        {

        }

        private void OnPatientModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().ToTable("Patients");

            modelBuilder.Entity<Patient>().HasKey(m => m.Id);

            modelBuilder.Entity<Patient>().Property(m => m.Id).ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Patient>()
                .Property(m => m.Id)
                .HasConversion(id => id.value, value => new PatientId(value));
        }

        private void OnDoctorModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>().ToTable("Doctors");

            modelBuilder.Entity<Doctor>().HasKey(m => m.Id);

            modelBuilder.Entity<Doctor>().Property(m => m.Id).ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Doctor>()
                .Property(m => m.Id)
                .HasConversion(id => id.value, value => new DoctorId(value));
        }

        private void OnMedicineModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medicine>().ToTable("Medicines");

            modelBuilder.Entity<Medicine>().HasKey(m => m.Id);

            modelBuilder.Entity<Medicine>().Property(m => m.Id).ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Medicine>()
                .Property(m => m.Id)
                .HasConversion(id => id.value, value => new MedicineId(value));
        }

        private void OnReceiptModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receipt>().ToTable("Receipts");

            modelBuilder.Entity<Receipt>().HasKey(r => r.Id);

            modelBuilder.Entity<Receipt>().Property(m => m.Id).ValueGeneratedOnAdd();

            modelBuilder
                .Entity<Receipt>()
                .Property(m => m.Id)
                .HasConversion(id => id.value, value => new ReceiptId(value));

            modelBuilder.Entity<Receipt>().HasMany(r => r.Medicines);

            modelBuilder
                .Entity<Receipt>()
                .HasOne(p => p.Patient)
                .WithMany()
                .HasForeignKey(x => x.PatientId);

            modelBuilder
                .Entity<Receipt>()
                .HasOne(r => r.Doctor)
                .WithMany()
                .HasForeignKey(x => x.DoctorId);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings and relationships here
            OnPatientModelCreating(modelBuilder);
            OnDoctorModelCreating(modelBuilder);
            OnMedicineModelCreating(modelBuilder);
            OnReceiptModelCreating(modelBuilder);
        }
    }
}
