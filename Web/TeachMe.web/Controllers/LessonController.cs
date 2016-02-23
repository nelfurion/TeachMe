namespace TeachMe.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using TeachMe.Data.Services.Contracts;
    using ViewModels.LessonViewModels;
    public class LessonController : Controller
    {
        private ILessonsService lessonsService;

        public LessonController(
            ILessonsService lessonsService)
        {
            this.lessonsService = lessonsService;
        }

        public ActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public ActionResult All(string subject, int take = 10, int skip = 0)
        {
            var viewModel = new LessonsListViewModel();
            

            if (!string.IsNullOrEmpty(subject))
            {
                var lessons = lessonsService
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
                var lessons = lessonsService
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