﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prototipo_Niconuts.Data;
using Prototipo_Niconuts.Models;

namespace Prototipo_Niconuts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Nosotros()
        {
            return View();
        }

        public IActionResult Contactenos()
        {
            return View();
        }

        public IActionResult FormularioContacto(){
            
            return View();
        }
        
        [HttpPost]
        public IActionResult FormularioContacto(Contacto a){
            if(ModelState.IsValid){
                _context.Add(a);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(a);
        }

        

        public IActionResult FormularioReclamaciones(){
            
            return View();
        }

        [HttpPost]
        public IActionResult FormularioReclamaciones(Reclamaciones c){
            if(ModelState.IsValid){
                c.Estado="No Atendido";
                _context.Add(c);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }

        

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
