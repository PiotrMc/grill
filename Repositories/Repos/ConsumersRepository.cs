using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repos
{
    public class ConsumersRepository : IDisposable
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
            return await dbSet.ToListAsync();
        }
        public async Task<int> AddAsync(Customer item)
        {

        }


        public DbContext Context { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
