using System;
using System.Collections.Generic;

namespace TipsMart.Models.db
{
    public partial class Users
    {
        public Guid UserId { get; set; }
        public decimal Balance { get; set; }
        public string Name { get; set; }
    }
}
