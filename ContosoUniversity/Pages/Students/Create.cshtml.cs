using System.Threading.Tasks;
using ContosoUniversity.Data;
using ContosoUniversity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContosoUniversity.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _unitOfWork.Student.Add(Student);

            await _unitOfWork.CompleteAsync();

            return RedirectToPage("./Index");
        }
    }
}