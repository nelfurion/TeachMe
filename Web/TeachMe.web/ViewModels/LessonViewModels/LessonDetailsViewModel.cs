namespace TeachMe.Web.ViewModels.LessonViewModels
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class LessonDetailsViewModel : IMapFrom<Lesson>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public string Creator { get; set; }

        public int Grade { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<LessonCommentViewModel> Comments { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Lesson, LessonDetailsViewModel>()
                .ForMember(l => l.Creator, opts => opts.MapFrom(m => m.Creator.UserName))
                .ForMember(l => l.Rating, opts => opts.MapFrom(m => m.Rating.Value))
                .ForMember(l => l.Subject, opts => opts.MapFrom(m => m.Subject.Name));
        }
    }
}