using DemoWebApi.Context;
using DemoWebApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Repository
{
    public class StudentsRepository : IStudentsRepositroy
    {
        private readonly DemoWebApiDbContext _context;

        public StudentsRepository(DemoWebApiDbContext context)
        {
            _context = context;
        }


        public async Task AddStudentAsync(Students students)
        {
            _context.Students.Add(students);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Students>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Students> GetStudentAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task UpdateStudentAsync(Students students)
        {
            _context.Entry(students).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Students> DeleteStudentAsync(int id)
        {
            var students = await _context.Students.FindAsync(id);
            if (students != null)
            {
                _context.Students.Remove(students);
                await _context.SaveChangesAsync();
            }
            return students;
        }

        public bool IsStudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }

    }
}
