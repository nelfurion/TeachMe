namespace TeachMe.Data.Services
{
    using System.Linq;
    using Contracts;
    using Models;
    using TeachMe.Data.Common;

    public class TicketsService : ITicketsService
    {
        private IDbRepository<Ticket> tickets;

        public TicketsService(IDbRepository<Ticket> tickets)
        {
            this.tickets = tickets;            
        }

        public void Add(Ticket ticket)
        {
            this.tickets.Add(ticket);
            this.tickets.Save();
        }

        public IQueryable<Ticket> All()
        {
            return this.tickets.All();
        }
    }
}
