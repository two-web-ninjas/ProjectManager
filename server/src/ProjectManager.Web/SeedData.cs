using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ProjectManager.Core.Entity;
using ProjectManager.Infrastructure;
using ProjectManager.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Web
{
    public class SeedData
    {
        private readonly ApplicationDbContext _db;
        //private readonly LoggerAdapter<SeedData> _logger;
        public SeedData(ApplicationDbContext db) //LoggerAdapter<SeedData> logger)
        {
            _db = db;
            //_logger = logger;
        }

        public void DataSeed()
        {
            if (_db.Database.CanConnect())
            {
                if (!_db.Roles.Any())
                {
                    InsertDefaultRoles();
                }
            }
        }

        private void InsertDefaultRoles()
        {
            List<Role> roles = new List<Role>
            {
                new Role
                {
                    Id = 0,
                    Name = "user",
                    NormalizedName = "USER"
                },
                new Role
                {
                    Id = 1,
                    Name = "administrator",
                    NormalizedName = "ADMINISTRATOR"
                }
            };
            _db.Roles.AddRange(roles);
            //_logger.LogInformation("The default roles has been added.");
            _db.SaveChanges();
        }
    }
}
