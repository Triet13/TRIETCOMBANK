using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Build.Framework;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;


namespace WebApplication1.Models
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
     [Required]
     [StringLength(255)]
     public string name { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Attendance>Attendances { get; set; }  
        public DbSet<Following> Followings { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
       public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.Course)
                .WithMany()
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
           .HasRequired(u => u.Followers)
           .WithRequired(f => f.Followee)
           .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
           .HasRequired(u => u.Followees)
           .WithRequired(false => f.Follower)
           .WillCascadeOnDelete(false);



            base.OnModelCreating(modelBuilder);
        }
    }
}