using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prototipo_Niconuts.Data;

namespace Prototipo_Niconuts.Controllers
{
    public class ProductoController : Controller
    {

        private readonly ILogger<ProductoController> _logger;
        private readonly ApplicationDbContext _context;

        public ProductoController(ILogger<ProductoController> logger,
            ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
       public IActionResult Producto()
        {
             var listProductos=_context.DataProducto.ToList();
            return View(listProductos);
        }

        /*public IActionResult MayorPrecio(decimal precio)
        {
            var listPrecio = _context.DataProducto.OrderBy(x => x.Precio).ToList();
            return View(listPrecio);
        }*/
    }
}