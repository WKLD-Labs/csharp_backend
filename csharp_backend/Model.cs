using csharp_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace csharp_backend
{
    public class LabsContext : DbContext
    {
        // Define models here
        public DbSet<Dummy> Dummies { get; set; }

        public string DbPath { get; }

        public LabsContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            path = System.IO.Path.Join(path, ".labsBackend");
            System.IO.Directory.CreateDirectory(path);
            DbPath = System.IO.Path.Join(path, "labsData.db");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
