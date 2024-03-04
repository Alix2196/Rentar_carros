using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    [Table("clientes")]
    public class EntityCliente
    {
        [Key]
        [Column("id_cliente")]
        public int Id { get; set; }

        [Column("documento")]
        public int Documento { get; set; }

        [Column("ciudad")]
        public string? Ciudad { get; set; }

        [Column("nombre")]
        public string? Nombre { get; set; }

        [Column("email")]
        public string? Email { get; set; }

        [Column("telefono")]
        public string? Telefono { get; set; }

        [Column("direccion")]
        public string? Direccion { get; set; }

        [Column("fecha_nacimiento")]
        public DateTime Fecha_Nacimiento { get; set; }

        [Column("fecha_creacion")]
        public DateTime Fecha_Creacion { get; set; }

        [Column("fecha_actualizacion")]
        public DateTime Fecha_Actualizacion { get; set; }
    }
}

