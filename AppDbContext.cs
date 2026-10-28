using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Data.Sqlite;
using System.IO;
using AvaloniaApplication2;

namespace AvaloniaApplication2
{
    public class AppDbContext : DbContext
    {
        public DbSet<TaskItem> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Путь к файлу БД (будет создан в папке приложения)
            var dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "AvaloniaApplication2",
                "app.db"
            );

            Directory.CreateDirectory(Path.GetDirectoryName(dbPath));

            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskItem>(entity =>
            {
                entity.Property(e => e.Text).IsRequired().HasMaxLength(100);
                entity.Property(e => e.IsCompleted).HasDefaultValue(false);   
            });
        }
    }
}
