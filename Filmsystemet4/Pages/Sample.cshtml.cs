using Azure;
using Filmsystemet4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Filmsystemet4.Pages
{
    public class SampleModel : PageModel
    {
        private readonly ApplicationDbContext _context; // Injected DbContext

        public SampleModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Email { get; set; }

        public void OnGet()
        {
            // Handle HTTP GET requests
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Create a new person with the submitted data
                var person = new Person
                {
                    Name = Name,
                    Email = Email
                };

                // Add the new person to your database
                _context.Persons.Add(person);
                _context.SaveChanges();

                // Redirect to a success page or show a success message
                return RedirectToPage("Success");
            }

            // If the model state is not valid, return to the same page with validation errors
            return Page();
        }

    }
}
