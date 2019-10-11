using System.Threading.Tasks;

namespace ContosoUniversity.Data
{
    public interface IUnitOfWork
    {
        IStudentRepository Student { get; }
        Task CompleteAsync();
    }
}