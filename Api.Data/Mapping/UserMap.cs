using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder
                .ToTable("User");

            builder
                .HasKey(t => t.Id);
            
            builder
                .HasIndex(t => t.Email)
                .IsUnique();

            builder
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(60);

            builder
                .Property(t => t.Email)
                .HasMaxLength(100);
        }
    }
}