namespace TeachMe.Web.Areas.Admin.ViewModels.TicketViewModels
{
    using System.Collections.Generic;
    using TicketViewModels;

    public class TicketListViewModel
    {
        public List<TicketListRowViewModel> Tickets { get; set; }

        public int PagesCount { get; set; }
    }
}