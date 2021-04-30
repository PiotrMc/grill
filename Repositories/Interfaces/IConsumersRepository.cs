using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IConsumersRepository
    {
        DbContext Context { get; }

        Task<int> AddAsync(Consumer item);
        Task<bool> DeleteAsync(int id);
        void Dispose();
        IQueryable<Consumer> FindBy(Expression<Func<Consumer, bool>> predicate);
        Task<Consumer> GetAsync(int id);
        Task<List<Consumer>> GetListAsync();
        Task SaveChangesAsync();
        Task<bool> UpdateAsync(Consumer item);
    }
}