using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace miniProject.Models
{
    public class MiniSchoolContext : DbContext
    {

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<User> Users { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            modelBuilder.Entity<Student>()
              .HasRequired(s => s.Class)                
              .WithMany(c => c.Students)                
             .HasForeignKey(s => s.ClassId);

            modelBuilder.Entity<Tasks>()
               .HasRequired(a => a.Class)                
               .WithMany(c => c.Tasks)                   
              .HasForeignKey(a => a.ClassId);


            base.OnModelCreating(modelBuilder);
        }
    }
}