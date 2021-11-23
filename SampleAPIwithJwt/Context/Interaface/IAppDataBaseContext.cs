using Microsoft.EntityFrameworkCore;
using SampleAPIwithJwt.Entities.Figure;
using SampleAPIwithJwt.Entities.User;
using SampleAPIwithJwt.Entities.UserPermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Context.Interaface
{
    public interface IAppDataBaseContext
    {
        public DbSet<UserEntityModel> Users { get; set; }
        public DbSet<UserPermissionEntityModel> Permits { get; set; }
        public DbSet<FigureEntityModel> Figures { get; set; }

        public int SaveChanges();
    }
}
