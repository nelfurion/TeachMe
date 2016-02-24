namespace TeachMe.Data.Services.Contracts
{
    using System.Linq;
    using Models;

    public interface ILessonsService
    {
        IQueryable<Lesson> GetAll(int skip = 0, int take = 10);

        int GetCountBySubject(string subject);

        int GetCount();

        Lesson GetBySubjectAndName(string subject, string name);

        Lesson GetById(int id);

        void Create(Lesson lesson);
    }
}
