namespace TeachMe.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
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
            if (context.Users.Any())
            {
                return;
            }

            var passwordHasher = new PasswordHasher();
            string passwordHash = passwordHasher.HashPassword("123456");

            var userTypeAdmin = new UserType
            {
                Name = "Admin"
            };

            var userTypeEditor = new UserType
            {
                Name = "Editor"
            };

            var userTypeNormal = new UserType
            {
                Name = "Normal"
            };

            context.UserTypes.Add(userTypeAdmin);
            

            var admin = new User
            {
                UserName = "gosho",
                PasswordHash = passwordHash,
                UserType = userTypeAdmin
            };

            var editor = new User
            {
                UserName = "pesho",
                PasswordHash = passwordHash,
                UserType = userTypeEditor
            };

            var normal = new User
            {
                UserName = "anastas",
                PasswordHash = passwordHash,
                UserType = userTypeNormal
            };
            for (int j = 0; j < 5; j++)
            {
                Battle battle = new Battle();

                Team leftTeam = new Team
                {
                    Battle = battle
                };

                Team rightTeam = new Team
                {
                    Battle = battle
                };

                for (int i = 0; i < 3; i++)
                {
                    User leftUser = new User
                    {
                        UserName = "leftUser" + j.ToString() + i.ToString(),
                        PasswordHash = passwordHash,
                        UserType = userTypeNormal
                    };

                    User rightUser = new User
                    {
                        UserName = "rightUser" + j.ToString() + i.ToString(),
                        PasswordHash = passwordHash,
                        UserType = userTypeNormal
                    };

                    Player leftPlayer = new Player
                    {
                        User = leftUser
                    };

                    Player rightPlayer = new Player
                    {
                        User = rightUser
                    };

                    leftTeam.Players.Add(leftPlayer);
                    leftTeam.Players.Add(rightPlayer);
                }

                battle.Teams.Add(leftTeam);
                battle.Teams.Add(rightTeam);

                context.Teams.Add(leftTeam);
                context.Teams.Add(rightTeam);

                context.Battles.Add(battle);
            }

            context.Users.Add(admin);
            context.Users.Add(editor);
            context.Users.Add(normal);

            var math = new Subject
            {
                Name = "Math"
            };

            var lesson = new Lesson
            {
                Content = "Lorem ipsum dolor auris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec.",
                Creator = editor,
                Grade = 10,
                Subject = math,
                Name = "Matrices"
            };

            var edit = new Edit
            {
                Creator = editor,
                OldContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
                EdditedContent = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.",
                Lesson = lesson,
            };

            var comment = new Comment
            {
                Content = "This is a very good lesson!",
                Lesson = lesson,
                User = normal,
            };

            var ticket = new Ticket
            {
                CreatedOn = DateTime.UtcNow,
                Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                Creator = normal,
            };

            context.Tickets.Add(ticket);
            context.Subjects.Add(math);
            context.Lessons.Add(lesson);
            context.Edits.Add(edit);
            context.Comments.Add(comment);

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
