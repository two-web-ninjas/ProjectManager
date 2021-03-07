using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectManager.Core.RepositoryInterface
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IRoleRepository Roles { get; }

        void SaveChanges();
    }
}
