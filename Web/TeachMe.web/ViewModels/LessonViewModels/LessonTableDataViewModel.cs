namespace TeachMe.Web.ViewModels.LessonViewModels
{
    using System;
    using AutoMapper;
    using TeachMe.Data.Models;
    using TeachMe.Web.Infrastructure.Mapping;

    public class LessonTableDataViewModel : IMapFrom<Lesson>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string Subject { get; set; }

        public int Grade { get; set; }

        public string Creator { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Lesson, LessonTableDataViewModel>()
                .ForMember(l => l.Subject, opts => opts.MapFrom(m => m.Subject.Name))
                .ForMember(l => l.Creator, opts => opts.MapFrom(m => m.Creator.UserName));
        }
    }
}