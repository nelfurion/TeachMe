namespace TeachMe.Web.ViewModels.LessonViewModels
{
    using CommentViewModels;
    using System.Collections.Generic;

    public class LessonDetailsViewModel
    {
        public LessonViewModel Lesson { get; set; }

        public List<CommentViewModel> Comments { get; set; }

        public int CommentPagesCount { get; set; }
    }
}