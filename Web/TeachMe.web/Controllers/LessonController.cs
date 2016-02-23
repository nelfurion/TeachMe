namespace TeachMe.Web.Controllers
{
    using System.Linq;
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

        public ActionResult Details(int id)
        {
            var selectedLesson = this.lessonsService.GetById(id);

           

            return this.View();
        }

        [HttpGet]
        public ActionResult All(string subject, int take = 10, int skip = 0)
        {
            var viewModel = new LessonsListViewModel();

            if (!string.IsNullOrEmpty(subject))
            {
                var lessons = this.lessonsService
                    .GetAll()
                    .Where(l => l.Subject.Name == subject);

                viewModel.PagesCount = lessons.Count() / take > 5 ? 5 : lessons.Count() / take;

                viewModel.Lessons = lessons
                    .OrderByDescending(l => l.CreatedOn)
                    .Skip(skip * take)
                    .Take(take)
                    .ToList();
            }
            else
            {
                var lessons = this.lessonsService
                    .GetAll();

                viewModel.PagesCount = lessons.Count() / take > 5 ? 5 : lessons.Count() / take ;

                viewModel.Lessons = lessons
                    .OrderByDescending(l => l.CreatedOn)
                    .Skip(skip * take)
                    .Take(take)
                    .ToList();
            }

            return View(viewModel);
        }
    }
}