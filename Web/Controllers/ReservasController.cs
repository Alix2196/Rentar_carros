using Bussiness.services;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers
{
    public class ReservasController  : Controller
    {

        private readonly ILogger<ReservasController> _logger;
        private readonly ReservasService _reservasService;
        private readonly VehiculoService _vehiculoService;
        
        public ReservasController(ILogger<ReservasController> logger, ReservasService reservasService, VehiculoService vehiculoService )
        {
            _vehiculoService = vehiculoService;
            _reservasService = reservasService;
            _logger = logger;
        }

        public IActionResult Index() 
        {
            _logger.LogInformation("Inicia vista de Reservas");
            

            var viewModel = new ReservasViewModel
            {
                ListReservas = _reservasService.ObtenerReservas(),
                ListaTipoVehiculos = []
            };
            return View(viewModel);
        }

       
        public IActionResult Crear()
        {
            var viModel = new ReservasViewModel
            {
                ListReservas = _reservasService.ObtenerReservas(),
                ListaTipoVehiculos = _vehiculoService.GetTiposVehiculos()
            };
            return View(viModel);
        }

        [HttpPost]
        public IActionResult Crear(EntityReservas entityReservas)
        {
            if (ModelState.IsValid) 
            {
                _reservasService.GuardarReservas(entityReservas);
                return RedirectToAction("Index");
            }

            return View(entityReservas);
        }

        public IActionResult Pago(EntityReservas entityReservas) 
        {
            return View(entityReservas);
        }
    }
}
