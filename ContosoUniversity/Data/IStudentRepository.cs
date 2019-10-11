using System.Threading.Tasks;
using ContosoUniversity.Entities;

namespace ContosoUniversity.Data
{
    public interface IStudentRepository
    {
        Task<Student> GetStudentAsync(int id);
        void Add(Student student);
        void Remove(Student student);
    }
}