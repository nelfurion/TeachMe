namespace TeachMe.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    //using TeachMe.Common;
    using TeachMe.Data.Models;
    using System;
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

            if (!context.Users.Any())
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

            if (!context.Comments.Any())
            {
                seeder.SeedComments();
            }

            if (!context.Lessons.Any())
            {
                var hasher = new PasswordHasher();
                var passwordHash = hasher.HashPassword("123456");
                var editor = new ApplicationUser
                {
                    UserName = "pesho 2",
                    PasswordHash = passwordHash
                };

                seeder.SeedLessons(editor, context.Subjects.First());
                seeder.SeedLessons(editor, context.Subjects.ToList()[1]);
                seeder.SeedLessons(editor, context.Subjects.ToList()[2]);
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
