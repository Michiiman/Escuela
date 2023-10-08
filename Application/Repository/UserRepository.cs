using Domain.Entities;
using Domain.Interfaces;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository
{
    public class UserRepository: GenericRepository<User>, IUser
    {
        public UserRepository(ApiEscuelaContext context):base(context){}
    }
}