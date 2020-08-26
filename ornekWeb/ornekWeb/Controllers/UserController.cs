using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ornekWeb.Data;
using ornekWeb.Models;

namespace ornekWeb.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepository;

        public UserController(IUserRepository repository)
        {
            userRepository = repository;
        }

        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UserLogin(string UserEmail, string UserPassword)
        {
            if (!string.IsNullOrEmpty(UserEmail) && string.IsNullOrEmpty(UserPassword))
            {
                return RedirectToAction("Index", "Home");
            }
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;

            var userControl = userRepository.GetByLogin(UserEmail, UserPassword);

            if (userControl != null)
            {
                identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, UserEmail),
                    new Claim(ClaimTypes.Role, userControl.UserAuthority),
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                isAuthenticated = true;
            }
            else
            {
                TempData["message"] = "Böyle bir kullanıcı bulunmuyor. Lütfen tekrar deneyiniz.";
                return RedirectToAction("Index", "Home");
            }
            if (isAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult UserLogout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UserList()
        {
            //ViewData["UserName"] = new SelectList(userRepository.GetAll(), "UserId", "UserName");
            return View(userRepository.GetAll());
        }

        [HttpGet]
        public IActionResult UserCreate()
        {
            //ViewBag.Airlines = new SelectList(airlineRepository.GetAll(), "AirlineId", "AirlineNumber").Count()+1;

            return View();
        }

        [HttpPost]
        public IActionResult UserCreate(User entity)
        {
            if (ModelState.IsValid)
            {
                userRepository.AddUser(entity);
                userRepository.Commit();
                return RedirectToAction("UserList");
            }

            return View(entity);
        }
    }
}