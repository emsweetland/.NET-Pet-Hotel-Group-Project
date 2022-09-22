using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetOwnersController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetOwnersController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<PetOwner> GetPets() {
            Console.WriteLine("in get pet owners");
            // return new List<PetOwner>();
             return _context.PetOwner;
        }

        // Put for pet owners
        [HttpPut("{id}")]
        public IActionResult Put(int id, PetOwner petOwner) {
            Console.WriteLine("updating pet owner");
            // If ID is not found...
            if (id != petOwner.id) {
                return BadRequest();
            }

            _context.Update(petOwner);
            _context.SaveChanges();
            
            return Ok();
        }
    }
}
