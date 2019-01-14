using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TipsMart.Models
{
    public class PurchaseModel
    {
        public Guid UserId { get; set; }
        public decimal PurchaseAmount { get; set; }
    }
}
