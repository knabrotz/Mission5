using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission5.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext movieContext { get; set; }

        public HomeController( MovieContext x)
        {
            movieContext = x;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Categories = movieContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Movies(MovieEntry movie)
        {
            if (ModelState.IsValid)
            {
                movieContext.Add(movie);
                movieContext.SaveChanges();

                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList();
                return View(movie);
            }
            
        }

        public IActionResult MovieList()
        {
            var movies = movieContext.Responses
                .Include(x => x.Category)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var movie = movieContext.Responses.Single(x => x.MovieID == movieid);
            return View("Movies", movie);
        }

        [HttpPost]
        public IActionResult Edit(MovieEntry movieEntry)
        {
            movieContext.Update(movieEntry);
            movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = movieContext.Responses.Single(x => x.MovieID == movieid);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(MovieEntry movieEntry)
        {
            movieContext.Responses.Remove(movieEntry);
            movieContext.SaveChanges();
            return RedirectToAction("MovieList");
        }

    }
}
