using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {

        public DbSet<T> Table { get; }

        Task<T> GetByIdAsync(Guid id);
        IQueryable<T> GetAll();

        Task<bool> RemoveByIdAsync(Guid id);
        void RemoveAsync(T entity);
        void RemoveRangeAsync(IEnumerable<T> entities);

        Task<bool> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        
        
        Task<int> SaveChangesAsync();
    }
}
