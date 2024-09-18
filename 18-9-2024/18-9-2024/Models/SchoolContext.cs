using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _18_9_2024.Models
{
    public class SchoolContext: DbContext
    {

        
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentDetails> StudentDetails { get; set; }


        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }

        
           
          
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
              .HasMany(c => c.Courses)
              .WithRequired(t => t.teacher)
              .HasForeignKey(t => t.TeacherID);
        

            modelBuilder.Entity<Student>()
                .HasOptional(s => s.StudentDetails)
                .WithRequired(sd => sd.Student);

            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }

}
    