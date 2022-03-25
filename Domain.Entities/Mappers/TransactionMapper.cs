using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Entities.Mappers
{
    public class TransactionMapper : IEntityTypeConfiguration<TransactionEntity>
    {
        public void Configure(EntityTypeBuilder<TransactionEntity> buider)
        {
            buider.ToTable("Transactions");
            buider.Property(x => x.Amount).HasPrecision(18, 2).IsRequired();
            buider.Property(x => x.IsoCurrencyCode).HasMaxLength(3);
            buider.Property(x => x.TransactionId);
            buider.Property(x => x.AircashTransactionId);
            buider.Property(x => x.DateTimeUTC).HasColumnType("datetime2");
        }
    }
}
