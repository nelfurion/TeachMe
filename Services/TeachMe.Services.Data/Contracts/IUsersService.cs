namespace TeachMe.Data.Services.Contracts
{
    using System.Linq;
    using TeachMe.Data.Models;

    public interface IUsersService
    {
        IQueryable<ApplicationUser> GetAll();

        int GetCount();
    }
}
