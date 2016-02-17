namespace TeachMe.Data.Models
{
    using Common;
    using System.ComponentModel.DataAnnotations;

    public class Edit
    {
        public int Id { get; set; }

        public int LessonId { get; set; }

        [Required]
        public Lesson Lesson { get; set; }

        [Required]
        [MaxLength(Constants.LessonMaxLength)]
        public string OldContent { get; set; }

        [Required]
        [MaxLength(Constants.LessonEditMaxLength)]
        public string EdditedContent { get; set; }

        //should use foreign key?
        [Required]
        public User Creator { get; set; }
    }
}
