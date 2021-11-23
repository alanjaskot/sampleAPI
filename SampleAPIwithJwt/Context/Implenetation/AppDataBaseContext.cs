using Microsoft.EntityFrameworkCore;
using SampleAPIwithJwt.Context.Interaface;
using SampleAPIwithJwt.Entities.Figure;
using SampleAPIwithJwt.Entities.User;
using SampleAPIwithJwt.Entities.UserPermission;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Context.Implenetation
{
    public class AppDataBaseContext : DbContext, IAppDataBaseContext
    {
        public DbSet<UserEntityModel> Users { get; set; }
        public DbSet<UserPermissionEntityModel> Permits { get; set; }
        public DbSet<FigureEntityModel> Figures {get; set; }

        public AppDataBaseContext(DbContextOptions options): base(options) 
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string dbFileName = "database.db";
            string path = AppDomain.CurrentDomain.BaseDirectory;
            var _db = Path.Combine(path, dbFileName);

            options.UseSqlite($"Data source = {_db}");
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<UserEntityModel>(opt =>
            {
                opt.HasKey(u => u.Id);
                opt.HasIndex(u => new { u.Id }).IsUnique(true);
                opt.HasIndex(u => new { u.Id, u.Password }).IsUnique(true);
            });

            model.Entity<UserEntityModel>()
                .HasMany<UserPermissionEntityModel>(u => u.Permits)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            model.Entity<FigureEntityModel>(opt =>
            {
                opt.HasKey(f => f.Id);
                opt.HasIndex(f => f.FigureName);
                opt.Property(f => f.FigureName).IsRequired(true);
                opt.Property(f => f.SideOne).IsRequired(true);
            });

            model.Entity<UserPermissionEntityModel>(opt =>
            {
                opt.Property(p => p.PermitsName).IsRequired();
                opt.Property(p => p.UserId).IsRequired();
            });

            model.Entity<UserEntityModel>()
                .HasData(new UserEntityModel
                {
                    Id = Guid.Parse("c1692909-24ef-4564-862d-94a146bc885b"),
                    Login = "Admin",
                    Password = "123"
                });

            model.Entity<UserEntityModel>()
                .HasData(new UserEntityModel
                {
                    Id = Guid.Parse("158a8ce5-903a-4a56-9a43-2445128b7949"),
                    Login = "User1",
                    Password = "123"
                });

            model.Entity<UserPermissionEntityModel>()
                .HasData(new UserPermissionEntityModel
                {
                    Id = Guid.Parse("bdad0bef-d83e-4dd8-b1fe-37fa8ded02d5"),
                    PermitsName = "Users.Read",
                    UserId = Guid.Parse("c1692909-24ef-4564-862d-94a146bc885b")
                },
                new UserPermissionEntityModel
                {
                    Id = Guid.Parse("6abc8cb9-6928-4052-8c5b-070cf54f80ac"),
                    PermitsName = "Users.Write",
                    UserId = Guid.Parse("c1692909-24ef-4564-862d-94a146bc885b")
                },
                new UserPermissionEntityModel
                {
                    Id = Guid.Parse("d3a5d315-2a04-43b6-afc0-039bf45f0234"),
                    PermitsName = "Users.Update",
                    UserId = Guid.Parse("c1692909-24ef-4564-862d-94a146bc885b")
                },
                new UserPermissionEntityModel
                {
                    Id = Guid.Parse("edcb1e7f-6e9e-4f31-8b26-84f1fc0a2107"),
                    PermitsName = "User.Delete",
                    UserId = Guid.Parse("c1692909-24ef-4564-862d-94a146bc885b")
                });
        }
    }
}
