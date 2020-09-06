using System;
using System.Collections.Generic;
using System.Text;
using ToDoPhoneBook.Contracts.Enums;

namespace ToDoPhoneBook.Contracts.Models
{
    /// <summary>
    /// Фильтр для поиска записей ежедневника.
    /// </summary>
    public class SearchItemFilter
    {
        public int PageNumber { get; set; }

        public int TakeCount { get; set; }

        public string SearchPhrase { get; set; }

        public ToDoTypeEnum ItemType { get; set; }

        public TimePeriodEnum PeriodType { get; set; }

        public bool SortType { get; set; }

        public bool SortTypeDesc { get; set; }

        public bool SortStartDate { get; set; }

        public bool SortStartDateDesc { get; set; }

        public bool SortEndDate { get; set; }

        public bool SortEndDateDesc { get; set; }
    }
}
