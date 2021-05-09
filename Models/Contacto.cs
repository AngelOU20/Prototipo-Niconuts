using System.ComponentModel.DataAnnotations.Schema;

namespace Prototipo_Niconuts.Models
{
    [Table("t_contacto")]
    public class Contacto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id{get;set;}

        [Column("nombre")]
        public string Nombre{get;set;}

        [Column("apellido")]
        public string Apellido{get;set;}

        [Column("email")]
        public string Email{get;set;}

        [Column("telefono")]
        public string Telefono{get;set;}

        [Column("mensaje")]
        public string Mensaje{get;set;}

    }
}