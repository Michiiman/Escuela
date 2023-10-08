
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class GradeRepository:GenericRepository<Grade> , IGrade
    {
        protected readonly ApiEscuelaContext context;
        public GradeRepository(ApiEscuelaContext context) : base(context)
        {
            this.context = context;
        }
    }
}