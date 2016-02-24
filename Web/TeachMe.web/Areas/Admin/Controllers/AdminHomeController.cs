namespace MvcTemplate.Web.Areas.Admin.Controllers
{
    using System.Web.Mvc;

    public class AdminHomeController : Controller
    {
        public ActionResult Index()
        {
            return this.View();
        }
    }
}