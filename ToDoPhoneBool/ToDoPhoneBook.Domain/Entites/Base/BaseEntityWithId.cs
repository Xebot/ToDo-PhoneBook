using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoPhoneBook.Domain.Entites.Base
{
    /// <summary>
    /// Базовый класс для сущностей с идентификатором.
    /// </summary>
    public class BaseEntityWithId
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
