namespace TeachMe.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    public sealed class Configuration : DbMigrationsConfiguration<TeachMeDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TeachMeDbContext context)
        {
            Seeder seeder = new Seeder(context);

            if (!context.Roles.Any())
            {
                seeder.SeedRoles();
            }

            if (context.Users.Any())
            {
                seeder.SeedUsers();
            }

            if (!context.Battles.Any())
            {
                seeder.SeedBattlesAndTeams();
            }

            if (!context.Subjects.Any())
            {
                seeder.SeedSubjects();
            }

            if (!context.Lessons.Any())
            {
                seeder.SeedLessons();
            }

            try
            {
                context.SaveChanges();
            }
            catch (Exception e)
            {

            }
        }
    }
}
