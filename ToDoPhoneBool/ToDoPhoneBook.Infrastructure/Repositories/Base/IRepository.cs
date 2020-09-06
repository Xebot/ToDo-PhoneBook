using System.Linq;
using ToDoPhoneBook.Domain.Entites.Base;

namespace ToDoPhoneBook.Infrastructure.Repositories.Base
{
    /// <summary>
    /// Обобщенный интерфейс репозитория.
    /// </summary>
    public interface IRepository<T>
        where T : BaseEntityWithId
    {
        /// <summary>
        /// Получить все записи.
        /// </summary>
        IQueryable<T> GetAll();

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="entity">Запись.</param>
        int Create(T entity);

        /// <summary>
        /// Обновить указанную запись.
        /// </summary>
        /// <param name="entity">Обновляемая запись.</param>
        int Update(T entity);

        /// <summary>
        /// Удалить указанную запись.
        /// </summary>
        /// <param name="entity">Удаляемая запись.</param>
        void Delete(T entity);

        /// <summary>
        /// Получить запись по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор.</param>
        T GetById(int id);
    }
}
