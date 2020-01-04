using DemoWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Repository
{
    public interface IStudentsRepositroy
    {
        Task AddStudentAsync(Students students);
        Task<IEnumerable<Students>> GetStudentsAsync();
        Task<Students> GetStudentAsync(int id);
        Task UpdateStudentAsync(Students students);
        Task<Students> DeleteStudentAsync(int id);
        bool IsStudentExists(int id);
    }
}
