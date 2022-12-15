using GocServer.Application.Interfaces.Repositories;
using GocServer.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GocServer.Persistence.Implementations.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T entity)
        {
            var result = await Table.AddAsync(entity);
            if (result.State == EntityState.Added)
            {
                return true;
            }

            return false;
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Table.AddRangeAsync(entities);
        }
        

        public IQueryable<T> GetAll()
        {
            return Table.AsQueryable();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public void RemoveAsync(T entity)
        {
            Table.Remove(entity);
        }

        public async Task<bool> RemoveByIdAsync(Guid id)
        {
            var obj = await Table.FindAsync(id);

            if (obj != null)
            {
                Table.Remove(obj);
                return true;
            }

            return false;
        }

        public void RemoveRangeAsync(IEnumerable<T> entities)
        {
            Table.RemoveRange(entities);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}