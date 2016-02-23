namespace TeachMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;
    using System.ComponentModel.DataAnnotations.Schema;
    using System;

    public class Lesson
    {
        public Lesson()
        {
            this.Edits = new HashSet<Edit>();
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [MaxLength(Constants.LessonMaxLength)]
        [Required]
        public string Name { get; set; }

        [ForeignKey("Creator")]
        public string UserId { get; set; }

        [Required]
        public virtual User Creator { get; set; }

        [Required]
        [MaxLength(Constants.LessonMaxLength)]
        public string Content { get; set; }

        public virtual ICollection<Edit> Edits { get; set; }
        
        public int Grade { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        [Required]
        public virtual Subject Subject { get; set; }

        public int RatingId { get; set; }

        public virtual Rating Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
