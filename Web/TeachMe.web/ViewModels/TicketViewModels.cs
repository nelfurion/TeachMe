namespace TeachMe.Web.Models
{
    using Infrastructure.Mappings;
    using TeachMe.Data.Models;

    public class CreateTicketViewModel : IMapFrom<Ticket>
    {
        public string Title { get; set; }

        public string Content { get; set; }
    }
}