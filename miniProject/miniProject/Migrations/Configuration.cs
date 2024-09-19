namespace miniProject.Migrations
{
    using miniProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<miniProject.Models.MiniSchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(miniProject.Models.MiniSchoolContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            context.Subjects.AddOrUpdate(
              s => s.Name, 
              new Subject { Name = "Mathematics" },
              new Subject { Name = "Science" },
              new Subject { Name = "English" },
              new Subject { Name = "Physics" });
        }
    }
}
