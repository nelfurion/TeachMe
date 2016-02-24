namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;
    using TeachMe.Data.Common;
    using TeachMe.Data.Models;
    using TeachMe.Services.Data.Contracts;

    public class CommentsService : ICommentsService
    {
        private IDbRepository<Comment> comments;

        public CommentsService(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public IQueryable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public void Create(Comment comment, string userId)
        {
            comment.UserId = userId;
            comment.CreatedOn = DateTime.UtcNow;
            this.comments.Add(comment);
            this.comments.Save();
        }
    }
}
