namespace TeachMe.Data.Services
{
    using System;
    using System.Linq;
    using TeachMe.Data.Models;
    using TeachMe.Data.Repositories;
    using TeachMe.Data.Services.Contracts;

    public class TicketsService : ITicketsService
    {
        private IRepository<Ticket> tickets;

        public TicketsService(IRepository<Ticket> tickets)
        {
            this.tickets = tickets;            
        }

        public void Add(Ticket ticket)
        {
            this.tickets.Add(ticket);
            this.tickets.SaveChanges();
        }

        public IQueryable<Ticket> All()
        {
            return this.tickets.All();
        }
    }
}
