using Data.Entity;

namespace Web.Models
{
    public class ReservasViewModel
    {
        public required List<EntityReservas> ListReservas { get; set; }
        public required List<string> ListaTipoVehiculos { get; set; }
    }
}
