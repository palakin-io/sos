using AccentureMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccentureMovie.Controllers
{
    public class MoviesController : Controller
    {
        private AccentureAccademyMovieDbEntities db;
        public MoviesController()
        {
            this.db = new AccentureAccademyMovieDbEntities();
        }

        public ActionResult Listar()
        {
            List<Movie> movies = this.db.Movie.ToList();
            return View(movies);
        }

        public ActionResult Editar(int id)
        {
            Movie m = this.db.Movie.Find(id);
            return View(m);
        }

        [HttpPost]
        public ActionResult Editar(Movie movie)
        {
            this.db.Movie.Attach(movie);
            this.db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }

        public ActionResult Agregar()
        {
            Movie m = new Movie();
            return View("Editar", m);
        }

        [HttpPost]
        public ActionResult Agregar(Movie movie)
        {
            this.db.Movie.Add(movie);
            this.db.SaveChanges();
            return RedirectToAction("Listar");
        }
    }
}