using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public ProductoController(ILogger<ProductoController> logger,
            ApplicationDbContext context ,  UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;

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

        public async Task<IActionResult> Add(int? id)
        {
            var userID = _userManager.GetUserName(User);
            if(userID == null){ 
                ViewData["Message"] = "Por favor debe loguearse antes de agregar un producto";
                List<Producto> productos = new List<Producto>();
                return  View("Producto",productos);
            }else{
                var producto = await _context.DataProducto.FindAsync(id);
                Proforma proforma = new Proforma();
                proforma.Producto = producto;
                proforma.Cantidad = 1;
                proforma.Precio = proforma.Cantidad * producto.Precio;
                proforma.UserID = userID;
                _context.Add(proforma);
                await _context.SaveChangesAsync();
                return  RedirectToAction(nameof(producto));
            }
        }

        

    }
}