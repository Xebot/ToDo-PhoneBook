using System;
using ToDoPhoneBook.Contracts.Enums;

namespace ToDoPhoneBook.Contracts.Models
{
    public class ToDoItemDto
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тип записи.
        /// </summary>
        public ToDoTypeEnum ItemType { get; set; }

        /// <summary>
        /// Тема.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Дата и время начала.
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Дата и время окончания.
        /// </summary>
        public DateTime? EndDate { get; set; }

        /// <summary>
        /// Место.
        /// </summary>
        public string Place { get; set; }
    }
}
