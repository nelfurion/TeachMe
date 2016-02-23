namespace TeachMe.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Rating
    {
        public int Id { get; set; }

        [Key, ForeignKey("Lesson")]
        public int LessonId { get; set; }

        public virtual Lesson Lesson { get; set; }

        public int Value { get; set; }
    }
}
