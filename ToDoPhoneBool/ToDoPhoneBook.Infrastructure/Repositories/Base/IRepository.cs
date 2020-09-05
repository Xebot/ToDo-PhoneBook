using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoPhoneBook.Domain.Entites.Base;

namespace ToDoPhoneBook.Infrastructure.Repositories.Base
{
    /// <summary>
    /// Обобщенный интерфейс репозитория.
    /// </summary>
    public interface IRepository<T>
        where T : BaseEntityWithId
    {
        IQueryable<T> GetAll();

        int Create(T entity);

        int Update(T entity);

        void Delete(int entity);
    }
}
