namespace TeachMe.Web.Areas.Admin.ViewModels.LessonViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CreateLessonViewModel : IMapTo<Lesson>
    {
        [MaxLength(Constants.LessonMaxLength)]
        [Required]
        public string Name { get; set; }

        [Required]
        [MaxLength(Constants.LessonMaxLength)]
        public string Content { get; set; }

        [Range(8, 12)]
        public int Grade { get; set; }

        public int SubjectId { get; set; }
    }
}