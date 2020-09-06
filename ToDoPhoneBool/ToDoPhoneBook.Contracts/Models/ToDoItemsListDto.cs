using System.Collections.Generic;

namespace ToDoPhoneBook.Contracts.Models
{
    /// <summary>
    /// Транспортная модель списка записей.
    /// </summary>
    public class ToDoItemsListDto
    {
        /// <summary>
        /// Текущая страница.
        /// </summary>
        public int Current { get; set; }

        /// <summary>
        /// Количество записей.
        /// </summary>
        public int rowCount { get; set; }

        /// <summary>
        /// Записи.
        /// </summary>
        public List<ToDoItemDto> rows { get; set; }

        /// <summary>
        /// Общее количество найденых записей.
        /// </summary>
        public int total { get; set; }
    }
}
