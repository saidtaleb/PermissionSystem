using PermissionSystem.Business.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PermissionSystem.Business.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected AppInoContext AppInoContext { get; set; }

        public RepositoryBase(AppInoContext repositoryContext)
        {
            AppInoContext = repositoryContext;
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await AppInoContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await AppInoContext.Set<T>().Where(expression).ToListAsync();
        }

        public void Create(T entity)
        {
            AppInoContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            AppInoContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            AppInoContext.Set<T>().Remove(entity);
        }

        public async Task SaveAsync()
        {
            await AppInoContext.SaveChangesAsync();
        }
    }
}
