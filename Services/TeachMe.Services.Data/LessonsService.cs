namespace TeachMe.Data.Services
{
    using System.Linq;
    using Common;
    using Contracts;
    using Models;
    using System;
    public class LessonsService : ILessonsService
    {
        private IDbRepository<Lesson> lessons;
        private IDbRepository<Rating> ratings;

        public LessonsService(IDbRepository<Lesson> lessons, IDbRepository<Rating> ratings)
        {
            this.lessons = lessons;
            this.ratings = ratings;
        }

        public IQueryable<Lesson> GetAll(int skip = 0, int take = 10)
        {
            return this.lessons
                .All()
                .OrderByDescending(l => l.CreatedOn)
                    .Skip(skip * take)
                    .Take(take);
        }

        public Lesson GetById(int id)
        {
            return this.lessons
                .All()
                .FirstOrDefault(l => l.Id == id);
        }

        public Lesson GetBySubjectAndName(string subject, string name)
        {
            return this.lessons
                .All()
                .FirstOrDefault(l => l.Subject.Name == subject &&
                    l.Name == name);
        }

        public int GetCount()
        {
            return this.lessons
                .All()
                .Count();
        }

        public int GetCountBySubject(string subject)
        {
            return this.lessons
                .All()
                .Where(l => l.Subject.Name.Contains(subject))
                .Count();
        }

        public void Create(Lesson lesson)
        {
            lesson.CreatedOn = DateTime.UtcNow;

            this.lessons.Add(lesson);
            this.lessons.Save();
        }
    }
}
