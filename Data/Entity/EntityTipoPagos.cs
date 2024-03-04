using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entity
{
    [Table("tipo_pagos")]
    public class EntityTipoPagos
    {
        [Key]
        [Column("id_pago")]
        public int Id { get; set; }

        [Column("tipo")]
        public string? Tipo { get; set; }
    }
}
