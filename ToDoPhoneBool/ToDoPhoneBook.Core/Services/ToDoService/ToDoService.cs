using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using ToDoPhoneBook.Contracts.Enums;
using ToDoPhoneBook.Contracts.Models;
using ToDoPhoneBook.Domain.Entites;
using ToDoPhoneBook.Infrastructure.Repositories;
using ToDoPhoneBook.Infrastructure.Tools;

namespace ToDoPhoneBook.Core.Services.ToDoService
{
    /// <summary>
    /// Сервис по работе с записями ежедневника.
    /// </summary>
    public class ToDoService : IToDoService
    {
        private readonly IToDoItemsRepository _toDoItemsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<ToDoService> _logger;

        public ToDoService(
            IToDoItemsRepository toDoItemsRepository,
            IMapper mapper,
            ILogger<ToDoService> logger)
        {
            _toDoItemsRepository = toDoItemsRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <inheritdoc/>
        public ToDoItemsListDto GetToDoItems(SearchItemFilter filter)
        {
            var query = _toDoItemsRepository.GetAll();

            if (filter.ItemType != ToDoTypeEnum.AllTypes)
                query = query.Where(x => x.ItemType == filter.ItemType);

            if (!string.IsNullOrWhiteSpace(filter.SearchPhrase))
                query = query.Where(x => EF.Functions.Like(x.Title.ToUpper(), $"%{filter.SearchPhrase.ToUpper()}%"));

            query = TakeByTimePeriod(query, filter.PeriodType);

            query = ApplyDateSearch(query, filter);

            var totalCount = query.Count();
            var entities = query.Skip(filter.PageNumber * filter.TakeCount).Take(filter.TakeCount);
            
            entities = ApplySort(entities, filter);

            var dtos = entities.Select(x => _mapper.Map<ToDoItemDto>(x)).ToList();

            return new ToDoItemsListDto
            {
                Current = filter.PageNumber+1,
                rowCount = filter.TakeCount,
                rows = dtos,
                total = totalCount
            };
        }

        /// <inheritdoc/>
        public void DeleteItem(int id)
        {
            var item = _toDoItemsRepository.GetById(id);

            if (item == null)
            {
                _logger.LogError($"Не найдена запись для удаления с Id = {id}");
                throw new Exception("Запись не найдена");
            }                

            try
            {
                _toDoItemsRepository.Delete(item);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, $"При попытке удаления записи с Id = {id} произошла ошибка");
                throw new Exception("При попытке удаления записи произошла ошибка");
            }
        }

        /// <inheritdoc/>
        public void MarkItemDone(int id)
        {
            var item = _toDoItemsRepository.GetById(id);

            if (item == null)
                return;

            item.IsDone = true;
            _toDoItemsRepository.Update(item);
        }

        /// <inheritdoc/>
        public ToDoItemDto GetItem(int id)
        {
            var item = _toDoItemsRepository.GetById(id);

            if (item == null)
                return null;

            return _mapper.Map<ToDoItemDto>(item);
        }

        /// <inheritdoc/>
        public void UpdateItem(ToDoItemDto dto)
        {
            var item = _toDoItemsRepository.GetById(dto.Id);

            if (item == null)
            {
                _logger.LogError($"Не найдена сущность с Id = {dto.Id} при попытке обновления.");
                throw new ArgumentNullException();
            }                

            item.ItemType = EnumHelper<ToDoTypeEnum>.ParseEnum(dto.ItemType);
            item.Title = dto.Title;
            item.StartDate = dto.StartDate;
            item.EndDate = item.ItemType ==ToDoTypeEnum.Memo ? (DateTime?)null : dto.EndDate;
            item.Place = item.ItemType == ToDoTypeEnum.Meeting ? dto.Place : string.Empty;
            item.IsDone = dto.IsDone;

            _toDoItemsRepository.Update(item);
        }

        /// <inheritdoc/>
        public int CreateItem(ToDoItemDto dto)
        {
            var itemType = EnumHelper<ToDoTypeEnum>.ParseEnum(dto.ItemType);
            var item = new ToDoItem
            {
                ItemType = itemType,
                Title = dto.Title,
                StartDate = dto.StartDate,
                EndDate = itemType == ToDoTypeEnum.Memo ? (DateTime?)null : dto.EndDate,
                Place = itemType == ToDoTypeEnum.Meeting ? dto.Place : string.Empty,
                IsDone = dto.IsDone
            };

            return _toDoItemsRepository.Create(item);
        }

        private IQueryable<ToDoItem> ApplyDateSearch(IQueryable<ToDoItem> query, SearchItemFilter filter)
        {
            if (filter.SearchStartDate.HasValue)
                return query.Where(x => x.StartDate.HasValue && x.StartDate.Value.Date == filter.SearchStartDate.Value.Date);

            if (filter.SearchEndDate.HasValue)
                return query.Where(x => x.EndDate == filter.SearchEndDate);

            return query;
        }

        private IQueryable<ToDoItem> TakeByTimePeriod(IQueryable<ToDoItem> query, TimePeriodEnum period)
        {            
            switch (period)
            {
                case TimePeriodEnum.Day:
                    var startOfDay = DateTime.Now.StartOfDay();
                    var endOfDay = DateTime.Now.EndOfDay();
                    return query.Where(x => x.StartDate >= startOfDay
                        && ((x.EndDate.HasValue && x.EndDate <= endOfDay) || x.StartDate <= endOfDay));
                
                case TimePeriodEnum.Week:
                    var startOfWeek = DateTime.Now.StartOfWeek(DayOfWeek.Monday);
                    var endOfWeek = DateTime.Now.EndOfWeek(DayOfWeek.Monday);
                    return query.Where(x => x.StartDate >= startOfWeek
                    && ((x.EndDate.HasValue && x.EndDate <= endOfWeek) || x.StartDate <= endOfWeek));
                
                case TimePeriodEnum.Month:
                    var startOfMonth = DateTime.Now.StartOfMonth();
                    var endOfMonth = DateTime.Now.EndOfMonth();
                    return query.Where(x => x.StartDate >= startOfMonth
                    && ((x.EndDate.HasValue && x.EndDate <= endOfMonth) || x.StartDate <= endOfMonth));
                
                case TimePeriodEnum.AllTime:    
                default:
                    return query;
            }
        }

        private IQueryable<ToDoItem> ApplySort(IQueryable<ToDoItem> query, SearchItemFilter filter)
        {
            if (filter.SortType)
                return filter.SortTypeDesc ? query.OrderByDescending(x => x.ItemType) : query.OrderBy(x => x.ItemType);

            if (filter.SortStartDate)
                return filter.SortTypeDesc ? query.OrderByDescending(x => x.StartDate) : query.OrderBy(x => x.StartDate);

            if (filter.SortEndDate)
                return filter.SortEndDateDesc ? query.OrderByDescending(x => x.EndDate) : query.OrderBy(x => x.EndDate);

            return query;
        }
    }
}
