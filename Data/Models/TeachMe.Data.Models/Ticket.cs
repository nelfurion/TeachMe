﻿namespace TeachMe.Data.Models
{
    using Common;
    using System;
    using System.ComponentModel.DataAnnotations;
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public User Creator { get; set; }

        [Required]
        [MinLength(Constants.TicketMinLength)]
        [MaxLength(Constants.TicketMaxLength)]
        public string Content { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public DateTime? ClosedOn { get; set; }
    }
}
