using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace eCommerceStarterCode.Controllers
{
    [Route("api/shoppingcart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private ApplicationDbContext _context;
        public ShoppingCartController(ApplicationDbContext context)
        {
            _context = context;
        }
        //GETS ALL ITEMS IN USERS CART 
        [HttpGet("{id}"), Authorize]
        public IActionResult Get(int id)
        {

            var shoppingCart = _context.ShoppingCarts.FirstOrDefault(sc => sc.ShoppingCartId == id);
            return Ok(shoppingCart);
        }

        // POST api/shoppingcart
        [HttpPost, Authorize]
        public IActionResult Post([FromBody] ShoppingCart value)
        {
            _context.ShoppingCarts.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        //// PATCH api/<ShoppingCartController>/5
        [HttpPut("{id}"), Authorize]
        public IActionResult Put(int id, [FromBody] ShoppingCart value)
        {

            var itemInCart = _context.ShoppingCarts.Where(sc => sc.ShoppingCartId == id).FirstOrDefault(sc => sc.UserId == value.UserId);

            itemInCart.Quantity = value.Quantity;
            _context.SaveChanges();
            return Ok(itemInCart);
        }

        //// DELETE api/<ShoppingCartController>/5
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            var shoppingCart = _context.ShoppingCarts.FirstOrDefault(sc => sc.ShoppingCartId == id);
            _context.Remove(shoppingCart);
            _context.SaveChanges();
            return Ok();
        }
    }
}