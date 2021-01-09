using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using KidsShop.Models;

namespace KidsShop.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CartController : Controller
    {
       
        Cart Cart = new Cart();

        [HttpPost]
        [Route("cart/add/{item}")]
        public void add([FromRoute] string item)
        {
            string sessionId = Request.Headers["sessionId"];
            if (sessionId == null)
            {
                Guid id = Cart.generateCart();
                Response.Headers.Add("sessionId", id.ToString());
                Cart.addItem(id, item);
            }
            else
            {
                Cart.addItem(Guid.Parse(sessionId), item);
            }
        }

        [HttpDelete]
        [Route("cart/remove/{item}")]
        public void remove([FromRoute] string item)
        {
            string sessionId = Request.Headers["sessionId"];
            Cart.removeItem(Guid.Parse(sessionId), item);
        }

        [HttpDelete]
        [Route("cart/decrease/{item}")]
        public void decrease([FromRoute] string item)
        {
            string sessionId = Request.Headers["sessionId"];
            Cart.updateItem(Guid.Parse(sessionId), item);
        }

        [HttpGet]
        public CartModel getCartInfo()
        {
            string sessionId = Request.Headers["sessionId"];
            if (sessionId == null)
            {
                return null;
            }
            else
            {
                return Cart.getList(Guid.Parse(sessionId));
            }
        }

    }
}
