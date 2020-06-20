using LogSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogSystem.Core.CoreDAL
{
    public class CRUD<TEntity> : ICRUD<TEntity> where TEntity : class, new()
    {
        private readonly LogContext _ctx;
        public CRUD(LogContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
                var addedEntry = await _ctx.AddAsync(entity);
                await _ctx.SaveChangesAsync();
                return entity;
        }

        public async Task<List<TEntity>> AddRange(List<TEntity> entity)
        {
                await _ctx.AddRangeAsync(entity);
                await _ctx.SaveChangesAsync();
                return entity;
        }

        public async Task<int> Delete(TEntity entity)
        {
                var addedEntry = _ctx.Remove(entity);
                return await _ctx.SaveChangesAsync();
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
                return await _ctx.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public async Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
                return await (filter == null ? _ctx.Set<TEntity>().ToListAsync() : _ctx.Set<TEntity>().Where(filter).ToListAsync());
        }

        public async Task<TEntity> Update(TEntity entity)
        {
                var addedEntry = _ctx.Update(entity);
                _ctx.Entry(entity).Property("CreatedDate").IsModified = false;
                await _ctx.SaveChangesAsync();
                return entity;
        }

        public async Task<List<TEntity>> UpdateRange(List<TEntity> entity)
        {
                _ctx.UpdateRange(entity);
                await _ctx.SaveChangesAsync();
                return entity;
        }
    }
}
