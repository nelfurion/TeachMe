﻿namespace TeachMe.Web.ViewModels.LessonViewModels
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class LessonViewModel : IMapFrom<Lesson>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public string Creator { get; set; }

        public int Grade { get; set; }

        public int Rating { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Lesson, LessonViewModel>()
                .ForMember(l => l.Creator, opts => opts.MapFrom(m => m.Creator.UserName))
                .ForMember(l => l.Subject, opts => opts.MapFrom(m => m.Subject.Name));
        }
    }
}