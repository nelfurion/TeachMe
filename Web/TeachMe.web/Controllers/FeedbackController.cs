using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TeachMe.Data.Models;
using TeachMe.Data.Services.Contracts;
using TeachMe.Web.Models;

namespace TeachMe.Web.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        private ITicketsService ticketsService;

        public FeedbackController(ITicketsService ticketsService)
        {
            this.ticketsService = ticketsService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateTicketViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Ticket newTicket = Mapper.Map<Ticket>(model);
            newTicket.CreatedOn = DateTime.UtcNow;
            newTicket.CreatorId = this.User.Identity.GetUserId();

            this.ticketsService.Add(newTicket);

            return RedirectToAction("Index", "Home", new { area = "" });

        }

        [HttpGet]
        public async Task<ActionResult> All(int skip = 0, int take = 10)
        {
            ViewBag.Tickets = this.ticketsService
                .All()
                .OrderByDescending(t => t.CreatedOn)
                .Skip(skip * take)
                .Take(take)
                .ToList();

            return View();
        }
    }
}