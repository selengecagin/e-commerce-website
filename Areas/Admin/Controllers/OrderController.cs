﻿using e_commerce_website.Areas.Admin.Controllers;
using e_commerce_website.Data;
using e_commerce_website.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace e_commerce_website.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public OrderDetailsVM OrderVM { get; set; }

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpPost]
        [Authorize(Roles = Other.Role_Admin)]
        public IActionResult Confirmed()
        {
            OrderHeader orderHeader = _db.OrderHeaders.FirstOrDefault(i =>i.Id ==OrderVM.OrderHeader.Id);
            orderHeader.OrderStatus = Other.OrderConfirmed;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize(Roles = Other.Role_Admin)]
        public IActionResult InitiateShipment()
        {
            OrderHeader orderHeader = _db.OrderHeaders.FirstOrDefault(i => i.Id == OrderVM.OrderHeader.Id);
            orderHeader.OrderStatus = Other.OrderShipped;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            OrderVM = new OrderDetailsVM
            {
                OrderHeader = _db.OrderHeaders.FirstOrDefault(i => i.Id == id),
                OrderDetails = _db.OrderDetails.Where(x => x.OrderId == id).Include(x => x.Product)
            };
            return View(OrderVM);
        }
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<OrderHeader> orderHeaderList;

            if(User.IsInRole(Other.Role_Admin))
            {
                orderHeaderList = _db.OrderHeaders.ToList();
            }
            else
            {
                orderHeaderList = _db.OrderHeaders.Where(i => i.ApplicationUserId == claim.Value).Include(i => i.ApplicationUser);
            }
            return View(orderHeaderList);
        }

        public IActionResult PendingOrders()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<OrderHeader> orderHeaderList;

            if (User.IsInRole(Other.Role_Admin))
            {
                orderHeaderList = _db.OrderHeaders.Where(i => i.OrderStatus == Other.OrderOnHold);
            }
            else
            {
                orderHeaderList = _db.OrderHeaders.Where(i => i.ApplicationUserId == claim.Value && i.OrderStatus==Other.OrderOnHold).Include(i => i.ApplicationUser);
            }
            return View(orderHeaderList);
        }


        public IActionResult ConfirmedOrders()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<OrderHeader> orderHeaderList;

            if (User.IsInRole(Other.Role_Admin))
            {
                orderHeaderList = _db.OrderHeaders.Where(i => i.OrderStatus == Other.OrderConfirmed);
            }
            else
            {
                orderHeaderList = _db.OrderHeaders.Where(i => i.ApplicationUserId == claim.Value && i.OrderStatus == Other.OrderConfirmed).Include(i => i.ApplicationUser);
            }
            return View(orderHeaderList);
        }


        public IActionResult ShippedOrders()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            IEnumerable<OrderHeader> orderHeaderList;

            if (User.IsInRole(Other.Role_Admin))
            {
                orderHeaderList = _db.OrderHeaders.Where(i => i.OrderStatus == Other.OrderShipped);
            }
            else
            {
                orderHeaderList = _db.OrderHeaders.Where(i => i.ApplicationUserId == claim.Value && i.OrderStatus == Other.OrderShipped).Include(i => i.ApplicationUser);
            }
            return View(orderHeaderList);
        }

    }
}



