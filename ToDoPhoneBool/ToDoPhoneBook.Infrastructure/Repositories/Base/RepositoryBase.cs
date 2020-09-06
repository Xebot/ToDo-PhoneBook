using System.Linq;
using ToDoPhoneBook.Domain.Entites.Base;

namespace ToDoPhoneBook.Infrastructure.Repositories.Base
{
    /// <summary>
    /// Реализация базового репозитория.
    /// </summary>
    public abstract class RepositoryBase<T> : IRepository<T>
        where T : BaseEntityWithId
    {
        private readonly AppDbContext _dbContext;

        public RepositoryBase(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <inheritdoc/>
        public int Create(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        /// <inheritdoc/>
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        /// <inheritdoc/>
        public IQueryable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        /// <inheritdoc/>
        public int Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        /// <inheritdoc/>
        public T GetById(int id)
        {
            return _dbContext.Set<T>().Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
