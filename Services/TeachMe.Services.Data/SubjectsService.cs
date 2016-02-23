namespace TeachMe.Data.Services
{
    using System.Linq;
    using Contracts;
    using Models;
    using TeachMe.Data.Common;

    public class SubjectsService : ISubjectsService
    {
        private IDbRepository<Subject> subjects;

        public SubjectsService(IDbRepository<Subject> subjects)
        {
            this.subjects = subjects;
        }

        public IQueryable<Subject> GetAll()
        {
            return this.subjects.All();
        }
    }
}
