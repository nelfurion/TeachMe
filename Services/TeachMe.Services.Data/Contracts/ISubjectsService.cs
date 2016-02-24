namespace TeachMe.Data.Services.Contracts
{
    using System.Linq;
    using TeachMe.Data.Models;

    public interface ISubjectsService
    {
        IQueryable<Subject> GetAll();
    }
}
