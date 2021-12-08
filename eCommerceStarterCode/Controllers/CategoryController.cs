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
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get()
        {
            var category = _context.Categories;
            return Ok(category);
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var category = _context.Categories.FirstOrDefault(category => category.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] Category value)
        {
            _context.Categories.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);

        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category value)
        {
            var category = _context.Categories.FirstOrDefault(category => category.CategoryId == id);
            category.CategoryName = value.CategoryName;
            _context.SaveChanges();
            return Ok(category);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(category => category.CategoryId == id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok();
        }
    }
}
