using ProjectManager.Core.Entity;
using ProjectManager.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Infrastructure.Data.Repository
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext db) : base(db)
        {}
    }
}
