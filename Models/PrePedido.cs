using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototipo_Niconuts.Models
{
    [Table("t_pre_pedido")]     //Carrito
    public class PrePedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id{get;set;}

        [Display(Name="Correo")]
        [Column("email")]
        public string Email{get;set;}

        [Column("productoid")]
        public int ProductoID{get;set;}


        [Display(Name="Cantidad")]
        [Column("cantidad")]
        public int Cantidad{get;set;}

        [Display(Name="Precio")]
        [Column("precio")]
        public Decimal precio{get;set;}

         
    }
}