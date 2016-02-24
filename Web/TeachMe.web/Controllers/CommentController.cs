namespace MvcTemplate.Web.Controllers
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using TeachMe.Data.Models;
    using TeachMe.Services.Data.Contracts;
    using TeachMe.Web;
    using TeachMe.Web.Controllers;
    using TeachMe.Web.ViewModels.CommentViewModels;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;
    public class CommentController : BaseController
    {
        private ICommentsService commentsService;

        public CommentController(ICommentsService commentsService)
        {
            this.commentsService = commentsService;
        }

        [HttpPost]
        public ActionResult Create(CreateCommentViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                if (!this.User.Identity.IsAuthenticated)
                {
                    this.RedirectToAction("Register", "Account");
                }

                try
                {
                    var userId = this.User.Identity.GetUserId();
                    var newComment = this.Mapper.Map<Comment>(model);


                    this.commentsService.Create(newComment, userId);
                }
                catch(Exception e)
                {

                }
            }

            return this.Redirect(this.Request.UrlReferrer.AbsolutePath);
        }

        [HttpGet]
        public ActionResult CommentPagePartial(int lessonId, int skip = 0, int take = 5)
        {
            var comments = this.commentsService.GetByLessonId(lessonId, skip, take).ToList();

            var viewModel = new CommentPageViewModel()
            {
                CommentViewModels = new List<CommentViewModel>()
            };

            for (int i = 0; i < comments.Count; i++)
            {
                var commentViewModel = this.Mapper.Map<CommentViewModel>(comments[i]);
                viewModel.CommentViewModels.Add(commentViewModel);
            }

            return this.View(viewModel);
        }
    }
}