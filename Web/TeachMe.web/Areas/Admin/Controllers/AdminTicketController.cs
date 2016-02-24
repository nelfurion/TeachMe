namespace MvcTemplate.Web.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using TeachMe.Data.Services.Contracts;
    using TeachMe.Web.Areas.Admin.ViewModels.TicketViewModels;
    using TeachMe.Web.Controllers;

    public class AdminTicketController : BaseController
    {
        private ITicketsService ticketsService;

        public AdminTicketController(ITicketsService ticketsService)
        {
            this.ticketsService = ticketsService;
        }

        [HttpGet]
        public ActionResult All(int skip = 0, int take = 10)
        {
            var tickets = this.ticketsService
                .All(skip, take)
                .ToList();

            var viewModel = new TicketListViewModel()
            {
                Tickets = this.Mapper.Map<List<TicketListRowViewModel>>(tickets),
            };

            viewModel.PagesCount = this.ticketsService.GetCount();

            return this.View(viewModel);
        }
    }
}