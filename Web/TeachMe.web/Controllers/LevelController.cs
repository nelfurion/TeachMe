using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TeachMe.Data.Services.Contracts;

namespace TeachMe.web.Controllers
{
    public class LevelController : Controller
    {
        private ILessonsService lessonsService;

        public LevelController(
            ILessonsService lessonsService)
        {
            this.lessonsService = lessonsService;
        }

        public ActionResult Index()
        {

            return View();
        }

        public ActionResult All()
        {
            ViewBag.Lessons = lessonsService.GetAll();
            return View();
        }
    }
}