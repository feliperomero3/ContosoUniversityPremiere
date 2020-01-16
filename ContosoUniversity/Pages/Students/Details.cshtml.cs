using System.Threading.Tasks;
using ContosoUniversity.Data;
using ContosoUniversity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoUniversity.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Student Student { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Student = await _unitOfWork.Student.GetStudentDetailAsync(id);

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
