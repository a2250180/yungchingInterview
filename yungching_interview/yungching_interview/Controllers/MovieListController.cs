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
        public ActionResult GetMovie(int movieID, bool is4Update)       //取得指定電影
        {
            if (is4Update)      //是否為更新使用
            {
                return PartialView("UpdateMovie", biMovie.GetMovie(movieID));
            }
            return PartialView("MovieDetail", biMovie.GetMovie(movieID));
        }

        public ActionResult OpenCreateMovieModal()      //呼叫新增電影的介面
        {
            return PartialView("CreateMovie");
        }

        [HttpPost]
        public ActionResult CreateMovie(DataAccess.Movie movie)     //新增電影
        {
            if (ModelState.IsValid)
            {
                if (biMovie.CreateMovie(movie))     //如果新增電影成功
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
                if (biMovie.UpdateMovie(movie))     //如果更新電影成功
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
            if (biMovie.DeleteMovie(movieID))       //如果刪除電影成功
            {
                var result = biMovie.GetAllMovie().ToPagedList(1, 10);
                return PartialView("MovieTable", result);
            }
            return Content("刪除電影失敗");
        }
    }
}