using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoPhoneBook.Contracts.Enums
{
    /// <summary>
    /// Тип записи.
    /// </summary>
    public enum ToDoTypeEnum
    {
        /// <summary>
        /// Встреча.
        /// </summary>
        [Display(Name = "Встреча")]
        Meeting = 1,

        /// <summary>
        /// Дело.
        /// </summary>
        [Display(Name = "Дело")]
        Business = 2,

        /// <summary>
        /// Памятка.
        /// </summary>
        [Display(Name = "Памятка")]
        Memo = 3,

        /// <summary>
        /// Все события.
        /// </summary>
        [Display(Name = "Все события")]
        [NonSerialized]
        AllTypes = 4
    }
}
