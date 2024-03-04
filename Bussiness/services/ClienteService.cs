using Data;
using Data.Entity;
using System.Linq;

namespace Bussiness.services
{
    public class ClienteService(AppConection context)
    {

        private readonly AppConection _context = context;

        public List<EntityCliente> ObtenerClientes()
        {
            return _context.EntityCliente.ToList();
        }

        public EntityCliente GuardarCliente(EntityCliente entityCliente)
        {
            entityCliente.Fecha_Creacion = DateTime.Now;
            entityCliente.Fecha_Actualizacion = DateTime.Now;
            _context.EntityCliente.Add(entityCliente);
            _context.SaveChanges();
            return entityCliente;
        }

        public string GetPreferenciasCliente(int documento)
        {
            return "Logica preferencia cliente por tipo de vehiculo en la reserva";
        }

        public int NumeroClienteMayorValorMil()
        {
            return 0;
        }

        public List<EntityCliente> GetListaClientesMayoresCuarentaBogotaReserva()
        {
            return new List<EntityCliente>();
        }

    }
}
