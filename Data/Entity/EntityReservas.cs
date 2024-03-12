using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("reservas")]
    public class EntityReservas
    {
        [Key]
        [Column("id_reserva")]
        public int IdReserva { get; set; }

        [ForeignKey("id_solicitudes")]
        public EntitySolicitudes? Solicitud { get; set; }

        [ForeignKey("estado")]
        public EntityEstadoReserva? Estado { get; set; }

        [ForeignKey("id_vehiculo")]
        public EntityVehiculos? Vehiculo { get; set; }

        [ForeignKey("id_cliente")]
        public EntityCliente? Cliente { get; set; }

        [Column("fecha_inicio")]
        public DateTime FechaInicio { get; set; }

        [Column("fecha_fin")]
        public DateTime FechaFin { get; set; }

        [ForeignKey("tipo_pago")]
        public EntityTipoPagos? TipoPago { get; set; }

        [Column("valor_pago")]
        public int? ValorPago { get; set; }

    }
}
