using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication18.Models
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("SchoolEntities")
        {
        }

       
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<Assignment> assignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }



}
