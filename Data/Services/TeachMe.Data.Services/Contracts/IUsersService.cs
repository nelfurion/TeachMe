namespace TeachMe.Data.Services.Contracts
{
    using Models;
    using System.Linq;

    public interface IUsersService
    {
        IQueryable<User> GetAll();

        int GetCount();
    }
}
