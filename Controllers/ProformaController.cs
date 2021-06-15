using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Prototipo_Niconuts.Data;
using Prototipo_Niconuts.Models;
using Microsoft.AspNetCore.Identity;

namespace Prototipo_Niconuts.Controllers
{
    public class ProformaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ProformaController(ApplicationDbContext context,
        UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Proforma
        public async Task<IActionResult> Proforma()
        {
            var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataProforma select o;
            items = items.
                Include(p => p.Producto).
                Where(s => s.UserID.Equals(userID));
            
            return View(await items.ToListAsync());
        }

        public IActionResult DeletePC(int id) 
        {
            var Producto= _context.DataProforma.Find(id);
            _context.Remove(Producto);
            _context.SaveChanges();
            return RedirectToAction("Proforma");
        }

        public IActionResult EditarProforma(int id){
            var proforma = _context.DataProforma.Find(id);
            return View(proforma);
        }


        [HttpPost]
        public IActionResult EditarProforma(Proforma p){
            if(ModelState.IsValid){
                var proforma = _context.DataProforma.Find(p.Id);
                proforma.Cantidad = p.Cantidad;
                proforma.SubTotal = p.Cantidad * proforma.Precio;
                _context.SaveChanges();
                return RedirectToAction("Proforma");
            }
            return View(p);
        }

        public async Task<IActionResult> ResumenCompra(){
            var userID = _userManager.GetUserName(User);
            var items = from o in _context.DataProforma select o;
            items = items.
                Include(p => p.Producto).
                Where(s => s.UserID.Equals(userID));
            
            return View(await items.ToListAsync());
        }

        public IActionResult Comprar(){
            return RedirectToAction("Index","Home");
        }
        
        public IActionResult MetodoDePago(){
            return View();
        }

        public IActionResult PagoContraEntrega(){
            return View();
        }
        public IActionResult PagoTarjeta(){
            return View();
        }

        public IActionResult PagoTransferencia(){
            return View();
        }

        public IActionResult PagoEnTienda(){
            return View();
        }
        
    }
}