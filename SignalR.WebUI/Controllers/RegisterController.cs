﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignalR.EntityLayer.Entities;
using SignalR.WebUI.Dtos.IdentityDtos;

namespace SignalR.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto dto)
        {
            var appUser = new AppUser()
            {
                Name = dto.Name,
                Surname = dto.Surname,
                Email = dto.Mail,
                UserName = dto.Username
            };
            var result = await _userManager.CreateAsync(appUser,dto.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }
            return View();
        }
    }
}
