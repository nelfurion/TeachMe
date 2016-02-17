namespace TeachMe.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common;

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

        [Required]
        public User Creator { get; set; }

        [Required]
        [MaxLength(Constants.LessonMaxLength)]
        public string Content { get; set; }

        public virtual ICollection<Edit> Edits { get; set; }
        
        public int Grade { get; set; }

        public int SubjectId { get; set; }

        [Required]
        public Subject Subject { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
