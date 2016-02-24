namespace TeachMe.Web.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CreateTicketViewModel : IMapFrom<Ticket>, IMapTo<Ticket>
    {
        public string Title { get; set; }

        [Required]
        [MinLength(Constants.TicketMinLength)]
        [MaxLength(Constants.TicketMaxLength)]
        public string Content { get; set; }
    }
}