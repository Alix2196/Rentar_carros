using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    [Table("solicitudes")]
    public class EntitySolicitudes
    {
        [Key]
        [Column("id_solicitud")]
        public int Id { get; set; }

        [Column("estado")]
        public string? Estado { get; set; }

        [Column("fecha_creacion")]
        public DateTime Fecha_Creacion { get; set; }

        [Column("fecha_actualizacion")]
        public DateTime Fecha_Actualizacion { get; set; }

        [Column("descripcion")]
        public string? Descripcion { get; set; }
    }
}
