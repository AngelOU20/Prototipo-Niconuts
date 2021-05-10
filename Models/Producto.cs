using System.ComponentModel.DataAnnotations.Schema;

namespace Prototipo_Niconuts.Models
{
    [Table("t_producto")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id{get;set;}

        [Column("nombre")]
        public string Nombre{get;set;}

        [Column("descripcion")]
        public string Descripcion{get;set;}

        public decimal Precio{get;set;}
        public string Imagen{get;set;}

    }
}