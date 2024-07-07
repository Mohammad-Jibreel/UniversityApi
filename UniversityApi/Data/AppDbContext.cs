using Microsoft.EntityFrameworkCore;
using UniversityApi.Models;

namespace UniversityApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<UserQualification> UserQualifications { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<College> Colleges { get; set; }
        public DbSet<Major> Majors { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserRole)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.UserRoleId);

            modelBuilder.Entity<User>()
    .HasOne(u => u.UserProfile)
    .WithOne(p => p.User)
    .HasForeignKey<UserProfile>(p => p.UserId);

            modelBuilder.Entity<UserProfile>()
                .HasMany(p => p.UserQualifications)
                .WithOne(q => q.UserProfile)
                .HasForeignKey(q => q.UserProfileId);

        }






        // User - UserProfile: One-to-One
        //    modelBuilder.Entity<User>()
        //        .HasOne(u => u.UserProfile)
        //        .WithOne(up => up.User)
        //        .HasForeignKey<UserProfile>(up => up.UserId);

        //    // User - UserQualifications: One-to-Many
        //    modelBuilder.Entity<User>()
        //        .HasMany(u => u.UserQualifications)
        //        .WithOne(uq => uq.User)
        //        .HasForeignKey(uq => uq.UserId);

        //    // User - Payments: One-to-Many
        //    modelBuilder.Entity<User>()
        //        .HasMany(u => u.Payments)
        //        .WithOne(p => p.User)
        //        .HasForeignKey(p => p.UserId);

        //    // User - Role: Many-to-One


        //    // University - Colleges: One-to-Many
        //    modelBuilder.Entity<University>()
        //        .HasMany(u => u.Colleges)
        //        .WithOne(c => c.University)
        //        .HasForeignKey(c => c.UniversityId);

        //    // College - Majors: One-to-Many
        //    modelBuilder.Entity<College>()
        //        .HasMany(c => c.Majors)
        //        .WithOne(m => m.College)
        //        .HasForeignKey(m => m.CollegeId);

        //    // UserQualification - University: Many-to-One
        //    modelBuilder.Entity<UserQualification>()
        //        .HasOne(uq => uq.University)
        //        .WithMany(u => u.UserQualifications)
        //        .HasForeignKey(uq => uq.UniversityId);
        //}






    }
}