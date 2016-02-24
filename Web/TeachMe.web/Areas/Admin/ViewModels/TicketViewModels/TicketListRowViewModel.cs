namespace TeachMe.Web.Areas.Admin.ViewModels.TicketViewModels
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class TicketListRowViewModel : IMapFrom<Ticket>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Creator { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Ticket, TicketListRowViewModel>()
                .ForMember(t => t.Creator, opts => opts.MapFrom(m => m.Creator.UserName));
        }
    }
}