using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class ClassRepository:GenericRepository<Class>, IClassRepository
    {
        protected readonly ApiEscuelaContext _context;
        public ClassRepository(ApiEscuelaContext context) : base(context)
        {
            _context = context;
        }
    public override async Task<IEnumerable<Class>> GetAllAsync()
    {
        return await _context.Classes.
        ToListAsync();
    }
    }
}