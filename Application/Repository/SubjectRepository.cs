using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository
{
    public class SubjectRepository: GenericRepository<Subject>, ISubject
    {
        public SubjectRepository(ApiEscuelaContext context):base(context){}
    }
}