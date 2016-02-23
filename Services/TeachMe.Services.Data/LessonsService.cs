namespace TeachMe.Data.Services
{
    using System.Linq;
    using Contracts;
    using Models;
    using TeachMe.Data.Common;
    public class LessonsService : ILessonsService
    {
        private IDbRepository<Lesson> lessons;

        public LessonsService(IDbRepository<Lesson> lessons)
        {
            this.lessons = lessons;
        }

        public IQueryable<Lesson> GetAll()
        {
            return lessons.All();
        }

        public Lesson GetById(int id)
        {
            return this.lessons
                .All()
                .FirstOrDefault(l => l.Id == id);
        }

        public int GetCount()
        {
            return lessons.All().Count();
        }
    }
}
