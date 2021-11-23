using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Context.Implenetation
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDataBaseContext>
    {

        AppDataBaseContext IDesignTimeDbContextFactory<AppDataBaseContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDataBaseContext>();
            string dbFileName = "database.db";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            var _db = Path.Combine(path, dbFileName);

            optionsBuilder.UseSqlite($"Data source = {_db}");

            return new AppDataBaseContext(optionsBuilder.Options);
        }
    }
}
