using Microsoft.AspNetCore.Mvc;

namespace Prototipo_Niconuts.Controllers
{
    public class ProductoController : Controller
    {
       public IActionResult Producto()
        {
            return View();
        }
    }
}