namespace TeachMe.Data.Models
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Security.Claims;
    using Microsoft.AspNet.Identity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class User : IdentityUser
    {
        public User()
        {
            this.Lessons = new HashSet<Lesson>();
            this.Comments = new HashSet<Comment>();
        }

        [Required]
        public int Type { get; set; }

        [ForeignKey("Type")]
        public virtual UserType UserType { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}
