namespace TeachMe.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Data.Services.Contracts;
    using Microsoft.AspNet.Identity.Owin;

    public class HomeController : BaseController
    {
        private const string StatisticsCountKey = "StatisticsCount";
        private IBattlesService battlesService;
        private ILessonsService lessonsService;

        public HomeController(
            IBattlesService battlesService,
            ILessonsService lessonsService)
        {
            this.battlesService = battlesService;
            this.lessonsService = lessonsService;
        }

        private ApplicationUserManager userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return this.userManager ?? this.Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }

            private set
            {
                this.userManager = value;
            }
        }

        public ActionResult Index()
        {
            Statistics stats;
            stats = (Statistics)HttpContext.Cache[StatisticsCountKey];
            if (stats == null)
            {
                stats = new Statistics();
                stats.BattlesCount = battlesService.GetCount();
                stats.LessonsCount = lessonsService.GetCount();
                stats.UsersCount = this.UserManager.Users.Count();

                this.HttpContext.Cache.Add(StatisticsCountKey, stats, null, DateTime.UtcNow.AddHours(1), TimeSpan.Zero, System.Web.Caching.CacheItemPriority.Default, null);
            }

            ViewBag.UsersCount = stats.UsersCount;
            ViewBag.LessonsCount = stats.LessonsCount;
            ViewBag.BattlesCount = stats.BattlesCount;
            return View();
        }

        [AllowAnonymous]
        [OutputCache(Duration = 60 * 60)]
        public ActionResult GetUsersCount()
        {

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        internal class Statistics
        {
            public Statistics()
            {
                this.UsersCount = 0;
                this.LessonsCount = 0;
                this.BattlesCount = 0;
            }

            public int UsersCount { get; set; }

            public int LessonsCount { get; set; }

            public int BattlesCount { get; set; }
        }
    }
}
