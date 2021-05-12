using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Prototipo_Niconuts.Models;

namespace Prototipo_Niconuts.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Contacto> DataContacto {get;set;}
        public DbSet<Cliente> DataCliente {get;set;}
        public DbSet<PrePedido> DataPrePedido {get;set;}
        public DbSet<Producto> DataProducto {get;set;}
       
    }
}
