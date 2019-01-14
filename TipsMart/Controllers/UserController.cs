using System;
using Microsoft.AspNetCore.Mvc;
using TipsMart.Models;
using TipsMart.Models.db;

namespace TipsMart.Controllers
{
    [Route("[controller]")]
    public class UserController : Controller
    {
        // POST <controller>
        [HttpPost("{userId}")]
        public IActionResult Post([FromBody] UserModel userModel , Guid userId)
        {
            if (userId == Guid.Empty)
                return BadRequest($"{nameof(userId)} is invalid!");
            
            using (var db = new ShopAndUserContext())
            {
                var user = db.Users.Find(userId);

                if (user == null)
                    return BadRequest($"user with {userId} not found!");

                decimal cashBack = userModel.PurchaseAmount / 100 * 15;
                user.Balance = user.Balance - userModel.PurchaseAmount + cashBack;

                db.SaveChanges();

                return Ok();
            }
        }
    }
}
