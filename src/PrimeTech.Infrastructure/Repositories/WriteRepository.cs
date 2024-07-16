using Microsoft.EntityFrameworkCore;
using PrimeTech.Interview.Business.Domain.Interfaces.Repositories;
using PrimeTech.Interview.Business.Infrastructure.Data;
using PrimeTech.Interview.Business.SharedKernel;
using System;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Infrastructure.Repositories;
public class WriteRepository<T> : IWriteRepository<T> where T : EntityBase
{
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public WriteRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
        {
            throw new ArgumentException($"Entity not found with the ID");
        }
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
