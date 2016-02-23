namespace TeachMe.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Common;
    using TeachMe.Data.Common.Models;
    using TeachMe.Data.Models;

    public class Ticket : BaseModel<int>
    {        
        [Required]
        public string CreatorId { get; set; }

        public string Title { get; set; }
        
        public virtual ApplicationUser Creator { get; set; }

        [Required]
        [MinLength(Constants.TicketMinLength)]
        [MaxLength(Constants.TicketMaxLength)]
        public string Content { get; set; }

        public DateTime? ClosedOn { get; set; }
    }
}
