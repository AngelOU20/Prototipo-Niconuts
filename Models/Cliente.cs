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
        [Display(Name="Nombre")]
        [Column("nombre")]
        public string Nombre{get;set;}

        [Required(ErrorMessage = "Por favor ingrese Apellido")]
        [Display(Name="Apellido")]
        [Column("apellido")]
        public string Apellido{get;set;}

        [Display(Name="Correo")]
        [Column("email")]
        public string Email{get;set;}

        [DataType(DataType.Password)]
        [Column("contraseña")]
        public string Contraseña{get;set;}

        [DataType(DataType.PhoneNumber)]
        [Display(Name="Telefono")]
        [Column("telefono")]
        public string Telefono{get;set;}

    }
}