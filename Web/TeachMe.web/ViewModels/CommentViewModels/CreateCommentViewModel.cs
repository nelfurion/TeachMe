namespace TeachMe.Web.ViewModels.CommentViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CreateCommentViewModel : IMapTo<Comment>
    {
        [Required]
        [MinLength(Constants.CommentMinLength)]
        [MaxLength(Constants.CommentMaxLength)]
        public string Content { get; set; }

        [Required]
        public int LessonId { get; set; }
    }
}