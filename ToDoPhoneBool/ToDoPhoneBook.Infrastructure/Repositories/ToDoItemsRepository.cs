using ToDoPhoneBook.Domain.Entites;
using ToDoPhoneBook.Infrastructure.Repositories.Base;

namespace ToDoPhoneBook.Infrastructure.Repositories
{
    /// <summary>
    /// Реализация репозитория записей ежедневника.
    /// </summary>
    public class ToDoItemsRepository : RepositoryBase<ToDoItem>, IToDoItemsRepository
    {
        public ToDoItemsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
