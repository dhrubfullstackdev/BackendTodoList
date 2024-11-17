using Microsoft.EntityFrameworkCore;
using BackendTodoList.Model;
using System;

namespace BackendTodoList
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>()
                 .HasOne(t => t.User)
                 .WithMany(u => u.Tasks)
                 .HasForeignKey(t => t.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Tasks>()
                 .HasOne(t => t.Category)
                 .WithMany(c => c.Tasks)
                 .HasForeignKey(t => t.CategoryId)
                 .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Tasks>()
                .Property(t => t.CreatedDate)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Tasks>()
                .Property(t => t.Priority)
                .HasDefaultValue(Priority.Medium);
        }
    }
     

}

