using Domain.Entities;
using Domain.Interfaces;
using Persistence;

namespace Application.Repository;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    public RoleRepository(ApiEscuelaContext context) : base(context)
    {}
}