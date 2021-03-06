﻿namespace TeachMe.Data.Migrations
{
    using System;
    using System.Linq;
    using Data;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Collections.Generic;
    public class Seeder
    {
        public Seeder(TeachMeDbContext context)
        {
            this.Context = context;
        }

        public void SeedComments()
        {
            var lessons = this.Context.Lessons.ToList();
            var user = this.Context.Users.FirstOrDefault();

            for (int i = 0; i < lessons.Count(); i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    var comment = new Comment
                    {
                        Content = "Comment: " + i.ToString() + " " + j.ToString() + " Lorem ipsum dolor sit amet, consectetur adipiscing elit.Mauris congue erat nec lacinia molestie.Etiam id interdum ligula.",
                        CreatedOn = DateTime.UtcNow,
                        IsDeleted = false,
                        Lesson = lessons[i],
                        User = user
                    };

                    this.Context.Comments.Add(comment);
                }
            }

            this.Context.SaveChanges();
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

        public void SeedLessons(ApplicationUser editor, Subject subject)
        {
            for (int i = 0; i < 10; i++)
            {
                var lesson = new Lesson
                {
                    Content = "Lorem ipsum dolor auris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec lacinia molestie. Etiam id interdum ligula.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris congue erat nec.",
                    Creator = editor,
                    Grade = 10,
                    Subject = subject,
                    Name = subject.Name + " " + i.ToString(),
                    CreatedOn = DateTime.UtcNow
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

            this.Context.SaveChanges();
        }

        public void SeedTickets()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.Context));

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
            const string UserName = "admin";
            const string RoleName = "Admin";

            var hasher = new PasswordHasher();
            var passwordHash = hasher.HashPassword("123456");

            var adminRole = new IdentityRole { Name = RoleName, Id = Guid.NewGuid().ToString() };
            var editorRole = new IdentityRole { Name = "Editor", Id = Guid.NewGuid().ToString() };

            this.Context.Roles.Add(adminRole);
            this.Context.Roles.Add(editorRole);

            var admin = new ApplicationUser
            {
                UserName = "admin@teachme.com",
                Email = "admin@teachme.com",
                PasswordHash = passwordHash,
                Lessons = new HashSet<Lesson>(),
                Comments = new HashSet<Comment>(),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            admin.Roles.Add(new IdentityUserRole { RoleId = adminRole.Id, UserId = admin.Id });

            var editor = new ApplicationUser
            {
                UserName = "editor@teachme.com",
                Email = "editor@teachme.com",
                PasswordHash = passwordHash,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            
            editor.Roles.Add(new IdentityUserRole { RoleId = editorRole.Id, UserId = admin.Id });

            var normal = new ApplicationUser
            {
                UserName = "pesho@teachme.com",
                Email = "pesho@teachme.com",
                PasswordHash = passwordHash,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            this.Context.Users.Add(admin);
            this.Context.Users.Add(editor);
            this.Context.Users.Add(normal);

            this.Context.SaveChanges();
        }

        public void SeedRoles()
        {
            /*IdentityRole adminRole = new IdentityRole("Admin");
            IdentityRole editorRole = new IdentityRole("Editor");
            IdentityRole normalRole = new IdentityRole("Normal");

            this.Context.Roles.Add(adminRole);
            this.Context.Roles.Add(editorRole);
            this.Context.Roles.Add(normalRole);

            this.Context.SaveChanges();*/
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
                    ApplicationUser leftUser = new ApplicationUser
                    {
                        UserName = "leftUser" + j.ToString() + i.ToString(),
                    };

                    ApplicationUser rightUser = new ApplicationUser
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