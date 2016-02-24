namespace TeachMe.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;
    using TeachMe.Common;

    public class Comment : BaseModel<int>
    {
        [Required]
        public int LessonId { get; set; }

        public virtual Lesson Lesson { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [MinLength(Constants.CommentMinLength)]
        [MaxLength(Constants.CommentMaxLength)]
        public string Content { get; set; }
    }
}
