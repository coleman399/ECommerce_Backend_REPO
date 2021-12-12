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
    [Route("api/plant")]
    [ApiController]
    public class PlantController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PlantController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/<Plant>
        [HttpGet]
        public IActionResult Get()
        {
            var plants = _context.Plants.Include(u => u.User);
            return Ok(plants);
        }

        // GET api/<Plant>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var plant = _context.Plants.Where(p => p.PlantId == id).Include(u => u.User);
            if (plant == null)
            {
                return NotFound();
            }
            return Ok(plant);
        }

        // POST api/<Plant>
        [HttpPost]
        public IActionResult Post([FromBody] Plant value)
        {
            _context.Plants.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);

        }

        // PUT api/<Plant>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Plant value)
        {
            _context.Plants.Update(value);
            _context.SaveChanges();
            return Ok(value);
        }

        // DELETE api/<Plant>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var plant = _context.Plants.Where(p => p.PlantId == id).SingleOrDefault();
            _context.SaveChanges();
            return StatusCode(200, plant);
        }
    }
}