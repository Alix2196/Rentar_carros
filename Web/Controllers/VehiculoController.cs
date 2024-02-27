using Bussiness.services;
using Microsoft.AspNetCore.Mvc;
using Web.Models;


namespace Web.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly ILogger<VehiculoController> _logger;
        private readonly VehiculoService _vehiculoService;

        public VehiculoController(ILogger<VehiculoController> logger, VehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
            _logger = logger;
        }

        public IActionResult Index()
        {

            _logger.LogInformation("Inicia vista");

            var viewModel = new VehiculoViewModel
            {
                Mensaje = _vehiculoService.MensajePrueba(),
                ListVehiculos = _vehiculoService.ObtenerVehiculos(),
            };

            return View(viewModel);
        }

        public IActionResult Crear()
        {
            return View();
        }


    }
}


