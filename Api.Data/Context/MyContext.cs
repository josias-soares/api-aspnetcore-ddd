using System;
using Api.Domain.Entities;
using Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class MyContext : DbContext
    {
        public DbSet<UserEntity> MyProperty { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
//            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = "Administrador",
                    Email = "adm@email.com",
                    CreateAt = DateTime.Now,
                    UpdateAt = DateTime.Now
                }
            );
        }
    }
}