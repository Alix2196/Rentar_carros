using Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class AppConection : DbContext
    {
        static readonly string connectionString = "Server=192.168.0.100; User ID=root; Password=root; Database=renta_automoviles";

        public required DbSet<EntityVehiculos> EntityVehiculos { get; set; }
        public required DbSet<EntityCliente> EntityCliente { get; set; }
        public required DbSet<EntityEstadoReserva> EntityEstadoReservas { get; set; }
        public required DbSet<EntityReservas> EntityReservas { get; set; }
        public required DbSet<EntitySolicitudes> EntitySolicitudes { get; set; }
        public required DbSet<EntityTipoPagos> EntityTipoPago { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }
    }
}
