namespace TeachMe.Data.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface ILessonsService
    {
        IQueryable<Lesson> GetAll();

        int GetCount();
    }
}
