using Data;
using Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.services
{
    internal class ClienteService
    {

        private readonly AppConection _context;

        public ClienteService(AppConection context)
        {
            _context = context;
        }

        public EntityCliente GuardarCliente(EntityCliente entityCliente)
        {

            return new EntityCliente();

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
            return [];
        }
    }
}
