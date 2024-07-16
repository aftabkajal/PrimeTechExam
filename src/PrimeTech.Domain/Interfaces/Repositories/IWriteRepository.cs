using PrimeTech.Interview.Business.SharedKernel;
using System;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Domain.Interfaces.Repositories;

public interface IWriteRepository<T> where T : EntityBase
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}
