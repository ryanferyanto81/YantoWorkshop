using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcMovie.Data;
using MvcMovie.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcMovie.Controllers
{
    public class MovieController : Controller
    {
        private MvcMovieDbContext _context;

        public MovieController(MvcMovieDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString, string movieGenre)
        {
            // SELECT DISTINCT Movies.Genre FROM Movies
            var genres = _context.Movies.Select(x => x.JumlahBarang).Distinct();
            var movies = _context.Movies.AsQueryable();
            
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(x => x.NamaProduk.Contains(searchString));
            }
            
            if (!String.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.JumlahBarang == movieGenre);
            }
            
            var viewModel = new MovieGenreViewModel()
            {
                Movies = await movies.ToListAsync(),
                Genres = new SelectList(await genres.ToListAsync())
            };
            
            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,NamaProduk,TanggalOrder,JumlahBarang,Harga")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Movies.Add(movie);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            
            var movie = _context.Movies.Find(id);
            if (movie == null)
                return NotFound();
            
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, [Bind("Id,NamaProduk,TanggalOrder,JumlahBarang,Harga")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Movies.Update(movie);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        private bool MovieExists(int id)
        {
            var movie = _context.Movies.Find(id);
            return movie != null;
        }

        public IActionResult Show(int id)
        {
            var movie = _context.Movies.Find(id);
            return View(movie);
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

             var movie = await _context.Movies
            .FirstOrDefaultAsync(m => m.Id == id);
             if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
           
        }
    }
}