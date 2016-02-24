namespace TeachMe.Services.Data.Contracts
{
    using System.Linq;
    using TeachMe.Data.Models;

    public interface ICommentsService
    {
        IQueryable<Comment> GetAll();

        int GetCount();

        void Create(Comment comment, string userId);
    }
}
