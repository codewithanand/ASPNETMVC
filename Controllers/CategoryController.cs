using BulkyMovie.Data;
using BulkyMovie.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace BulkyMovie.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if(category.CategoryName == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("DisplayOrder", "The Display Order cannot match the Category Name");
            }
            if(ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                TempData["success"] = "Category created";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Category category = _context.Categories.Find(id);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                TempData["success"] = "Category updated";
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
            TempData["success"] = "Category deleted";
            return RedirectToAction(nameof(Index));
        }
    }
}
