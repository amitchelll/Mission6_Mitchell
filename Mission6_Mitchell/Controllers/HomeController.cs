using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission6_Mitchell.Models;

namespace Mission6_Mitchell.Controllers
{
    public class HomeController : Controller
    {
        private MovieDataContext _context; //Allows MovieDataContext to be referenced in the whole class
        public HomeController(MovieDataContext movie) 
        {
            _context = movie; //Set the passed variable from the database to the _context
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetToKnow()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {

            ViewBag.Categories = _context.Categories.ToList();
            return View("MovieForm", new Movie());
        }

        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response); //Allows the form to pass the information to the database 
                _context.SaveChanges();

                return View("Confirmation", response); //Redirects users to a confirmation page & utilizes the response variable to add a custom greeting.
            }
            else 
            {
                ViewBag.Categories = _context.Categories.ToList();
                return View(response);
            }

        }

        public IActionResult Collection() 
        { 
            var movies = _context.Movies.Include("Category")
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordtoEdit = _context.Movies
                .Single(x => x.MovieId == id);

            ViewBag.Categories = _context.Categories.ToList();
            
            return View("MovieForm", recordtoEdit);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedMovie)
        {
            _context.Update(updatedMovie);
            _context.SaveChanges();

            return RedirectToAction("Collection");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordtoDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordtoDelete);
        }

        [HttpPost]
        public IActionResult Delete(Movie deletedMovie)
        {
            _context.Remove(deletedMovie); 
            _context.SaveChanges();

            return RedirectToAction("Collection");
        }
    }
}
