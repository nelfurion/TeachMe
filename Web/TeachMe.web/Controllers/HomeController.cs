using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeachMe.Data.Services.Contracts;

namespace TeachMe.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string StatisticsCountKey = "StatisticsCount";
        private IUsersService usersService;
        private IBattlesService battlesService;
        private ILessonsService lessonsService;

        public HomeController(
            IUsersService usersService,
            IBattlesService battlesService,
            ILessonsService lessonsService)
        {
            this.battlesService = battlesService;
            this.usersService = usersService;
            this.lessonsService = lessonsService;
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
                stats.UsersCount = usersService.GetCount();

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