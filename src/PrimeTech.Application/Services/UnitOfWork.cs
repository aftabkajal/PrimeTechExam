using PrimeTech.Interview.Business.Application.Interfaces;
using PrimeTech.Interview.Business.Infrastructure.Data;
using System;
using System.Threading.Tasks;

namespace PrimeTech.Interview.Business.Application.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(
            ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
