using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAPI;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentInfoesController : ControllerBase
    {
        private readonly studentDBContext _context;

        public studentInfoesController(studentDBContext context)
        {
            _context = context;
        }

        // GET: api/studentInfoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<studentInfo>>> GetstudentTable()
        {
            return await _context.studentTable.ToListAsync();
        }

        // GET: api/studentInfoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<studentInfo>> GetstudentInfo(int id)
        {
            var studentInfo = await _context.studentTable.FindAsync(id);

            if (studentInfo == null)
            {
                return NotFound();
            }

            return studentInfo;
        }

        // PUT: api/studentInfoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutstudentInfo(int id, studentInfo studentInfo)
        {
            if (id != studentInfo.stdId)
            {
                return BadRequest();
            }

            _context.Entry(studentInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!studentInfoExists(id))
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

        // POST: api/studentInfoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<studentInfo>> PoststudentInfo(studentInfo studentInfo)
        {
            _context.studentTable.Add(studentInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetstudentInfo", new { id = studentInfo.stdId }, studentInfo);
        }

        // DELETE: api/studentInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletestudentInfo(int id)
        {
            var studentInfo = await _context.studentTable.FindAsync(id);
            if (studentInfo == null)
            {
                return NotFound();
            }

            _context.studentTable.Remove(studentInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool studentInfoExists(int id)
        {
            return _context.studentTable.Any(e => e.stdId == id);
        }
    }
}
