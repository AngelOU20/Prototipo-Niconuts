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
            return RedirectToAction("Administrador");
        }

    

        // GET: Producto/Edit/5
        public async Task<IActionResult> EditarProducto(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.DataProducto.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View();
        }

        
         // POST: Producto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,ImagenName,Price")] Producto producto)
        {
            if (id != producto.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Administrador));
            }
            return View(producto);
        }

        private bool ProductoExists(int id)
        {
            return _context.DataProducto.Any(e => e.id == id);
        }



    }
}