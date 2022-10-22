using Microsoft.AspNetCore.Mvc;
using MVCMovies.Models;
using System.Diagnostics;
using MVCMovies.DatabaseHelper;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace MVCMovies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Movies = DatabaseHelper.DatabaseHelper.GetMovies();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit(int IdMovie)
        {
            Movies movie = new Movies()
            {
                IdMovie = Convert.ToInt32(IdMovie),
            };

            ViewBag.Movies = DatabaseHelper.DatabaseHelper.GetIDMovies(IdMovie);

            return View();
        }

        public IActionResult Delete(int IdMovie)
        {
            Movies movie = new Movies()
            {
                IdMovie = Convert.ToInt32(IdMovie),
            };

            ViewBag.IdMovie = DatabaseHelper.DatabaseHelper.Delete(IdMovie);

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult SaveMovie(string txtIdMovie, string txtName, string selectGenere, string txtDate)
        {

            Movies movie = new Movies()
            {
                IdMovie = Convert.ToInt32(txtIdMovie),
                Name = txtName,
                Genere = selectGenere,
                Date = txtDate,
                Photo = "/images/0.jpg",
            };

            DatabaseHelper.DatabaseHelper.CreateMovie(movie);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult SaveEditMovie(string txtIdMovie, string txtName, string selectGenere, string txtDate)
        {

            Movies movie = new Movies()
            {
                IdMovie = Convert.ToInt32(txtIdMovie),
                Name = txtName,
                Genere = selectGenere,
                Date = txtDate
            };

            DatabaseHelper.DatabaseHelper.EditMovie(movie);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult UpdatePhoto(int IdMovie, IFormFile photo)
        {
            Movies movie = new Movies()
            {
                IdMovie = Convert.ToInt32(IdMovie),
                Photo = Convert.ToString(photo)
            };

            ViewBag.Movies = DatabaseHelper.DatabaseHelper.UpdatePhoto(IdMovie, photo);

            return RedirectToAction("Index", "Home");
        }


        public ActionResult DeletePhoto(int IdMovie, string photo)
        {
            Movies movie = new Movies()
            {
                IdMovie = Convert.ToInt32(IdMovie),
                Photo = Convert.ToString(photo)
            };

            ViewBag.Movies = DatabaseHelper.DatabaseHelper.DeletePhoto(IdMovie, photo);

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}