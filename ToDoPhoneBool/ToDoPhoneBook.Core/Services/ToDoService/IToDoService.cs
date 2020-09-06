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
        ToDoItemsListDto GetToDoItems(SearchItemFilter filter);

        /// <summary>
        /// Удаляет запись с указанным идентификатором.
        /// </summary>
        /// <param name="id">Идентификатор записи.</param>
        void DeleteItem(int id);

        /// <summary>
        /// Помечает запись с указанным идентификатором выполненной.
        /// </summary>
        /// <param name="id">Идентификатор записи.</param>
        void MarkItemDone(int id);

        /// <summary>
        /// Получает запись по указанному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        ToDoItemDto GetItem(int id);

        /// <summary>
        /// Обновляет указанную запись.
        /// </summary>
        /// <param name="dto">Транспортная модель записи.</param>
        void UpdateItem(ToDoItemDto dto);

        /// <summary>
        /// Создает новую запись.
        /// </summary>
        /// <param name="dto">Транспортная модель новой записи.</param>
        int CreateItem(ToDoItemDto dto);
    }
}
