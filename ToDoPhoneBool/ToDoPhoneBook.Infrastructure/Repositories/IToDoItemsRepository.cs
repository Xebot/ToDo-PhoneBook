using System;
using System.Collections.Generic;
using System.Text;
using ToDoPhoneBook.Domain.Entites;
using ToDoPhoneBook.Infrastructure.Repositories.Base;

namespace ToDoPhoneBook.Infrastructure.Repositories
{
    public interface IToDoItemsRepository : IRepository<ToDoItem>
    {
         
    }
}
