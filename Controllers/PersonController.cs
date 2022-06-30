using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using persons.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace persons.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController: ControllerBase
    {
        private readonly PersonContext _context;

        public PersonController(PersonContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Person> GetAll()
        {
            return _context.Person.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            var item = await _context.Person.FindAsync(id);
            if(item == null)
            {
                return NotFound();
            }
            return item;
        }
    }
}
