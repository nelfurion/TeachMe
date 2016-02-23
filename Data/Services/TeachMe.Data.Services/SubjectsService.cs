namespace TeachMe.Data.Services
{
    using System;
    using System.Linq;
    using Models;
    using TeachMe.Data.Services.Contracts;
    using Repositories;
    public class SubjectsService : ISubjectsService
    {
        private IRepository<Subject> subjects;

        public SubjectsService(IRepository<Subject> subjects)
        {
            this.subjects = subjects;
        }

        public IQueryable<Subject> GetAll()
        {
            return this.subjects.All();
        }
    }
}
