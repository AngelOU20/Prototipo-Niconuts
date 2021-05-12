using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Prototipo_Niconuts.Data;
using Prototipo_Niconuts.Models;

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
        public IActionResult AdministrarProducto()    //https://localhost:5001/Administrador/Administrador
        {
            var listProducto = _context.DataProducto.OrderBy(x => x.id).ToList();
            ViewData["Message"] = "";
            return View(listProducto);
        }

        public IActionResult CrearProducto(){
            return View();
        }

        [HttpPost]
        public IActionResult CrearProducto(Producto a){
            if(ModelState.IsValid){
                _context.Add(a);
                _context.SaveChanges();
            }
            return RedirectToAction("AdministrarProducto");
        }

        public IActionResult EditarProducto(int id){
            var producto = _context.DataProducto.Find(id);
            return View(producto);
        }


        [HttpPost]
        public IActionResult EditarProducto(Producto r){
            if(ModelState.IsValid){
                var producto = _context.DataProducto.Find(r.id);
                producto.Nombre = r.Nombre;
                producto.Precio = r.Precio;
                producto.Descripcion = r.Descripcion;
                producto.Imagen = r.Imagen;
                _context.SaveChanges();
                return RedirectToAction("AdministrarProducto");
            }
            return View(r);
        }
   
        public IActionResult Delete(int id) 
        {
            var Producto= _context.DataProducto.Find(id);
            _context.Remove(Producto);
            _context.SaveChanges();
            return RedirectToAction("AdministrarProducto");
        }


        private bool ProductoExists(int id)
        {
            return _context.DataProducto.Any(e => e.id == id);
        }



    }
}