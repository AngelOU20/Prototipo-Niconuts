using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prototipo_Niconuts.Data;

namespace Prototipo_Niconuts.Controllers
{
    public class AdministradorController : Controller
    {
        private readonly ILogger<AdministradorController> _logger;
        private readonly ApplicationDbContext _context;

        public AdministradorController(ILogger<AdministradorController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Administrador()    //https://localhost:5001/Administrador/Administrador
        {
            var listcontactos = _context.DataContacto.OrderBy(x => x.id).ToList();
            ViewData["Message"] = "";
            return View(listcontactos);
        }
    }
}