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
    }
}