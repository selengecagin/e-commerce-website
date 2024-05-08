﻿using e_commerce_website.Data;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var users= _context.ApplicationUsers.ToList();
            var role=_context.Roles.ToList();
            var userRole =_context.UserRoles.ToList();

            foreach (var user in users)
            {
                var roleId = userRole.FirstOrDefault(i => i.UserId == user.Id).RoleId;

                user.Role = role.FirstOrDefault(i => i.Id == roleId).Name;

            }
            return View(users);
        }
    }
}