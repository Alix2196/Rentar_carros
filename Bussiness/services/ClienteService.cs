using Data;
using Data.Entity;
using System.Linq;

namespace Bussiness.services
{
    public class ClienteService(AppConection context)
    {

        private readonly AppConection _context = context;

        public EntityCliente GetClienteId(int id)
        {
            return _context.EntityCliente.Find(id);
        }

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
            /*Consutar los clinetes que tiene reservas en la reserva tomar el vehiculo y obtener el tipo de vehiculo*/
            var cliente = _context.EntityCliente.Find(documento);
            var reserva = _context.EntityReservas.FirstOrDefault(reserva => reserva.Cliente.Id == cliente.Id);
            var vehiculo_placa = reserva.Vehiculo.Placa;
            var vehiculo = _context.EntityVehiculos.FirstOrDefault(vehiculo => vehiculo.Placa == vehiculo_placa);

            return vehiculo.Tipo;
        }

        public int NumeroClienteMayorValorMil()
        {
            /* Consultar Reservas valores pagos mayores de 1000 retornar la cantidad*/
            var cantidadpago = _context.EntityReservas.Where(reserva => reserva.ValorPago >= 1000).Select(reserva => reserva.Cliente.Id).Distinct().Count();
            return cantidadpago;
        }

        public List<EntityCliente> GetListaClientesMayoresCuarentaBogotaReserva()
        {
            var fechaLimite = DateTime.Today.AddYears(-40);
            var clientes = _context.EntityCliente
                .Where(cliente => cliente.Fecha_Nacimiento <= fechaLimite && cliente.Ciudad == "Bogota")
                .ToList();
            var clientesConReserva = clientes.Where(cliente => ClienteTieneReserva(cliente.Id)).ToList();
            return clientesConReserva;
        }

        private bool ClienteTieneReserva(int clienteId)
        {
            var reserva = _context.EntityReservas.FirstOrDefault(reserva => reserva.Cliente.Id == clienteId);
            return reserva != null;
        }

    }
}
