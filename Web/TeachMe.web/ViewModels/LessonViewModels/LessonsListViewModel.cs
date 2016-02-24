namespace TeachMe.Web.ViewModels.LessonViewModels
{
    using System.Collections.Generic;

    public class LessonsListViewModel
    {
        public List<LessonTableDataViewModel> Lessons { get; set; }

        public int PagesCount { get; set; }
    }
}