
using Bussiness.services;
using Data.Entity;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class ClienteController : Controller
    {

        private readonly ILogger<ClienteController> _logger;
        private readonly ClienteService _clienteService;

        public ClienteController(ILogger<ClienteController> logger, ClienteService clienteService)
        {
            _clienteService = clienteService;
            _logger = logger;

        }

        public IActionResult Index()
        {
            _logger.LogInformation("inicia vista clientes");
            var vieModel = new ClienteViewModel
            {
                ListCliente = _clienteService.ObtenerClientes(),
            };
            return View(vieModel);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Crear(EntityCliente entityCliente)
        {
            if (ModelState.IsValid)
            {
                _clienteService.GuardarCliente(entityCliente);
                return RedirectToAction("Index");
            }
            return View(entityCliente);
        }


    }
}
