using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;
public class StudentRepository:GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(ApiEscuelaContext context) : base(context){}
}