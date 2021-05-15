using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototipo_Niconuts.Models
{
    [Table("t_producto")]
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id{get;set;}

        [Required(ErrorMessage = "Por favor ingrese Nombre")]
        [Display(Name="Nombre")]
        [Column("nombre")]
        public string Nombre{get;set;}

        [Display(Name="Precio")]
        [Column("precio")]
        public decimal Precio{get;set;}

        [Column("descripcion")]
        public string Descripcion{get;set;}

        [Column("image_name")]
        public string Imagen{get;set;}

    }
}