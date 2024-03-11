using Bussiness.services;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ReservasController  : Controller
    {

        private readonly ILogger<ReservasController> _logger;
        private readonly ReservasService _reservasService;
        private readonly VehiculoService _vehiculoService;
        private readonly ClienteService _clienteService;
        
        public ReservasController(ILogger<ReservasController> logger, ReservasService reservasService, VehiculoService vehiculoService, ClienteService clienteService )
        {
            _clienteService = clienteService;
            _vehiculoService = vehiculoService;
            _reservasService = reservasService;
            _logger = logger;
        }

        public IActionResult Index() 
        {
            _logger.LogInformation("Inicia vista de Reservas");
            

            var viewModel = new ReservasViewModel
            {
                ListReservas = _reservasService.ObtenerReservas()
            };
            return View(viewModel);
        }

       
        public IActionResult Crear()
        {
            var viModel = new ReservasViewModel
            {
                ListCliente = _clienteService.ObtenerClientes(),
                ListReservas = _reservasService.ObtenerReservas(),
                ListaTipoVehiculos = _vehiculoService.GetTiposVehiculos(),
                ListaVehiculos = _vehiculoService.ObtenerVehiculos()
            };
            return View(viModel);
        }

        [HttpPost]
        public IActionResult CrearReserva(ReservasViewModel viewModel)
        {
            var reserva = new EntityReservas();

            var cliente = _clienteService.GetClienteId(viewModel.ClienteId);
            var vehiculo = _vehiculoService.GetVehiculoId(viewModel.VehiculosId);

            if (ModelState.IsValid){

                reserva.Cliente = cliente;
                reserva.Vehiculo = vehiculo;
                reserva.FechaInicio = viewModel.FechaInicio;
                reserva.FechaFin = viewModel.FechaFin;

                _reservasService.GuardarReservas(reserva);
                return RedirectToAction("Index");
            }
            return View(reserva);

        }

        public IActionResult Pago(EntityReservas entityReservas) 
        {
            return View(entityReservas);
        }
    }
}
