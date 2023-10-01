using Microsoft.AspNetCore.Mvc;
using Stoor.Data;
using Stoor.Models;
using Stoor.Models.Dtos;
using System.Diagnostics;   

namespace Stoor.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Signup()
        {
            return View(new UserSignupDtos());
        }
        [HttpPost]
        public IActionResult Signup(UserSignupDtos dto)
        {
            if (!ModelState.IsValid) 
                return View(dto);
            var User = new User
            {
                Id=0,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Email = dto.Email,
                Password = dto.Password,
            };
            _context.Users.Add(User);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Signin()
        {
            return View(new UserSigninDtos());
        }
        [HttpPost]
        public IActionResult Signin(UserSigninDtos dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            var User = new User
            {
                Email = dto.Email,
                Password = dto.Password,
            };
            _context.Users.Add(User);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}