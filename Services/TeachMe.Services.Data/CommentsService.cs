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

        public IQueryable<Comment> GetByLessonId(int lessonId, int skip, int take)
        {
            return this.comments
                .All()
                .Where(c => c.LessonId == lessonId)
                .OrderByDescending(c => c.CreatedOn)
                .Skip(skip)
                .Take(take);
        }

        public void Create(Comment comment, string userId)
        {
            comment.UserId = userId;
            comment.CreatedOn = DateTime.UtcNow;
            this.comments.Add(comment);
            this.comments.Save();
        }

        public int GetCommentsCountByLessonId(int lessonId)
        {
            return this.comments
                .All()
                .Where(c => c.LessonId == lessonId)
                .Count();
        }

        public IQueryable<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }
    }
}
