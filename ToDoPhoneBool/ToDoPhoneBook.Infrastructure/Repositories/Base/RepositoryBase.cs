using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoPhoneBook.Domain.Entites.Base;

namespace ToDoPhoneBook.Infrastructure.Repositories.Base
{
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : BaseEntityWithId
    {
        private readonly AppDbContext _dbContext;

        public RepositoryBase(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
