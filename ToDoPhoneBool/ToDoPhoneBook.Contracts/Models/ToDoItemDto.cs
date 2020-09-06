using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        public string ItemType { get; set; }

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
        /// Дата и время начала.
        /// </summary>
        public string StartDateString { get; set; }

        /// <summary>
        /// Дата и время окончания.
        /// </summary>
        public string EndDateString { get; set; }

        /// <summary>
        /// Место.
        /// </summary>
        public string Place { get; set; }

        /// <summary>
        /// Признак выполнения.
        /// </summary>
        public bool IsDone { get; set; }
    }
}
