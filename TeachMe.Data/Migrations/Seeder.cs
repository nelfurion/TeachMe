using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;
using TeachMe.Data.Models;

namespace TeachMe.Data.Migrations
{
    public class Seeder
    {
        public Seeder(TeachMeDbContext context)
        {
            this.Context = context;
        }

        public void SeedSubjects()
        {
            var math = new Subject
            {
                Name = "Math"
            };

            var biology = new Subject
            {
                Name = "Biology"
            };

            var physics = new Subject
            {
                Name = "Physics"
            };

            this.Context.Subjects.Add(math);
            this.Context.Subjects.Add(biology);
            this.Context.Subjects.Add(physics);

            this.Context.SaveChanges();
        }

        public void SeedLessons()
        {
            var hasher = new PasswordHasher();
            var passwordHash = hasher.HashPassword("123456");

            var editor = new User
            {
                UserName = "pesho 2",
                PasswordHash = passwordHash
            };

            this.Context.Users.Add(editor);

            var subject = this.Context.Subjects.First();

            for (int i = 0; i < 5; i++)
            {
                var lesson = new Lesson
                {
                    Content = "Lorem ipsum dolor auris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec.",
                    Creator = editor,
                    Grade = 10,
                    Subject = subject,
                    Name = "Matrices " + i.ToString()
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
                    User = editor,
                };

                this.Context.Lessons.Add(lesson);
            }
        }

        public void SeedTickets()
        {
            var userManager = new UserManager<User>(new UserStore<User>(this.Context));

            var normalUser = this.Context.Users.FirstOrDefault(u => userManager.IsInRole(u.Id, "Normal"));

            for (int i = 0; i < 5; i++)
            {
                var ticket = new Ticket
                {
                    CreatedOn = DateTime.UtcNow,
                    Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Lorem ipsum dolor sit amet, consectetur adipiscing elit",
                    Creator = normalUser,
                };
            }
        }

        public void SeedUsers()
        {
            var hasher = new PasswordHasher();
            var passwordHash = hasher.HashPassword("123456");

            var roles = this.Context.Roles;

            var admin = new User
            {
                UserName = "gosho",
                PasswordHash = passwordHash,
            };
            
            admin.Roles.Add(
                new IdentityUserRole {
                    RoleId = roles.FirstOrDefault(r => r.Name == "Admin").Id,
                    UserId = admin.Id });

            var editor = new User
            {
                UserName = "pesho",
                PasswordHash = passwordHash
            };

            editor.Roles.Add(
                new IdentityUserRole
                {
                    RoleId = roles.FirstOrDefault(r => r.Name == "Editor").Id,
                    UserId = admin.Id
                });

            var normal = new User
            {
                UserName = "anastas",
                PasswordHash = passwordHash
            };

            normal.Roles.Add(
                new IdentityUserRole
                {
                    RoleId = roles.FirstOrDefault(r => r.Name == "Normal").Id,
                    UserId = admin.Id
                });
        }

        public void SeedRoles()
        {
            IdentityRole adminRole = new IdentityRole("Admin");
            IdentityRole editorRole = new IdentityRole("Editor");
            IdentityRole normalRole = new IdentityRole("Normal");

            this.Context.Roles.Add(adminRole);
            this.Context.Roles.Add(editorRole);
            this.Context.Roles.Add(normalRole);

            //this.Context.SaveChanges();
        }

        public void SeedBattlesAndTeams()
        {
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
                    };

                    User rightUser = new User
                    {
                        UserName = "rightUser" + j.ToString() + i.ToString(),
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

                this.Context.Teams.Add(leftTeam);
                this.Context.Teams.Add(rightTeam);

                this.Context.Battles.Add(battle);
            }
        }

        private TeachMeDbContext Context { get; set; }
    }
}
