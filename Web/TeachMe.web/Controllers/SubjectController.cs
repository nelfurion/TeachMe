namespace TeachMe.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using TeachMe.Data.Services.Contracts;

    public class SubjectController : Controller
    {
        private ISubjectsService subjectsService;

        public SubjectController(ISubjectsService subjectsService)
        {
            this.subjectsService = subjectsService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            this.ViewBag.Subjects = this.subjectsService
                .GetAll()
                .ToList();
            return View();
        }
    }
}