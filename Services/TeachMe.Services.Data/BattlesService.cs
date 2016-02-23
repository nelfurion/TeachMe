namespace TeachMe.Data.Services
{
    using System.Linq;
    using Contracts;
    using Models;
    using TeachMe.Data.Common;

    public class BattlesService : IBattlesService
    {
        private IDbRepository<Battle> battles;

        public BattlesService(IDbRepository<Battle> battles)
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
