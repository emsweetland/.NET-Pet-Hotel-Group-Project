using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using pet_hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace pet_hotel.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public PetsController(ApplicationContext context) {
            _context = context;
        }

        // This is just a stub for GET / to prevent any weird frontend errors that 
        // occur when the route is missing in this controller
        [HttpGet]
        public IEnumerable<Pet> GetPets() {
            return _context.Pets.Include(PetOwner => PetOwner.petOwner);
        }


        [HttpPost]
        public IActionResult Post(Pet taco) {
            _context.Add(taco);
            _context.SaveChanges();

            return CreatedAtAction(nameof(Post), new {id = taco.id}, taco);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Pet pet = _context.Pets.SingleOrDefault(b => b.id == id);
            if (pet is null) {
                return NotFound();
            }
            _context.Pets.Remove(pet);
            _context.SaveChanges();

            return NoContent();
        }



        [HttpPut("{id}")]
        public IActionResult Put(int id, Pet pet)
        {
            Console.WriteLine("updating Pets");
            if (id != pet.id)
            {
                return BadRequest();
            }
            _context.Update(pet);
            _context.SaveChanges();
            
            return NoContent();

        }

      

        // [HttpGet]
        // [Route("test")]
        // public IEnumerable<Pet> GetPets() {
        //     PetOwner blaine = new PetOwner{
        //         name = "Blaine"
        //     };

        //     Pet newPet1 = new Pet {
        //         name = "Big Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Black,
        //         breed = PetBreedType.Poodle,
        //     };

        //     Pet newPet2 = new Pet {
        //         name = "Little Dog",
        //         petOwner = blaine,
        //         color = PetColorType.Golden,
        //         breed = PetBreedType.Labrador,
        //     };

        //     return new List<Pet>{ newPet1, newPet2};
        // }
    }
}
