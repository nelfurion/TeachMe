namespace TeachMe.Data.Services
{
    using Contracts;
    using System.Linq;
    using System;
    using Models;
    using Repositories;
    public class BattlesService : IBattlesService
    {
        private IRepository<Battle> battles;

        public BattlesService(IRepository<Battle> battles)
        {
            this.battles = battles;
        }

        public IQueryable<Battle> GetAll()
        {
            return this.battles.All();
        }

        public int GetCount()
        {
            return this.battles.All().Count();
        }
    }
}
