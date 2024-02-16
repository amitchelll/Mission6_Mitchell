using Microsoft.AspNetCore.Mvc;
using Mission6_Mitchell.Models;
using System.Diagnostics;

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
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(Form response)
        {
            _context.Forms.Add(response); //Allows the form to pass the information to the database 
            _context.SaveChanges();

            return View("Confirmation", response); //Redirects users to a confirmation page & utilizes the response variable to add a custom greeting.
        }
    }
}
