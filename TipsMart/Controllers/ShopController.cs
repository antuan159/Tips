using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TipsMart.Models;
using TipsMart.Models.db;

namespace TipsMart.Controllers
{
    [Route("[controller]")]
    public class ShopController : Controller
    {
        // POST <controller>
        [HttpPost("{shopId}")]
        public async Task<IActionResult> PostAsync([FromBody] PurchaseModel purchaseModel, Guid shopId)
        {
            if(shopId == Guid.Empty)
                return BadRequest($"{nameof(shopId)} is invalid!");

            
            using (var db = new ShopAndUserContext())
            {
                var user = db.Users.Find(purchaseModel.UserId);

                if (user == null)
                    return BadRequest($"user with {purchaseModel.UserId} not found!");

                Purchase purchase = new Purchase();
                purchase.ShopId = shopId;
                purchase.UserId = purchaseModel.UserId;
                purchase.PurchaseAmount = purchaseModel.PurchaseAmount;

                #region MyRegion если нужно дёрнуть api user

                string url = "http://localhost:55692/user/" + purchaseModel.UserId.ToString().ToUpper();
                string data = "PurchaseAmount=" + purchaseModel.PurchaseAmount.ToString();

                UserModel userOne = new UserModel();
                userOne.PurchaseAmount = purchaseModel.PurchaseAmount;

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsJsonAsync(url, userOne);
                    response.EnsureSuccessStatusCode();
                }

                #endregion


                db.Purchase.Add(purchase);
                db.SaveChanges();
                return Ok();
            }
        }
    }
}
