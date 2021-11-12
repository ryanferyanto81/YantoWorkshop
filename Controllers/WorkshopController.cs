using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using YantoWorkshop.Data;
using YantoWorkshop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity;

namespace YantoWorkshop.Controllers
{
    public class WorkshopController : Controller
    {
        private YantoWorkshopDbContext _context;
        public WorkshopController(YantoWorkshopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Workshops.ToList());
        }

        public async Task<IActionResult> Beli(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }  
            var beli =  await _context.Workshops
                .FirstOrDefaultAsync(m => m.Id == id);
            if (beli == null)
            {
                return NotFound();
            }
            return View(beli);
        }
                [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,NamaProduk,JumlahBarang,Harga")] Workshop workshop)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Workshops.Add(workshop);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(workshop);
        }
         public IActionResult Create()
        {
            return View();
        }
       public IActionResult Show(int id)
        {
            var workshop = _context.Workshops.Find(id);
            return View(workshop);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        
        public IActionResult Error()
        {
            return View("Error!");
        }
                    public async Task<IActionResult> Delete(int? id)
            {
                if (id == null)
                {
                    return NotFound();
                }

             var workshop = await _context.Workshops
            .FirstOrDefaultAsync(m => m.Id == id);
             if (workshop == null)
            {
                return NotFound();
            }

            return View(workshop);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Workshops.FindAsync(id);
            _context.Workshops.Remove(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
           
        }
        
        public IActionResult Pembelian()
        {
            return View();
        }
    }
}