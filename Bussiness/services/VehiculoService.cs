using Data;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.services
{
    public class VehiculoService
    {

        private readonly AppConection _context;

        public VehiculoService(AppConection context)
        {
            _context = context;
        }

        public string MensajePrueba()
        {
            string respuesta = "Este es el comienzo";
            return respuesta;
        }

        public List<EntityVehiculos> ObtenerVehiculos()
        {
            var listaVehiculos = _context.EntityVehiculos.ToList();
            return listaVehiculos;
        }

        public List<string> GetTiposVehiculos()
        {
            return [.. _context.EntityVehiculos.Select(v => v.Tipo).Distinct()];
        }

    }
}
