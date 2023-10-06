using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interfaces;
using Persistence;

namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiEscuelaContext context;
    private ClassRepository _classes;
    private GradeRepository _grades;
    private RoleRepository _roles;
    private StudentRepository _students;
    private SubjectRepository _subjects;
    private TeacherRepository _teachers;
    private UserRepository _users;
    public UnitOfWork (ApiEscuelaContext _context)
    {
        context = _context;
    }

    public IClassRepository Classes
    {
        get
        {
            if(_classes == null)
            {
                _classes = new ClassRepository(context);
            }
            return _classes;
        }
    }
    public IGradeRepository Grades
    {
        get
        {
            if(_grades == null)
            {
                _grades = new GradeRepository(context);
            }
            return _grades;
        }
    }
    public IRoleRepository Roles
    {
        get
        {
            if(_roles == null)
            {
                _roles = new RoleRepository(context);
            }
            return _roles;
        }
    }
    public IStudentRepository Students
    {
        get
        {
            if(_students == null)
            {
                _students = new StudentRepository(context);
            }
            return _students;
        }
    }
    public ISubjectRepository Subjects
    {
        get
        {
            if(_subjects == null)
            {
                _subjects = new SubjectRepository(context);
            }
            return _subjects;
        }
    }
    public ITeacherRepository Teachers
    {
        get
        {
            if(_teachers == null)
            {
                _teachers = new TeacherRepository(context);
            }
            return _teachers;
        }
    }
    public IUserRepository Users
    {
        get
        {
            if(_users == null)
            {
                _users = new UserRepository(context);
            }
            return _users;
        }
    }
    public int Save ()
    {
        return context.SaveChanges();
    }
    public void Dispose ()
    {
        context.Dispose();
    }
    public async Task<int> SaveAsync ()
    {
        return await context.SaveChangesAsync ();
    }
}
