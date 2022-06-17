using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhamacyOn.Models;
using PharmacyOn.Data;

namespace PharmacyOn.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult LogIn()
        {
            var model = new User();
            return View(model);
        }

        //HttpPost Action to check if the email and password are valid.
        [HttpPost]
        public IActionResult LogIn(User model)
        {
            var data = _context.Users.Where(s => s.Email.Equals(model.Email) && s.Password.Equals(model.Password)).ToList();
            if (data.Count == 1)
            {
                ViewBag.Message += string.Format("Logged in successfully<br />");
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                ViewBag.Message += string.Format("Wrong password or username!<br />");
                return View();
            }
        }

        public IActionResult SignUp()
        {
            var model = new User();
            return View(model);
        }

        //HttpPost action to check if a user is already register and if not, to save the new user at database.
        [HttpPost]
        public IActionResult SignUp(User model)
        {

            var data = _context.Users.Where(s => s.Email.Equals(model.Email)).ToList();

            if (data.Count > 0)
            {
                ViewBag.Message += string.Format("Email already taken!<br />");
                return View();
            }
            else
            {
                var account = new User { 

                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Age = model.Age,
                    PersonalID = model.PersonalID,
                    PhoneNumber = model.PhoneNumber,
                    Address = model.Address,
                    Email = model.Email, 
                    Password = model.Password,
                    Weight = model.Weight,
                    Height = model.Height,
                    BloodGroup = model.BloodGroup
                };
                _context.Users.Add(account);
                _context.SaveChanges();
                ViewBag.Message += string.Format("Registered Successfuly!<br />");
                return RedirectToAction("Index", "Blog");
            }
        }
    }
}
