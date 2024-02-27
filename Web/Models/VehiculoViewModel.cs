using Data.Entity;

namespace Web.Models
{
    public class VehiculoViewModel
    {
        public string? Mensaje { get; set; }
        public required List<EntityVehiculos> ListVehiculos { get; set; }
    }
}
