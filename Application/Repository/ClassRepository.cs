using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class ClassRepository:GenericRepository<Class>, IClassRepository
    {
        public ClassRepository(ApiEscuelaContext context) : base(context)
        {}
    }
}