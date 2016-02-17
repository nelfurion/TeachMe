namespace TeachMe.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Data.Entity;

    public class TeachMeDbContext : IdentityDbContext<User>, ITeachMeDbContext
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

        public IDbSet<UserType> UserTypes { get; set; }

        public IDbSet<Lesson> Lessons { get; set; }

        public IDbSet<Ticket> Tickets { get; set; }

        public IDbSet<Subject> Subjects{ get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Battle> Battles { get; set; }

        public IDbSet<Player> Players { get; set; }

        public IDbSet<Team> Teams { get; set; }

        public IDbSet<Edit> Edits { get; set; }
    }
}