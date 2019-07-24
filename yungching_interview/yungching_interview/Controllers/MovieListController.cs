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
        // GET: MovieList
        public ActionResult Index(int? pageNumber)
        {
            int currentPage;
            if(pageNumber == null)
            {
                currentPage = 1;
            }
            else
            {
                currentPage = Convert.ToInt32(pageNumber);
            }

            Movie biMovie = new Movie();
            var  result = biMovie.GetAllMovie().ToPagedList(currentPage, 10);
            return View("AllMovie", result);
        }
    }
}