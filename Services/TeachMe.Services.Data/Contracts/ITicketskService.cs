namespace TeachMe.Data.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface ITicketsService
    {
        void Add(Ticket ticket);

        IQueryable<Ticket> All(int skip, int take);

        int GetCount();

        void Delete(int id);

        Ticket GetById(int id);
    }
}
