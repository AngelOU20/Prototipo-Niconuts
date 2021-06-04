using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototipo_Niconuts.Models
{
    [Table("proforma")]
    public class Proforma
    {
         

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("Id")]
        public int Id {get; set;}

        public String UserID {get; set;}

        public Producto Producto {get; set;}

        public int Cantidad{get; set;}

        public Decimal Precio { get; set; }
    }
}