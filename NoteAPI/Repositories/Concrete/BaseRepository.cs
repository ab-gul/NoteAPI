using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NoteAPI.Data;
using NoteAPI.Domain;
using NoteAPI.Repositories.Abstract;
using System.Reflection.Metadata.Ecma335;

namespace NoteAPI.Repositories.Concrete
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        protected readonly AppDBContext _dbContext;
        protected readonly DbSet<T> _entities;
        public BaseRepository(AppDBContext context)
        {
             _dbContext = context;
            _entities = context.Set<T>();
        }
        public async Task<T> AddAsync(T entity)
        {
           _entities.Add(entity);
           await _dbContext.SaveChangesAsync();
           return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _entities.Where(e => e.Id == id).ExecuteDeleteAsync();
               
        }

        public async Task<List<T>> GetAllAsync()
        {
           return await _entities.ToListAsync() ?? new List<T>();
        }

        public async Task<T?> GetByIdAsync(Guid id)
        {
           return await _entities.FirstOrDefaultAsync(e => e.Id == id);
        }

        //public async Task SaveAsync()
        //{
        //  await _dbContext.SaveChangesAsync();
        //}

        public async Task UpdateAsync(T entity)
        {
            _entities.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
