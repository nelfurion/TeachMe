namespace TeachMe.Data.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        public int LessonId { get; set; }

        [Required]
        public Lesson Lesson { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        [MinLength(Constants.CommentMinLength)]
        [MaxLength(Constants.CommentMaxLength)]
        public string Content { get; set; }
    }
}
