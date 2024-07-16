using PrimeTech.Interview.Business.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Domain.Interfaces.Repositories;

public interface IReadRepository<T> where T : EntityBase
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
}
