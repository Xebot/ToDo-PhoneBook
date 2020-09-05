using System;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoPhoneBook.Contracts.Enums;
using ToDoPhoneBook.Domain.Entites.Base;

namespace ToDoPhoneBook.Domain.Entites
{
    /// <summary>
    /// Класс представляющий сущность "Запись".
    /// </summary>
    [Table("ToDoItem")]
    public class ToDoItem : BaseEntityWithId
    {
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
