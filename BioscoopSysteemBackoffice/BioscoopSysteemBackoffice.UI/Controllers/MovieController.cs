using BioscoopSysteemWebsite.Domain.Entities;
using BioscoopSysteemWebsite.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BioscoopSysteemBackoffice.UI.Controllers
{


    public class MovieController : Controller
    {
        IRepository repo;

        public MovieController(IRepository repo)
        {
            this.repo = repo;
        }

        // GET: Movie
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Add()
        {
            throw new NotImplementedException();
        }

        public ViewResult Edit(int movieId)
        {
            throw new NotImplementedException();
        }

        public ViewResult Remove(int movieId)
        {
            throw new NotImplementedException();
        }

        public ViewResult List(bool showExpired)
        {
            List<Movie> movies;

            movies = showExpired ? repo.GetAllMovies().OrderBy(r => r.Name).ToList() : repo.GetAllMovies().Where(r => r.EndDate > DateTime.Now).OrderBy(r => r.Name).ToList();

            return View(movies);
        }
    }
}