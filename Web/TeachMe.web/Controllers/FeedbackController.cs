namespace TeachMe.Web.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Mvc;
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
        public ActionResult Create(CreateTicketViewModel model, string returnUrl)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var newTicket = this.Mapper.Map<Ticket>(model);

            newTicket.CreatedOn = DateTime.UtcNow;
            newTicket.CreatorId = this.User.Identity.GetUserId();

            this.ticketsService.Add(newTicket);

            return this.RedirectToAction("Index", "Home", new { area = "" });

        }
    }
}