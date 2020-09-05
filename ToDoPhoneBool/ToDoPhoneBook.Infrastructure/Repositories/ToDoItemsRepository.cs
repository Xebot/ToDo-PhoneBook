using System;
using System.Collections.Generic;
using System.Text;
using ToDoPhoneBook.Domain.Entites;
using ToDoPhoneBook.Infrastructure.Repositories.Base;

namespace ToDoPhoneBook.Infrastructure.Repositories
{
    public class ToDoItemsRepository : RepositoryBase<ToDoItem>, IToDoItemsRepository
    {
        public ToDoItemsRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
