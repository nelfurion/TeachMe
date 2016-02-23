
using System.Collections.Generic;
using TeachMe.Data.Models;

namespace TeachMe.Web.ViewModels.LessonViewModels
{
    public class LessonsListViewModel
    {
        public List<Lesson> Lessons { get; set; }

        public int PagesCount { get; set; }
    }
}