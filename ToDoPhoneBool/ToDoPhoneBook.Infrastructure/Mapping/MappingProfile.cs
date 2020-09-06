using AutoMapper;
using ToDoPhoneBook.Contracts.Enums;
using ToDoPhoneBook.Contracts.Models;
using ToDoPhoneBook.Domain.Entites;
using ToDoPhoneBook.Infrastructure.Tools;

namespace ToDoPhoneBook.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoItem, ToDoItemDto>()
                .ForMember(dest => dest.ItemType, opt => opt.MapFrom(src => EnumHelper<ToDoTypeEnum>.GetDisplayValue(src.ItemType)))
                .ForMember(dest => dest.StartDateString, opt => opt.MapFrom(src => src.StartDate.HasValue 
                ? src.StartDate.Value.ToString("MM/dd/yyyy HH:mm:ss")
                : string.Empty))
                .ForMember(dest => dest.EndDateString, opt => opt.MapFrom(src => src.EndDate.HasValue
                ? src.EndDate.Value.ToString("MM/dd/yyyy HH:mm:ss")
                : string.Empty));
        }
    }
}
