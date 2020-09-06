using ToDoPhoneBook.Domain.Entites;
using ToDoPhoneBook.Infrastructure.Repositories.Base;

namespace ToDoPhoneBook.Infrastructure.Repositories
{
    /// <summary>
    /// Интерфейс репозитория записей ежедневника.
    /// </summary>
    public interface IToDoItemsRepository : IRepository<ToDoItem>
    {
         
    }
}
