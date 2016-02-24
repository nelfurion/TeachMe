namespace TeachMe.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Common.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;
    using TeachMe.Data.Models;
    using System.Data.Entity.ModelConfiguration;
    using System.ComponentModel.DataAnnotations.Schema;
    public class TeachMeDbContext : IdentityDbContext<ApplicationUser>
    {
        public TeachMeDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static TeachMeDbContext Create()
        {
            return new TeachMeDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Lesson>()
                .HasRequired(p => p.Creator)
                .WithMany(x => x.Lessons)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
    }

        public IDbSet<Lesson> Lessons { get; set; }

        public IDbSet<Ticket> Tickets { get; set; }

        public IDbSet<Subject> Subjects{ get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Battle> Battles { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Edit> Edits { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
