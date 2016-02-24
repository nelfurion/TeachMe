namespace TeachMe.Data.Services
{
    using System;
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

        public IQueryable<Ticket> All(int skip, int take)
        {
            return this.tickets
                .All()
                .Where(t => !t.IsDeleted)
                .OrderByDescending(t => t.CreatedOn)
                .Skip(skip * take)
                .Take(take);
        }

        public void Delete(int id)
        {
            var ticket = this.tickets.GetById(id);
            this.tickets.Delete(ticket);
        }

        public Ticket GetById(int id)
        {
            return this.tickets
                .All()
                .FirstOrDefault(t => t.Id == id);
        }

        public int GetCount()
        {
            return this.tickets
                .All()
                .Count();
        }
    }
}
