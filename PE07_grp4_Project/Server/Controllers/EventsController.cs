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
    public class EventsController : ControllerBase
    {
        //Refactored
        //private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;

        //Refactored
        //public EventsController(ApplicationDbContext context)
        public EventsController(IUnitOfWork unitOfWork)
        {
            //Refactored
            //_context = context;
            _unitOfWork = unitOfWork;
        }

        // GET: api/Events
        [HttpGet]
        //Refactored
        //public async Task<ActionResult<IEnumerable<Event>>> GetEvents()
        public async Task<IActionResult> GetEvents()
        {
          if (_unitOfWork.Events == null)
          {
              return NotFound();
          }
            //Refactored
            //return await _context.Events.ToListAsync();
            var events = await _unitOfWork.Events.GetAll(includes: q => q.Include(x => x.Organiser));
            return Ok(events);
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        //Refactored
        //public async Task<ActionResult<Event>> GetEvent(int id)
        public async Task<IActionResult> GetEvent(int id)
        {
          if (_unitOfWork.Events == null)
          {
              return NotFound();
          }
            //Refactored
            //var event = await _context.Events.FindAsync(id);
            var events = await _unitOfWork.Events.Get(q => q.Id == id);

            if (events == null)
            {
                return NotFound();
            }
            
            //Refactored
            return Ok(events);
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event events)
        {
            if (id != events.Id)
            {
                return BadRequest();
            }

            //Refactored
            //_context.Entry(events).State = EntityState.Modified;
            _unitOfWork.Events.Update(events);

            try
            {
                //Refactored
                //await _context.SaveChangesAsync();
                await _unitOfWork.Save(HttpContext);
            }
            catch (DbUpdateConcurrencyException)
            {
                //Refactored
                //if (!EventExists(id))
                if (!await EventExists(id))
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

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event events)
        {
            if (_unitOfWork.Events == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Events'  is null.");
            }
            //Refactored
            //_context.Events.Add(events);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Events.Insert(events);
            await _unitOfWork.Save(HttpContext);

            return CreatedAtAction("GetEvent", new { id = events.Id }, events);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            if (_unitOfWork.Events == null)
            {
                return NotFound();
            }
            //Refactored
            //var events = await _context.Events.FindAsync(id);
            var events = await _unitOfWork.Events.Get(q => q.Id == id);
            if (events == null)
            {
                return NotFound();
            }

            //Refactored
            //_context.Events.Remove(events);
            //await _context.SaveChangesAsync();
            await _unitOfWork.Events.Delete(id);
            await _unitOfWork.Save(HttpContext);

            return NoContent();
        }

        //Refactored
        //private bool EventExists(int id)
        private async Task<bool> EventExists(int id)
        {
            //Refactored
            //return (_context.Events?.Any(e => e.Id == id)).GetValueOrDefault();
            var events = await _unitOfWork.Events.Get(q => q.Id == id);
            return events != null;
        }
    }
}
