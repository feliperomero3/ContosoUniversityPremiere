using System.Threading.Tasks;
using ContosoUniversity.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Student> GetStudentAsync(int id)
        {
            return await _context.Student.FindAsync(id);
        }

        public void Add(Student student)
        {
            _context.Student.Add(student);
        }

        public void Remove(Student student)
        {
            _context.Student.Remove(student);
        }

        public async Task<Student> GetStudentDetailAsync(int id)
        {
            return await _context.Student
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}