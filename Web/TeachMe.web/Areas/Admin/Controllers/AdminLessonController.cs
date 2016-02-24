namespace MvcTemplate.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using TeachMe.Data.Models;
    using TeachMe.Data.Services.Contracts;
    using TeachMe.Services.Data.Contracts;
    using TeachMe.Web.Areas.Admin.ViewModels.LessonViewModels;
    using TeachMe.Web.Controllers;
    using TeachMe.Web.ViewModels.CommentViewModels;
    using TeachMe.Web.ViewModels.LessonViewModels;
    [Authorize(Roles = "Admin")]
    public class AdminLessonController : BaseController
    {
        private const int InitialCommentSkip = 0;
        private const int InitialCommentTake = 5;
        private ILessonsService lessonsService;
        private ICommentsService commentsService;
        private ISubjectsService subjectsService;

        public AdminLessonController(
            ILessonsService lessonsService,
            ICommentsService commentsService,
            ISubjectsService subjectsService)
        {
            this.lessonsService = lessonsService;
            this.commentsService = commentsService;
            this.subjectsService = subjectsService;
        }

        // GET: Admin/Level
        public ActionResult Index(string subject = "", int take = 10, int skip = 0)
        {
            var viewModel = new LessonsListViewModel();
            var lessons = this.lessonsService.GetAll(skip, take);
            viewModel.PagesCount = this.lessonsService.GetCountBySubject(subject) / take;
            viewModel.Lessons = this.Mapper.Map<List<LessonTableDataViewModel>>(lessons);

            return this.View(viewModel);
        }

        public ActionResult Details(string subject, string name)
        {
            var viewModel = new LessonDetailsViewModel();

            var selectedLesson = this.lessonsService.GetBySubjectAndName(subject, name);
            viewModel.Lesson = this.Mapper.Map<LessonViewModel>(selectedLesson);

            var lessonComments = this.commentsService
                .GetByLessonId(
                    selectedLesson.Id,
                    InitialCommentSkip,
                    InitialCommentTake);

            viewModel.Comments = this.Mapper.Map<List<CommentViewModel>>(lessonComments);
            viewModel.CommentPagesCount = this.commentsService.GetCommentsCountByLessonId(selectedLesson.Id);

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(CreateLessonViewModel lessonCreateModel)
        {
            var newLesson = this.Mapper.Map<Lesson>(lessonCreateModel);
            this.lessonsService.Create(newLesson);

            return this.RedirectToAction("Index");
        }
    }
}