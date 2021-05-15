using System;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prototipo_Niconuts.Data;
using Prototipo_Niconuts.Models;

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

        [HttpPost]
        public IActionResult Producto(string ordenar, string filtro)
        {
            var listProd= _context.DataProducto.OrderBy(s => s.id).ToList();
            
            if(ordenar == "MayorPrecio"){
                listProd=_context.DataProducto.Where(c => c.Nombre.ToUpper().Contains(filtro.ToUpper())).OrderByDescending(s=>s.Precio) .ToList();
            }else if(ordenar == "MenorPrecio"){
                Console.WriteLine("MenorPrecio"+ ordenar);
                listProd=_context.DataProducto.Where(c => c.Nombre.ToUpper().Contains(filtro.ToUpper())).OrderBy(s=>s.Precio) .ToList();
            }else{
                listProd=_context.DataProducto.Where(c => c.Nombre.ToUpper().Contains(filtro.ToUpper())).OrderBy(s=>s.id) .ToList();
            }
            return View(listProd);
        }

        public IActionResult DescripcionProducto(int id){
            var producto = _context.DataProducto.Find(id);
            return View(producto);
        }

        [Authorize]
        public IActionResult Carrito()
        {
            var Ordenes=_context.DataPrePedido.Where(x => x.Usuario != null).ToList();
            return View(Ordenes);
        }

    }
}