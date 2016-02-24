namespace TeachMe.Services.Data.Contracts
{
    using System.Linq;
    using TeachMe.Data.Models;

    public interface ICommentsService
    {
        IQueryable<Comment> GetAll();

        int GetCount();

        IQueryable<Comment> GetByLessonId(int lessonId, int skip, int take);

        int GetCommentsCountByLessonId(int lessonId);

        void Create(Comment comment, string userId);
    }
}
