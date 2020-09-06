using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoPhoneBook.Contracts.Enums;
using ToDoPhoneBook.Contracts.Models;
using ToDoPhoneBook.Core.Services.ToDoService;
using ToDoPhoneBook.Models;

namespace ToDoPhoneBook.WebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoItemsController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        /// <summary>
        /// Получает все записи удовлетворящие фильтру.
        /// </summary>
        /// <param name="filterDto">Фильтр.</param>
        [HttpPost]
        public IActionResult List([FromForm]SearchFilterDto filterDto)
        {
            var errors = ValidateSearchFilter(filterDto);

            if (errors.Count() > 0)
                return BadRequest(string.Join(Environment.NewLine, errors.ToArray()));            

            var items = _toDoService.GetToDoItems(ConvertFilter(filterDto));

            return Ok(items);
        }

        /// <summary>
        /// Отмечает выбранную запись выполненной.
        /// </summary>
        /// <param name="id">Идентификатор записи.</param>
        [Route("{id}")]
        [HttpGet]
        public IActionResult MakeDone(int id)
        {
            _toDoService.MarkItemDone(id);

            if (string.IsNullOrWhiteSpace(string.Empty))
               return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Валидирует входные параметры фильтра.
        /// </summary>
        /// <param name="filter">Фильтр.</param>
        /// <returns>Список ошибок валидации, либо пустой список, если ошибок нет.</returns>
        private List<string> ValidateSearchFilter(SearchFilterDto filter)
        {
            var errors = new List<string>();
            
            if (filter == null)
            {
                errors.Add("Фильтр для поиска не может быть пустым");
                return errors;
            }

            if (filter.Current < 0)
                errors.Add("Номер текущей страницы не может быть меньше 0");

            if (filter.RowCount < 0)
                errors.Add("Количество запрашиваемых элементов не может быть меньше 0");

            return errors;
                
        }

        /// <summary>
        /// Преобразует входящий фильтр в фильтр для выборки, который будет передан в сервис.
        /// </summary>
        /// <param name="filterDto">Входяций фильтр.</param>
        private SearchItemFilter ConvertFilter(SearchFilterDto filterDto)
        {
            var filter = new SearchItemFilter
            {
                PageNumber = filterDto.Current != 0 ? filterDto.Current-1 : filterDto.Current,
                TakeCount = filterDto.RowCount,
                SearchPhrase = filterDto.SearchPhrase
            };

            var sortType = Request.Form.TryGetValue("sort[itemType]", out var sortItemsType);
            if (sortType)
            {
                filter.SortType = sortType;
                filter.SortTypeDesc = string.Equals(sortItemsType, "desc", StringComparison.InvariantCultureIgnoreCase);
            }

            var sortDateStart = Request.Form.TryGetValue("sort[startDateString]", out var sortStartDateType);
            if (sortDateStart)
            {
                filter.SortStartDate = sortDateStart;
                filter.SortStartDateDesc = string.Equals(sortStartDateType, "desc", StringComparison.InvariantCultureIgnoreCase);
            }

            var sortDateEnd = Request.Form.TryGetValue("sort[endDateString]", out var sortEndDateType);
            if (sortDateEnd)
            {
                filter.SortEndDate = sortDateEnd;
                filter.SortEndDateDesc = string.Equals(sortEndDateType, "desc", StringComparison.InvariantCultureIgnoreCase);
            }

            filter.ItemType = int.TryParse(filterDto.Type, out var itemType) ? (ToDoTypeEnum)itemType : ToDoTypeEnum.AllTypes;
            filter.PeriodType = int.TryParse(filterDto.TimePeriod, out var periodType) ? (TimePeriodEnum)periodType : TimePeriodEnum.AllTime;

            if (DateTime.TryParse(filterDto.StartDateSearch, out var StartDT))
                filter.SearchStartDate = StartDT;

            if (DateTime.TryParse(filterDto.EndDateSearch, out var EndDT))
                filter.SearchEndDate = EndDT;

            return filter;
        }
    }
}
