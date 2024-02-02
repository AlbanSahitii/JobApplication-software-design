﻿// <auto-generated />
using System;
using JobApplication_software_design.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobApplication_software_design.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240202122159_Error6")]
    partial class Error6
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobApplication_software_design.Models.ApplicationReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Feedback")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("ReviewerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("JobApplicationId")
                        .IsUnique();

                    b.HasIndex("ReviewerId");

                    b.ToTable("ApplicationReviews");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.ApplicationStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("JobApplicationId")
                        .IsUnique();

                    b.ToTable("ApplicationStatuses");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.CoverLetter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobApplicationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("JobApplicationId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("CoverLetters");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.Employer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Industry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employers");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.Interview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("InPersonInterviewId")
                        .HasColumnType("int");

                    b.Property<int>("JobApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PhoneInterviewId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobApplicationId");

                    b.ToTable("Interviews");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("JobApplication_software_design.Models.JobApplication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApplicationReviewId")
                        .HasColumnType("int");

                    b.Property<int?>("ApplicationStatusId")
                        .HasColumnType("int");

                    b.Property<int>("CoverLetterId")
                        .HasColumnType("int");

                    b.Property<int?>("InterviewId")
                        .HasColumnType("int");

                    b.Property<int>("JobPostingId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResumeId")
                        .HasColumnType("int");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SubmissionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("JobPostingId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("JobApplications");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.JobCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobPostingId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("JobCategories");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.JobPosting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployerId")
                        .HasColumnType("int");

                    b.Property<int>("JobCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployerId");

                    b.HasIndex("JobCategoryId");

                    b.ToTable("JobPosting");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.Resume", b =>
                {
                    b.Property<int>("ResumeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ResumeId"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JobApplicationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Skills")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ResumeId");

                    b.HasIndex("JobApplicationId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ApplicationReviewID")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CoverLetterId")
                        .HasColumnType("int");

                    b.Property<string>("Education")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("JobApplicationId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ResumeId")
                        .HasColumnType("int");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skills")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("JobApplication_software_design.Models.InPersonInterview", b =>
                {
                    b.HasBaseType("JobApplication_software_design.Models.Interview");

                    b.Property<int>("InterviewId")
                        .HasColumnType("int");

                    b.HasIndex("InterviewId")
                        .IsUnique()
                        .HasFilter("[InterviewId] IS NOT NULL");

                    b.ToTable("InPersonInterviews", (string)null);
                });

            modelBuilder.Entity("JobApplication_software_design.Models.PhoneInterview", b =>
                {
                    b.HasBaseType("JobApplication_software_design.Models.Interview");

                    b.Property<string>("DialInNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InterviewId")
                        .HasColumnType("int");

                    b.HasIndex("InterviewId")
                        .IsUnique()
                        .HasFilter("[InterviewId] IS NOT NULL");

                    b.ToTable("PhoneInterviews", (string)null);
                });

            modelBuilder.Entity("JobApplication_software_design.Models.ApplicationReview", b =>
                {
                    b.HasOne("JobApplication_software_design.Models.JobApplication", "JobApplication")
                        .WithOne("ApplicationReview")
                        .HasForeignKey("JobApplication_software_design.Models.ApplicationReview", "JobApplicationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobApplication_software_design.Models.User", "Reviewer")
                        .WithMany("ApplicationReview")
                        .HasForeignKey("ReviewerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("JobApplication");

                    b.Navigation("Reviewer");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.ApplicationStatus", b =>
                {
                    b.HasOne("JobApplication_software_design.Models.JobApplication", "JobApplication")
                        .WithOne("ApplicationStatus")
                        .HasForeignKey("JobApplication_software_design.Models.ApplicationStatus", "JobApplicationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("JobApplication");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.CoverLetter", b =>
                {
                    b.HasOne("JobApplication_software_design.Models.JobApplication", "JobApplication")
                        .WithOne("CoverLetter")
                        .HasForeignKey("JobApplication_software_design.Models.CoverLetter", "JobApplicationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobApplication_software_design.Models.User", "User")
                        .WithMany("CoverLetter")
                        .HasForeignKey("UserId");

                    b.Navigation("JobApplication");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.Interview", b =>
                {
                    b.HasOne("JobApplication_software_design.Models.JobApplication", "JobApplication")
                        .WithMany("Interviews")
                        .HasForeignKey("JobApplicationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("JobApplication");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.JobApplication", b =>
                {
                    b.HasOne("JobApplication_software_design.Models.JobPosting", "JobPosting")
                        .WithMany("JobApplications")
                        .HasForeignKey("JobPostingId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobApplication_software_design.Models.ApplicationStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobApplication_software_design.Models.User", "User")
                        .WithMany("JobApplications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("JobPosting");

                    b.Navigation("Status");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.JobPosting", b =>
                {
                    b.HasOne("JobApplication_software_design.Models.Employer", "Employer")
                        .WithMany("JobPostings")
                        .HasForeignKey("EmployerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobApplication_software_design.Models.JobCategory", "JobCategory")
                        .WithMany("JobPosting")
                        .HasForeignKey("JobCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Employer");

                    b.Navigation("JobCategory");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.Resume", b =>
                {
                    b.HasOne("JobApplication_software_design.Models.JobApplication", "JobApplication")
                        .WithOne("Resume")
                        .HasForeignKey("JobApplication_software_design.Models.Resume", "JobApplicationId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("JobApplication_software_design.Models.User", "User")
                        .WithMany("Resumes")
                        .HasForeignKey("UserId");

                    b.Navigation("JobApplication");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JobApplication_software_design.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JobApplication_software_design.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobApplication_software_design.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("JobApplication_software_design.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JobApplication_software_design.Models.InPersonInterview", b =>
                {
                    b.HasOne("JobApplication_software_design.Models.Interview", null)
                        .WithOne()
                        .HasForeignKey("JobApplication_software_design.Models.InPersonInterview", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobApplication_software_design.Models.Interview", "Interview")
                        .WithOne("InPersonInterview")
                        .HasForeignKey("JobApplication_software_design.Models.InPersonInterview", "InterviewId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Interview");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.PhoneInterview", b =>
                {
                    b.HasOne("JobApplication_software_design.Models.Interview", null)
                        .WithOne()
                        .HasForeignKey("JobApplication_software_design.Models.PhoneInterview", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JobApplication_software_design.Models.Interview", "Interview")
                        .WithOne("PhoneInterview")
                        .HasForeignKey("JobApplication_software_design.Models.PhoneInterview", "InterviewId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Interview");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.Employer", b =>
                {
                    b.Navigation("JobPostings");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.Interview", b =>
                {
                    b.Navigation("InPersonInterview")
                        .IsRequired();

                    b.Navigation("PhoneInterview")
                        .IsRequired();
                });

            modelBuilder.Entity("JobApplication_software_design.Models.JobApplication", b =>
                {
                    b.Navigation("ApplicationReview");

                    b.Navigation("ApplicationStatus");

                    b.Navigation("CoverLetter")
                        .IsRequired();

                    b.Navigation("Interviews");

                    b.Navigation("Resume")
                        .IsRequired();
                });

            modelBuilder.Entity("JobApplication_software_design.Models.JobCategory", b =>
                {
                    b.Navigation("JobPosting");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.JobPosting", b =>
                {
                    b.Navigation("JobApplications");
                });

            modelBuilder.Entity("JobApplication_software_design.Models.User", b =>
                {
                    b.Navigation("ApplicationReview");

                    b.Navigation("CoverLetter");

                    b.Navigation("JobApplications");

                    b.Navigation("Resumes");
                });
#pragma warning restore 612, 618
        }
    }
}
