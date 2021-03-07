using ProjectManager.Core.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Infrastructure.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public IUserRepository Users { get; private set; }
        public IRoleRepository Roles { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Users = new UserRepository(db);
            Roles = new RoleRepository(db);
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public void SaveChangesAsync()
        {
            _db.SaveChangesAsync();
        }
    }
}
