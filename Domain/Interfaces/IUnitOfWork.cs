using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces;
public interface IUnitOfWork
{
    IClassRepository Classes { get; }
    IGradeRepository Grades { get; }
    IRoleRepository Roles { get; }
    IStudentRepository Students { get; }
    ISubjectRepository Subjects { get; }
    ITeacherRepository Teachers { get; }
    IUserRepository Users { get; }
}