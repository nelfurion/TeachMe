namespace TeachMe.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Data.Services.Contracts;
    using Services.Data.Contracts;
    using ViewModels.LessonViewModels;
    using System.Linq;
    using ViewModels.CommentViewModels;
    public class LessonController : BaseController
    {
        private const int InitialCommentSkip = 0;
        private const int InitialCommentTake = 5;
        private ILessonsService lessonsService;
        private ICommentsService commentsService;

        public LessonController(
            ILessonsService lessonsService,
            ICommentsService commentsService)
        {
            this.lessonsService = lessonsService;
            this.commentsService = commentsService;
        }

        public ActionResult Index()
        {

            return this.View();
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