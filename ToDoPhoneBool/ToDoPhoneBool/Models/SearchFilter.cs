﻿namespace ToDoPhoneBook.Models
{
    /// <summary>
    /// Фильтр для отображения записей ежедневника.
    /// </summary>
    public class SearchFilterDto
    {
        /// <summary>
        /// Запрашиваемая страница.
        /// </summary>
        public int Current { get; set; }

        /// <summary>
        /// Количество запрашиваемых элементов.
        /// </summary>
        public int RowCount { get; set; }

        /// <summary>
        /// Текст поискового запроса.
        /// </summary>
        public string SearchPhrase { get; set; }

        /// <summary>
        /// Период за который отображать записи.
        /// </summary>
        public string TimePeriod { get; set; }

        /// <summary>
        /// Тип запрашиваемых записей.
        /// </summary>
        public string Type { get;set; }

        /// <summary>
        /// Дата для поиска по дате начала.
        /// </summary>
        public string StartDateSearch { get; set; }

        /// <summary>
        /// Дата для поиска по дате окончания.
        /// </summary>
        public string EndDateSearch { get; set; }
    }
}
