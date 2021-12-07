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
        public IActionResult  Get()
        {
            var plants = _context.Plants;
            return Ok(plants);
        }

        // GET api/<Plant>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var plant = _context.Plants.FirstOrDefault(plant => plant.PlantId == id);
            if(plant == null)
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
            var plant = _context.Plants.FirstOrDefault(plant => plant.PlantId == id);
            plant.Name = value.Name;
            plant.Price = value.Price;
            plant.Description = value.Description;
            plant.ReviewId = value.ReviewId;
            plant.CategoryId = value.CategoryId;
            plant.UserId = value.UserId;
            _context.SaveChanges();
            return Ok(plant);
        }

        // DELETE api/<Plant>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var plant = _context.Plants.FirstOrDefault(plant => plant.PlantId == id);
            _context.Plants.Remove(plant);
            _context.SaveChanges();
            return Ok();
        }
    }
}
