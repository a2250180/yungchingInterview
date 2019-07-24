using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace yungching_interview.Controllers
{
    public class MovieListController : Controller
    {
        // GET: MovieList
        public ActionResult Index()
        {
            return View();
        }
    }
}