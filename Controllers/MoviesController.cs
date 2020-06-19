using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();    
        }

        // GET: Movies
        public ActionResult Index()
        {
            IEnumerable<Movie> movies = _context.Movies.Include(g => g.Genre).ToList();

            return View(movies);
        }

        [HttpPost]
        public ActionResult Save(MovieFormViewModel viewModel)
        {
            if (viewModel.Movie.Id == 0)
            {
                viewModel.Movie.DateAdded = DateTime.Now;
                _context.Movies.Add(viewModel.Movie);
            }
            else
            {
                var movieInDB = _context.Movies.Single(m => m.Id == viewModel.Movie.Id);

                movieInDB.Name = viewModel.Movie.Name;
                movieInDB.NumberInStock = viewModel.Movie.NumberInStock;
                movieInDB.ReleaseDate = viewModel.Movie.ReleaseDate;
                movieInDB.GenreId = viewModel.Movie.GenreId;
              
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}