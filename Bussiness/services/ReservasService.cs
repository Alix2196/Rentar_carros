using Data;
using Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.services
{
    public class ReservasService(AppConection context)
    {
        private readonly AppConection _context = context;

        public EntityReservas GuardarReservas(EntityReservas entityReservas)
        {
            Console.WriteLine("debe ser cliente",entityReservas.Cliente);
            /*Crear Solicitud*/
            _context.EntityReservas.Add(entityReservas);
            _context.SaveChanges();
            return entityReservas;
        }

        public List<EntityReservas> ObtenerReservas()
        {
            var listReservas = _context.EntityReservas
                .Include(r => r.Estado)
                .Include(r => r.Cliente)
                .Include(r =>r.TipoPago)
                .Include(r => r.Vehiculo)
                .ToList();

            return listReservas;
        }

         public List<EntityReservas> ListarReservasTarjetaCredito() 
         {
             var listarReservascredito = _context.EntityReservas.ToList();
             return listarReservascredito;
         }
        public EntityReservas GetRealizarReservas()
        {
            return new EntityReservas();
        }
    }
}
