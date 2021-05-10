using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Prototipo_Niconuts.Models
{
    [Table("t_pre_pedido")]     //Carrito
    public class PrePedido
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id{get;set;}

        public string UserID{get;set;}

        public int ProductID{get;set;}

        public int Cantidad{get;set;}

        public Decimal precio{get;set;}

         
    }
}