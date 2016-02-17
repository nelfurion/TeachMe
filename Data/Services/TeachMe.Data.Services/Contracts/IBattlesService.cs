namespace TeachMe.Data.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IBattlesService
    {
        IQueryable<Battle> GetAll();

        int GetCount();
    }
}
