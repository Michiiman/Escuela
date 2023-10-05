using System.Security.Cryptography;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Aquí puedes configurar las propiedades de la entidad Marca
            // utilizando el objeto 'builder'.
            builder.ToTable("User");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id);

            builder.Property(p => p.Email)
            .HasMaxLength(50);

            builder.HasOne(p => p.Student)
            .WithOne(p => p.User)
            .HasForeignKey<User>(p => p.StudentIdFk);

            builder.HasOne(p => p.Teacher)
            .WithOne(p => p.User)
            .HasForeignKey<User>(p => p.TeacherIdFk);

            builder.Property(p => p.Password)
            .HasMaxLength(255)
            .IsRequired()
            .HasConversion(
                s => SHA256.HashData(Encoding.UTF8.GetBytes(s)),
                s => Encoding.UTF8.GetString(SHA256.HashData(s)));

            builder
            .HasMany(p=>p.Roles)
            .WithMany(p=>p.Users)
            .UsingEntity<UserRole>(
            j=>j
                .HasOne(pt=>pt.Role)
                .WithMany(t=>t.UserRoles)
                .HasForeignKey(pt=>pt.RoleIdFk),
            j => j
                .HasOne(pt => pt.User)
                .WithMany(t => t.UserRoles)
                .HasForeignKey(pt => pt.UserIdFk),
            j => 
            {
                j.ToTable("userRol");
                j.HasKey(t => new { t.UserIdFk, t.RoleIdFk});
            });


        }
    }
}