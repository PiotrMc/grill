using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class ConsumersRepository : IDisposable, IConsumersRepository
    {
        private readonly DbContext context;

        private readonly DbSet<Consumer> dbSet = null;
        public ConsumersRepository(DbContext context)
        {
            this.context = context;
            dbSet = context.Set<Consumer>();
        }
        public async Task<Consumer> GetAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<List<Consumer>> GetListAsync()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }
        public async Task<int> AddAsync(Consumer item)
        {
            try
            {
                await dbSet.AddAsync(item);
                return item.Id;
            }
            catch (Exception)
            {

                return -1;
            }

        }
        public async Task<bool> UpdateAsync(Consumer item)
        {
            try
            {
                await Task.Run(() => dbSet.Update(item));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetAsync(id);
            if (item != null)
            {
                dbSet.Remove(item);
                return true;
            }
            return false;
        }
        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public IQueryable<Consumer> FindBy(Expression<Func<Consumer, bool>> predicate)
        {
            return dbSet.Where(predicate).AsQueryable();
        }
        public DbContext Context { get; }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
