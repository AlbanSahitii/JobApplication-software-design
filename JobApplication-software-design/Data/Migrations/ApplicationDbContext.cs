using JobApplication_software_design.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JobApplication_software_design.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
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
        public DbSet<JobPosting> JobPosting { get; set; }
        public DbSet<JobCategory> JobCategories { get; set; }
        public DbSet<PhoneInterview> PhoneInterview { get; set; }
        public DbSet<InPersonInterview> InPersonInterview { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Interview> Interviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhoneInterview>().ToTable("PhoneInterviews");
            modelBuilder.Entity<InPersonInterview>().ToTable("InPersonInterviews");

            base.OnModelCreating(modelBuilder);

            // User to ApplicationReview (Association - One to Many)
            modelBuilder.Entity<ApplicationReview>()
                .HasOne(ar => ar.Reviewer)
                .WithMany(u => u.ApplicationReview)
                .HasForeignKey(ar => ar.ReviewerId)
               .OnDelete(DeleteBehavior.Restrict);

            // User to JobApplication (Association - One to Many)
            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.User)
                .WithMany(u => u.JobApplications)
                .HasForeignKey(ja => ja.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // JobApplication to Interview (Association - One to Many)
            modelBuilder.Entity<Interview>()
                .HasOne(i => i.JobApplication)
                .WithMany(ja => ja.Interviews) // Assuming you have an Interviews collection in JobApplication
                .HasForeignKey(i => i.JobApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

            // JobApplication to JobPosting (Association - Many to One)
            modelBuilder.Entity<JobApplication>()
                .HasOne(ja => ja.JobPosting)
                .WithMany(jp => jp.JobApplications)
                .HasForeignKey(ja => ja.JobPostingId)
                .OnDelete(DeleteBehavior.Restrict);

            // ApplicationReview to JobApplication (Composition - One to One)
            modelBuilder.Entity<ApplicationReview>()
                .HasOne(ar => ar.JobApplication)
                .WithOne(ja => ja.ApplicationReview)
                .HasForeignKey<ApplicationReview>(ar => ar.JobApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Resume to JobApplication (Composition - One to One)
            modelBuilder.Entity<Resume>()
                .HasOne(r => r.JobApplication)
                .WithOne(ja => ja.Resume)
                .HasForeignKey<Resume>(r => r.JobApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

            // ApplicationStatus to JobApplication (Composition - One to One)
            modelBuilder.Entity<ApplicationStatus>()
                .HasOne(ast => ast.JobApplication)
                .WithOne(ja => ja.ApplicationStatus)
                .HasForeignKey<ApplicationStatus>(ast => ast.JobApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

            // CoverLetter to JobApplication (Composition - One to One)
            modelBuilder.Entity<CoverLetter>()
                .HasOne(cl => cl.JobApplication)
                .WithOne(ja => ja.CoverLetter)
                .HasForeignKey<CoverLetter>(cl => cl.JobApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employer to JobPosting (Association - One to Many)
            modelBuilder.Entity<JobPosting>()
                .HasOne(jp => jp.Employer)
                .WithMany(e => e.JobPostings)
                .HasForeignKey(jp => jp.EmployerId)
                .OnDelete(DeleteBehavior.Restrict);

            // JobPosting to JobCategory (Aggregation - Many to One)
            modelBuilder.Entity<JobPosting>()
                .HasOne(jp => jp.JobCategory)
                .WithMany(jc => jc.JobPosting)
                .HasForeignKey(jp => jp.JobCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Assuming InPersonInterview and PhoneInterview have a navigation property called InterviewId

            modelBuilder.Entity<InPersonInterview>()
            .HasOne(ipi => ipi.Interview)
            .WithOne(i => i.InPersonInterview)
            .HasForeignKey<InPersonInterview>(ipi => ipi.InterviewId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PhoneInterview>()
                .HasOne(pi => pi.Interview)
                .WithOne(i => i.PhoneInterview)
                .HasForeignKey<PhoneInterview>(pi => pi.InterviewId)
                .OnDelete(DeleteBehavior.Restrict);




        }
    }
}
