using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> _userManager;

        public AdministradorController(ILogger<AdministradorController> logger,
            ApplicationDbContext context,UserManager<IdentityUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Administrador()    //https://localhost:5001/Administrador/Administrador
        {
            var listcontactos = _context.DataContacto.OrderBy(x => x.id).ToList();
            ViewData["Message"] = "";
            return View(listcontactos);
        }

        public ActionResult AdministrarUsuarios()    //https://localhost:5001/Administrador/Administrador
        {
            var listusuario = _userManager.GetUserName(User);
            return View(listusuario);
        }

        public IActionResult AdministrarReclamos()    
        {
            var listcontactos = _context.DataReclamos.OrderBy(x => x.id).ToList();
            
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

        

        public IActionResult DetalleProducto(int id){
            var producto = _context.DataProducto.Find(id);
            return View(producto);
        }
   
        public IActionResult Delete(int id) 
        {
            var Producto= _context.DataProducto.Find(id);
            _context.Remove(Producto);
            _context.SaveChanges();
            return RedirectToAction("AdministrarProducto");
        }

        
        public IActionResult BorrarContacto(int id){
            var contacto= _context.DataContacto.Find(id);
            _context.Remove(contacto);
            _context.SaveChanges();

            return RedirectToAction("Administrador");
        }

        public IActionResult BorrarReclamo(int id){
            var reclamo= _context.DataReclamos.Find(id);
            _context.Remove(reclamo);
            _context.SaveChanges();

            return RedirectToAction("AdministradorReclamos");
        }

    }
}