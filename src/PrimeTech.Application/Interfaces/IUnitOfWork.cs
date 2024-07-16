using System;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<int> CompleteAsync();
}
