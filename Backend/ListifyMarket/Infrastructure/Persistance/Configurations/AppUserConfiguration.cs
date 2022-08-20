using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        //Configuración de atributos de entidad
        builder.OwnsOne(i => i.Address, n =>
        {
            n.Property(a => a.Province).HasMaxLength(50);
            //.HasColumnName("Province")
            //.HasDefaultValue("");
            n.Property(a => a.City).HasMaxLength(50);
            n.Property(p => p.Street).HasMaxLength(50);
            n.Property(p => p.ZipCode).HasMaxLength(50);
        });
    }
}
