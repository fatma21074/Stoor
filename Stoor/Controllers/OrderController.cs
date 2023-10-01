using Microsoft.AspNetCore.Mvc;
using Stoor.Data;
using Stoor.Models;
using Stoor.Models.Dtos;

namespace Stoor.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create( OrderDtos order)
        {
            if (!ModelState.IsValid)
                return View(order);
            var Order = new Order
            {
                ProductId=order.ProductId,
                UserId=order.UserId,
                DateTime = DateTime.Now,
            };
            _context.orders.Add(Order);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Index(OrderDtos dtos)
        {
           var product = _context.Products.FirstOrDefault(p=>p.Id==2);
          var User =_context.Users.FirstOrDefault(u=>u.Id==2);
            var Order = new UserOrderDtos
            {
                FirstName = User.FirstName,
                LastName = User.LastName,
                Address = User.Address,
                Email = User.Email,
                PhoneNumber = User.PhoneNumber,
                UserId = User.Id,
                Price = product.Price,
                Name = product.Name,
                Description = product.Description,
                ProductId = product.Id,

            };
            return View(Order);
        }
    }
}
