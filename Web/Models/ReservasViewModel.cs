using Data.Entity;

namespace Web.Models
{
    public class ReservasViewModel
    {
        public List<EntityReservas>? ListReservas { get; set; }
        public List<string>? ListaTipoVehiculos { get; set; }
        public List<EntityCliente>? ListCliente { get; set; }
        public List<EntityVehiculos>? ListaVehiculos { get; set; }
        public int ClienteId { get; set; }

        public int VehiculosId { get; set; }

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin {  get; set; }

    }
}
