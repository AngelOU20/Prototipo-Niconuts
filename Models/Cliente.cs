using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototipo_Niconuts.Models
{
    [Table("t_cliente")]
    public class Cliente
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id{get;set;}

        [Required(ErrorMessage = "Por favor ingrese Nombre")]
        [Display(Name="nombre")]
        public string Nombre{get;set;}
        public string Apellido{get;set;}
        public string Email{get;set;}
        public string Contraseña{get;set;}
        public string Telefono{get;set;}

    }
}