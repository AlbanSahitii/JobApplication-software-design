using Microsoft.EntityFrameworkCore;
using JobApplication_software_design.Models;

namespace JobApplication_software_design.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }
        public DbSet<ApplicationReview> ApplicationReviews { get; set; }
        public DbSet<ApplicationStatus> ApplicationStatuses { get; set; }
        public DbSet<CoverLetter> CoverLetters { get; set; }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<PhoneInterview> PhoneInterviews { get; set; }
        public DbSet<InPersonInterview> InPersonInterviews { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Interview> Interviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User - ApplicationReview association
            modelBuilder.Entity<User>()
                .HasMany(u => u.ApplicationReview)
                .WithOne(ar => ar.Reviewer)
                .HasForeignKey(ar => ar.ReviewerId);

            // User - JobApplication association
            modelBuilder.Entity<User>()
                .HasMany(u => u.JobApplications)
                .WithOne(ja => ja.User)
                .HasForeignKey(ja => ja.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // JobApplication - Interview association
            modelBuilder.Entity<JobApplication>()
                .HasMany(ja => ja.Interviews)
                .WithOne(i => i.JobApplication)
                .HasForeignKey(i => i.JobApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

            // JobApplication - JobPosting association
            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.JobPosting)
                .WithMany(jp => jp.JobApplications)
                .HasForeignKey(ja => ja.JobPostingId);

            // ApplicationReview - JobApplication composition
            modelBuilder.Entity<ApplicationReview>()
                .HasOne(ar => ar.JobApplication)
                .WithOne(ja => ja.ApplicationReview)
                .HasForeignKey<ApplicationReview>(ar => ar.JobApplicationId);


            // Resume - JobApplication composition
            modelBuilder.Entity<Resume>()
                .HasOne(r => r.JobApplication)
                .WithOne(ja => ja.Resume)
                .HasForeignKey<Resume>(r => r.JobApplicationId);

            // ApplicationStatus - JobApplication composition
            modelBuilder.Entity<ApplicationStatus>()
                .HasOne(ast => ast.JobApplication)
                .WithOne(ja => ja.ApplicationStatus)
                .HasForeignKey<ApplicationStatus>(ast => ast.JobApplicationId);

            // CoverLetter - JobApplication composition
            modelBuilder.Entity<CoverLetter>()
                .HasOne(cl => cl.JobApplication)
                .WithOne(ja => ja.CoverLetter)
                .HasForeignKey<CoverLetter>(cl => cl.JobApplicationId);

            // Employer - JobPosting association
            modelBuilder.Entity<Employer>()
                .HasMany(e => e.JobPostings)
                .WithOne(jp => jp.Employer)
                .HasForeignKey(jp => jp.EmployerId);

            // JobPosting - JobCategory aggregation
            modelBuilder.Entity<JobPosting>()
                .HasOne(jp => jp.JobCategory)
                .WithMany(jc => jc.JobPostings)
                .HasForeignKey(jp => jp.JobCategoryId);

            // Interview - PhoneInterview and InPersonInterview aggregation
            // Here, adjust as necessary depending on your specific inheritance/aggregation strategy
            modelBuilder.Entity<Interview>()
                .HasMany(i => i.PhoneInterview)
                .WithOne(pi => pi.Interview)
                .HasForeignKey(pi => pi.InterviewId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Interview>()
                .HasMany(i => i.InPersonInterview)
                .WithOne(ipi => ipi.Interview)
                .HasForeignKey(ipi => ipi.InterviewId)
                .OnDelete(DeleteBehavior.Restrict);
        }





    }
}
