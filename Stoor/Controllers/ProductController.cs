using Microsoft.AspNetCore.Mvc;
using Stoor.Data;
using Stoor.Models;

namespace Stoor.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Products.ToList());

        }
        [HttpGet]
        public IActionResult Details(int Id) 
        {
            if(Id == 0)
            {
                return NotFound();
            }
            var product = _context.Products.FirstOrDefault(p => p.Id == Id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult Update(int Id , Product product)
        {
            if(Id != product.Id)
            {
                return NotFound();
            }
            if(ModelState.IsValid) { 
            _context.Update(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
                    }
            return View(product);
        }
        [HttpGet]
        public IActionResult Update(int Id)
        {
            if (Id ==null)
            {
                return NotFound();
            }
            var product = _context.Products.FirstOrDefault(p => p.Id == Id);
            if(product==null)
            {
                return NotFound();
              
            }
            return View(product);
        }

        [HttpGet("Delete/{id}")]
        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var product = _context.Products.FirstOrDefault(p => p.Id == Id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost("Delete/{id}")]
        public IActionResult DeleteConfirmed(int Id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == Id);

            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
