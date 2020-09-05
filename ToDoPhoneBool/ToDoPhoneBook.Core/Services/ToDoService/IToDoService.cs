using System;
using System.Collections.Generic;
using System.Text;
using ToDoPhoneBook.Contracts.Models;

namespace ToDoPhoneBook.Core.Services.ToDoService
{
    /// <summary>
    /// Интерфейс сервиса по работе с записями ежедневника.
    /// </summary>
    public interface IToDoService
    {
        /// <summary>
        /// Возвращает записи ежедневника с учетом номера страницы и количества запрошеных элементов.
        /// </summary>
        /// <param name="count">Количество запрошенных записей.</param>
        /// <param name="pageNumber">Номер страницы.</param>
        ToDoItemsListDto GetToDoItems(int count, int pageNumber); 
    }
}
