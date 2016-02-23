namespace TeachMe.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Data.Common.Models;

    public class Comment : BaseModel<int>
    {
        public int LessonId { get; set; }

        [Required]
        public virtual Lesson Lesson { get; set; }

        [Required]
        public virtual ApplicationUser User { get; set; }

        [Required]
        [MinLength(Constants.CommentMinLength)]
        [MaxLength(Constants.CommentMaxLength)]
        public string Content { get; set; }
    }
}
