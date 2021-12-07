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

namespace eCommerceStarterCode.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public ApplicationDbContext _context;
        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        // GET
        public IActionResult Get()
        {
            var reviews = _context.Reviews;
            return Ok(reviews);
        }

        // GET id
        [HttpGet("{id")]
        public ActionResult Get(int id)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.ReviewId == id);
            if (review == null)
            {
                return NotFound();
            }
            return Ok(review);
        }

        // POST
        [HttpPost]
        public IActionResult Post([FromBody] Review value)
        {
            _context.Reviews.Add(value);
            _context.SaveChanges();
            return StatusCode(201, value);
        }

        // PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Review value)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.ReviewId==id);
            review.ReviewText = value.ReviewText;
            review.ReviewRating = value.ReviewRating;
            review.UserId = value.UserId;
            _context.SaveChanges();
            return Ok(review);
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var plant = _context.Reviews.FirstOrDefault(r => r.ReviewId == id);
            _context.Reviews.Remove(plant);
            _context.SaveChanges();
            return Ok();
        }
    }
}
