using MvcDemo.Models;
using MvcDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemo.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie/Random
        public ActionResult Random()
        {
            var movie = new Movie { Id = 1, Name = "Shrek" };
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Customer 1" },
                new Customer { Id = 2, Name = "Customer 2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content($"You are trying to edit movie with id: {id}");
        }

        public ActionResult Index(int pageIndex = 1, string sortBy = "name")
        {
            return Content($"Viewing movies starting with page {pageIndex}, sorted by {sortBy}");
        }

        public ActionResult ByReleaseDate(int year, int month)
        {
            DateTime date = new DateTime(year, month, 1);
            return Content($"Showing movies released in {date.ToString("MMM yyyy", CultureInfo.InvariantCulture)}");
        }

        [Route("movies/awards/{moviename}/{awardname}/{wasWinner:bool}")]
        public ActionResult GetAward(string movieName, string awardName, bool wasWinner)
        {
            string wonResult = wasWinner ? "...congrats to them!" : " not...sorry";
            return Content($"You are trying to see if {movieName} won the {awardName} award.\nWell...they did{wonResult}");
        }
    }
}