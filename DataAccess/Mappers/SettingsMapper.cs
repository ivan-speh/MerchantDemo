using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;

namespace DataAccess.Mappers
{
    class SettingsMapper : IEntityTypeConfiguration<SettingsEntity>
    {
        public void Configure(EntityTypeBuilder<SettingsEntity> builder)
        {
            builder.ToTable("Settings");
            builder.Property(x => x.Key);
            builder.Property(x => x.Value);
        }
    }
}
