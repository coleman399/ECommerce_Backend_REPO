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

namespace eCommerceStarterCode.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public readonly ApplicationDbContext _context;

        public ReviewController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/reviews
        [HttpGet]
        public IActionResult Get()
        {
            var reviews = _context.Reviews.Include(u => u.User).Include(p => p.Plant);
            return Ok(reviews);
        }
        // GET api/reviews/[productID]
        //Gets all Reviews for a Certain ProductID
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var productReviews = _context.Reviews.Where(r => r.ReviewId == id).Include(u => u.User).Include(p => p.Plant);

            return StatusCode(200, productReviews);
        }
        // POST api/reviews
        [HttpPost]
        public IActionResult Post([FromBody] Review review)
        {
            _context.Reviews.Add(review);
            _context.SaveChanges();
            return Ok(review);
        }
        // PUT api/reviews
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Review value)
        {
            var review = _context.Reviews.Where(r => r.ReviewId == id).SingleOrDefault();
            review = new Review()
            {
                ReviewId = id,
                ReviewText = value.ReviewText,
                ReviewRating = value.ReviewRating,
                PlantId = value.PlantId
            };
            _context.SaveChanges();
            return Ok(value);
        }
        // DELETE api/review
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var review = _context.Reviews.Where(r => r.ReviewId == id).SingleOrDefault();
            _context.Reviews.Remove(review);
            _context.SaveChanges();
            return Ok(review);
        }   
    }
}