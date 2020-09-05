using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoPhoneBook.Contracts.Models;
using ToDoPhoneBook.Domain.Entites;

namespace ToDoPhoneBook.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoItem, ToDoItemDto>();
        }
    }
}
