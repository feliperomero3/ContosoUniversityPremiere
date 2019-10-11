using System.Threading.Tasks;

namespace ContosoUniversity.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Student = new StudentRepository(context);
        }

        public IStudentRepository Student { get; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
