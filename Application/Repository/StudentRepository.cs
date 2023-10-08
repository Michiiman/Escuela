using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository;
public class StudentRepository:GenericRepository<Student>, IStudent
{
    protected readonly ApiEscuelaContext _context;
    public StudentRepository(ApiEscuelaContext context) : base(context)
    {
        _context = context;
    }
    public override async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students
            .Include(p=>p.Class)
            .Include(p=>p.User)
            .ToListAsync();
    }
        public override async Task<Student> GetByIdAsync(int id)
    {
        return await _context.Students
        .Include(p=>p.Class)
        .Include(p=>p.User)
        .FirstOrDefaultAsync(p => p.Id == id);
    }
}