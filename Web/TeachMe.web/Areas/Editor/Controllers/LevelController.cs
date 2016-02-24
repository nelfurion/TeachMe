namespace MvcTemplate.Web.Areas.Editor.Controllers
{
    using System.Web.Mvc;

    [Authorize(Roles = "Editor")]
    public class LevelController : Controller
    {
        // GET: Editor/Level
        public ActionResult Index()
        {
            return this.View();
        }
    }
}