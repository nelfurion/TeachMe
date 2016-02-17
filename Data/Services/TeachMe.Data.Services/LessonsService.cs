namespace TeachMe.Data.Services
{
    using Contracts;
    using System.Linq;
    using System;
    using Models;
    using Repositories;

    public class LessonsService : ILessonsService
    {
        private IRepository<Lesson> lessons;

        public LessonsService(IRepository<Lesson> lessons)
        {
            this.lessons = lessons;
        }

        public IQueryable<Lesson> GetAll()
        {
            return lessons.All();
        }

        public int GetCount()
        {
            return lessons.All().Count();
        }
    }
}
