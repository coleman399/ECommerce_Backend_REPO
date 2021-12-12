using eCommerceStarterCode.Data;
using eCommerceStarterCode.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [HttpGet]
        public IActionResult Get()
        {
            var shoppingCarts = _context.ShoppingCarts.Include(u => u.User).Include(sc => sc.Plant);
            return Ok(shoppingCarts);
        }
        [HttpGet("{type}")]
        public IActionResult Get(string id, [FromBody] ShoppingCart value)
        {
            var user = _context.Users.Where(u => u.Id == value.UserId).FirstOrDefault();
            var shoppingCart = _context.ShoppingCarts.Where(sc => sc.UserId == user.Id).Include(u => u.User).Include(p => p.Plant);
            return Ok(shoppingCart);
        }

        // POST api/shoppingcart
        [HttpPost]
        public IActionResult Post([FromBody] ShoppingCart value)
        {
            _context.ShoppingCarts.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        //// PATCH api/<ShoppingCartController>/5
        [HttpPut]
        public IActionResult Put([FromBody] ShoppingCart value)
        {
            _context.ShoppingCarts.Update(value);
            _context.SaveChanges();
            return Ok(value);
        }

        //// DELETE api/<ShoppingCartController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var shoppingCartItem = _context.ShoppingCarts.Where(sc => sc.ShoppingCartId == id).Include(u => u.User).Include(p => p.Plant).SingleOrDefault();

            _context.ShoppingCarts.Remove(shoppingCartItem);
            _context.SaveChanges();
            return StatusCode(200, shoppingCartItem);
        }
    }
}