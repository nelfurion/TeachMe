namespace TeachMe.Web.ViewModels.LessonViewModels
{
    using System;
    using AutoMapper;
    using TeachMe.Data.Models;
    using TeachMe.Web.Infrastructure.Mapping;

    public class LessonCommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public string Creator { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Comment, LessonCommentViewModel>()
                .ForMember(c => c.Creator, opts => opts.MapFrom(m => m.User.UserName));
        }
    }
}