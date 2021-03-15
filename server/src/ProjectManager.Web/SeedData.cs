using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ProjectManager.Core.Entity;
using ProjectManager.Core.Interface;
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
        private readonly ILoggerAdapter<SeedData> _logger;
        public SeedData(ApplicationDbContext db, ILoggerAdapter<SeedData> logger)
        {
            _db = db;
            _logger = logger;
        }

        public void DataSeed()
        {
            if (_db.Database.CanConnect())
            {
                //PopulateDatabase
            }
        }

    }
}
