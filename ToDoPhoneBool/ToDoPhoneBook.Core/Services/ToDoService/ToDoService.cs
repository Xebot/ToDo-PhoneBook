using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using ToDoPhoneBook.Contracts.Models;
using ToDoPhoneBook.Domain.Entites;
using ToDoPhoneBook.Infrastructure.Repositories;
using ToDoPhoneBook.Infrastructure.Repositories.Base;

namespace ToDoPhoneBook.Core.Services.ToDoService
{
    public class ToDoService : IToDoService
    {
        private readonly IToDoItemsRepository _toDoItemsRepository;
        private readonly IMapper _mapper;

        public ToDoService(
            IToDoItemsRepository toDoItemsRepository,
            IMapper mapper)
        {
            _toDoItemsRepository = toDoItemsRepository;
            _mapper = mapper;
        }

        public ToDoItemsListDto GetToDoItems(int takeCount, int pageNumber)
        {
            var totalCount = _toDoItemsRepository.GetAll().Count();
            pageNumber = pageNumber == 0 ? pageNumber : pageNumber - 1;
            var entities = _toDoItemsRepository.GetAll().Skip(pageNumber * takeCount).Take(takeCount);            

            var dtos = entities.Select(x => _mapper.Map<ToDoItemDto>(x)).ToList();

            return new ToDoItemsListDto
            {
                Current = pageNumber+1,
                rowCount = takeCount+1,
                rows = dtos,
                total = totalCount+20
            };
        }
    }
}
