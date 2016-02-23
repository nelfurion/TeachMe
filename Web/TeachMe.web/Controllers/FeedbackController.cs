namespace TeachMe.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Models;
    using Data.Services.Contracts;
    using Microsoft.AspNet.Identity;
    using Models;

    [Authorize]
    public class FeedbackController : BaseController
    {
        private ITicketsService ticketsService;

        public FeedbackController(ITicketsService ticketsService)
        {
            this.ticketsService = ticketsService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateTicketViewModel model, string returnUrl)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            Ticket newTicket = this.Mapper.Map<Ticket>(model);
            newTicket.CreatedOn = DateTime.UtcNow;
            newTicket.CreatorId = this.User.Identity.GetUserId();

            this.ticketsService.Add(newTicket);

            return this.RedirectToAction("Index", "Home", new { area = "" });

        }

        [HttpGet]
        public async Task<ActionResult> All(int skip = 0, int take = 10)
        {
            this.ViewBag.Tickets = this.ticketsService
                .All()
                .OrderByDescending(t => t.CreatedOn)
                .Skip(skip * take)
                .Take(take)
                .ToList();

            return this.View();
        }
    }
}