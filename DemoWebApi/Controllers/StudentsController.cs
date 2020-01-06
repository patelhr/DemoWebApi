using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoWebApi.Model;
using DemoWebApi.Repository;

namespace DemoWebApi.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsRepositroy _studentsRepositroy;
        public StudentsController(IStudentsRepositroy studentsRepositroy)
        {
            _studentsRepositroy = studentsRepositroy;
        }
        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Students>>> GetStudents()
        {
            
            var students = await _studentsRepositroy.GetStudentsAsync();
            return Ok(students);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> GetStudents(int id)
        {
            var student = await _studentsRepositroy.GetStudentAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudents(int id, Students students)
        {
            if (id != students.Id)
            {
                return BadRequest();
            }
            try
            {
                await _studentsRepositroy.UpdateStudentAsync(students);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_studentsRepositroy.IsStudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        // POST: api/Students
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Students>> PostStudents(Students students)
        {
            await _studentsRepositroy.AddStudentAsync(students);
            return Ok();
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Students>> DeleteStudents(int id)
        {
            var students = await _studentsRepositroy.DeleteStudentAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return Ok();
        }


    }
}
