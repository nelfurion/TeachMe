namespace TeachMe.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Data.Services.Contracts;
    using ViewModels.LessonViewModels;

    public class LessonController : BaseController
    {
        private ILessonsService lessonsService;

        public LessonController(
            ILessonsService lessonsService)
        {
            this.lessonsService = lessonsService;
        }

        public ActionResult Index()
        {

            return this.View();
        }

        public ActionResult Details(string subject, string name)
        {
            if (this.ModelState.IsValid)
            {
                var selectedLesson = this.lessonsService.GetBySubjectAndName(subject, name);

                var viewModel = this.Mapper.Map<LessonDetailsViewModel>(selectedLesson);

                return this.View(viewModel);
            }

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public ActionResult All(string subject = "", int take = 10, int skip = 0)
        {
            var viewModel = new LessonsListViewModel();
            var lessons = this.lessonsService.GetAll(skip, take);
            viewModel.PagesCount = this.lessonsService.GetCountBySubject(subject) / take;
            viewModel.Lessons = this.Mapper.Map<List<LessonTableDataViewModel>>(lessons);

            return this.View(viewModel);
        }
    }
}