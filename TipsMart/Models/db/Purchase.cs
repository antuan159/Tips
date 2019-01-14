using System;
using System.ComponentModel.DataAnnotations;

namespace TipsMart.Models.db
{
    public class Purchase
    {
        [Key]
        public Guid UserId { get; set; }
        public Guid ShopId { get; set; }
        public decimal PurchaseAmount { get; set; }
    }
}
