using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BI;
using PagedList;

namespace yungching_interview.Controllers
{
    public class MovieListController : Controller
    {
        Movie biMovie = new Movie();

        public ActionResult Index(int? pageNumber)
        {
            int currentPage;
            if (pageNumber == null)
            {
                currentPage = 1;
            }
            else
            {
                currentPage = Convert.ToInt32(pageNumber);
            }

            var result = biMovie.GetAllMovie().ToPagedList(currentPage, 10);
            return View("AllMovie", result);
        }

        [HttpPost]
        public ActionResult GetMovie(int movieID, bool is4Update)
        {
            if (is4Update)
            {
                return PartialView("UpdateMovie", biMovie.GetMovie(movieID));
            }
            return PartialView("MovieDetail", biMovie.GetMovie(movieID));
        }

        public ActionResult OpenCreateMovieModal()
        {
            return PartialView("CreateMovie");
        }

        [HttpPost]
        public ActionResult CreateMovie(DataAccess.Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (biMovie.CreateMovie(movie))
                {
                    var result = biMovie.GetAllMovie().ToPagedList(1, 10);
                    return PartialView("MovieTable", result);
                }
            }
            return PartialView("CreateMovie", movie);
        }

        [HttpPost]
        public ActionResult UpdateMovie(DataAccess.Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (biMovie.UpdateMovie(movie))
                {
                    var result = biMovie.GetAllMovie().ToPagedList(1, 10);
                    return PartialView("MovieTable", result);
                }
            }
            return PartialView("UpdateMovie", movie);
        }

        [HttpPost]
        public ActionResult DeleteMovie(int movieID)
        {
            if (biMovie.DeleteMovie(movieID))
            {
                var result = biMovie.GetAllMovie().ToPagedList(1, 10);
                return PartialView("MovieTable", result);
            }
            return PartialView("MovieTable", null);
        }
    }
}