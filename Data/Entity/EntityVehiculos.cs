using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    [Table("vehiculos")]
    public class EntityVehiculos
    {
        [Key]
        [Column("id_vehiculo")]
        public int Id{ get; set; }

        [Column("marca")]
        public string? Marca { get; set;  }

        [Column("placa")]
        public string? Placa { get; set; }

        [Column("color")]
        public string? Color { get; set; }

        [Column("cilindraje")]
        public string? Cilindraje { get; set;}

        [Column("modelo")]
        public string? Modelo { get; set; }

        [Column("precio")]
        public int Precio { get; set;}

        [Column("tipo")]
        public string? Tipo { get; set; }
    }
}
