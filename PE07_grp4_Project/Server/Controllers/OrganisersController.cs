using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PE07_grp4_Project.Server.Data;
using PE07_grp4_Project.Server.IRepository;
using PE07_grp4_Project.Shared.Domain;

namespace PE07_grp4_Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganisersController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public OrganisersController(ApplicationDbContext context)
        public OrganisersController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Organisers
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Organiser>>> GetOrganisers()
        public async Task<IActionResult> GetOrganisers()
        {
          if (_unitOfWork.Organisers == null)
          {
              return NotFound();
          }
            //Refactored
            //return await _context.Organisers.ToListAsync();
            var organisers = await _unitOfWork.Organisers.GetAll();
            return Ok(organisers);
        }

        // GET: api/Organisers/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Organiser>> GetOrganiser(int id)
        public async Task<IActionResult> GetOrganiser(int id)
        {
          if (_unitOfWork.Organisers == null)
          {
              return NotFound();
          }
            //Refactored
            //var organiser = await _context.Organisers.FindAsync(id);
            var organiser = await _unitOfWork.Organisers.Get(q => q.Id == id);

            if (organiser == null)
            {
                return NotFound();
            }
            
            //Refactored
            return Ok(organiser);
        }

        // PUT: api/Organisers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrganiser(int id, Organiser organiser)
        {
            if (id != organiser.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(organiser).State = EntityState.Modified;
            _unitOfWork.Organisers.Update(organiser);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!OrganiserExists(id))
                if (!await OrganiserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Organisers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Organiser>> PostOrganiser(Organiser organiser)
        {
            if (_unitOfWork.Organisers == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Organisers'  is null.");
            }
            //Refactored
            //_context.Organisers.Add(organiser);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Organisers.Insert(organiser);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetOrganiser", new { id = organiser.Id }, organiser);
        }

        // DELETE: api/Organisers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrganiser(int id)
        {
            if (_unitOfWork.Organisers == null)
            {
                return NotFound();
            }
            //Refactored
            //var organiser = await _context.Organisers.FindAsync(id);
            var organiser = await _unitOfWork.Organisers.Get(q => q.Id == id);
            if (organiser == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Organisers.Remove(organiser);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Organisers.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool OrganiserExists(int id)
        private async Task<bool> OrganiserExists(int id)
        {
            //Refactored
            //return (_context.Organisers?.Any(e => e.Id == id)).GetValueOrDefault();
            var organiser = await _unitOfWork.Organisers.Get(q => q.Id == id);
            return organiser != null;
        }
    }
}
