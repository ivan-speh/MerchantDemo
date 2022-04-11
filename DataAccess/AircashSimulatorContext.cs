using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AircashSimulatorContext : DbContext
    {
        public AircashSimulatorContext(DbContextOptions<AircashSimulatorContext> options) : base(options)
        {

        }

        public DbSet<TransactionEntity> Transactions { get; set; }
        public DbSet<SettingsEntity> Settings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AircashSimulatorContext).Assembly);
        }

    }
}
