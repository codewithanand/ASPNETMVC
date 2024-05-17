using BulkyMovieRazor.Data;
using BulkyMovieRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyMovieRazor.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            TempData["success"] = "Category created";
            return RedirectToPage("/categories/index");
        }
    }
}
