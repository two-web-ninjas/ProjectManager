using Microsoft.EntityFrameworkCore;
using ProjectManager.Core.Entity;
using ProjectManager.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Infrastructure.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
