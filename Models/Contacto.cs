using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototipo_Niconuts.Models
{
    [Table("t_contacto")]
    public class Contacto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id{get;set;}

        [Required]
        [Column("nombre")]
        public string Nombre{get;set;}

        [Required]
        [Column("apellido")]
        public string Apellido{get;set;}

        [Required]
        [Column("email")]
        public string Email{get;set;}

        [Required]
        [Column("telefono")]
        public string Telefono{get;set;}

        [Required]
        [Column("mensaje")]
        public string Mensaje{get;set;}

    }
}