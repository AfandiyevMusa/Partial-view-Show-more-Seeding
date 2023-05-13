using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiorello.Data;
using Fiorello.Models;
using Fiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await _context.products.Include(m => m.Images).Take(4).Where(m => !m.SoftDelete).ToListAsync();

            var count = await _context.products.Where(m => !m.SoftDelete).CountAsync();

            ViewBag.productCount = count;
            ShopVM model = new()
            {
                products = products
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ShowMoreOrLess(int skip)
        {
            IEnumerable<Product> products = await _context.products.Include(m => m.Images).Where(m => !m.SoftDelete).Skip(skip).Take(4).ToListAsync();

            ShopVM model = new()
            {
                products = products
            };

            return PartialView("_ProductsPartial", model.products);
        }
    }
}

