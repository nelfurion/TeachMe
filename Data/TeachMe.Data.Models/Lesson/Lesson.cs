namespace TeachMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;
    using TeachMe.Common;

    public class Lesson : BaseModel<int>
    {
        public Lesson()
        {
            this.Edits = new HashSet<Edit>();
            this.Comments = new HashSet<Comment>();
        }

        [MaxLength(Constants.LessonMaxLength)]
        [Required]
        public string Name { get; set; }

        [ForeignKey("Creator")]
        public string ApplicationUserId { get; set; }

        [Required]
        public virtual ApplicationUser Creator { get; set; }

        [Required]
        [MaxLength(Constants.LessonMaxLength)]
        public string Content { get; set; }

        public virtual ICollection<Edit> Edits { get; set; }

        [Range(8,12)]
        public int Grade { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        [Required]
        public virtual Subject Subject { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
