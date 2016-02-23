namespace TeachMe.Web.Models
{
    using TeachMe.Web.Infrastructure.Mapping;
    using Data.Models;

    public class CreateTicketViewModel : IMapFrom<Ticket>
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}