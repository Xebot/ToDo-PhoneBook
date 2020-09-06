using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
