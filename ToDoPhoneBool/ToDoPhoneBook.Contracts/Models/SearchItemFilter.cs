using System;
using ToDoPhoneBook.Contracts.Enums;

namespace ToDoPhoneBook.Contracts.Models
{
    /// <summary>
    /// Фильтр для поиска записей ежедневника.
    /// </summary>
    public class SearchItemFilter
    {
        /// <summary>
        /// Номер страницы.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Количество запрашиваемых данных.
        /// </summary>
        public int TakeCount { get; set; }

        /// <summary>
        /// Поисковая фраза.
        /// </summary>
        public string SearchPhrase { get; set; }

        /// <summary>
        /// Тип записи.
        /// </summary>
        public ToDoTypeEnum ItemType { get; set; }

        /// <summary>
        /// Запрашиваемый период.
        /// </summary>
        public TimePeriodEnum PeriodType { get; set; }

        /// <summary>
        /// Признак сортировки по типу записи.
        /// </summary>
        public bool SortType { get; set; }

        /// <summary>
        /// Сортировать ли по типу по убыванию.
        /// </summary>
        public bool SortTypeDesc { get; set; }

        /// <summary>
        /// Признак сортировки по дате начала.
        /// </summary>
        public bool SortStartDate { get; set; }

        /// <summary>
        /// Сортировать ли дату начала по убывания.
        /// </summary>
        public bool SortStartDateDesc { get; set; }

        /// <summary>
        /// Признак сортировки по дате конца.
        /// </summary>
        public bool SortEndDate { get; set; }

        /// <summary>
        /// Сортировать ли дату конца по убыванию.
        /// </summary>
        public bool SortEndDateDesc { get; set; }

        /// <summary>
        /// Дата начала для поиска.
        /// </summary>
        public DateTime? SearchStartDate { get; set; }

        /// <summary>
        /// Дата окончания для поиска.
        /// </summary>
        public DateTime? SearchEndDate { get; set; }
    }
}
