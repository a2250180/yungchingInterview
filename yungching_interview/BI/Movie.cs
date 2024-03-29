﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BI
{
    public class Movie
    {
        public List<DataAccess.Movie> GetAllMovie()     //取得所有電影
        {
            MovieEntities dbMovie = new MovieEntities();
            return dbMovie.Movie.ToList();
        }

        public DataAccess.Movie GetMovie(int movieID)       //取得指定的電影
        {
            MovieEntities dbMovie = new MovieEntities();
            DataAccess.Movie movie = dbMovie.Movie.FirstOrDefault(x => x.ID == movieID);
            return movie;
        }

        public bool CreateMovie(DataAccess.Movie movie)     //新增電影
        {
            MovieEntities dbMovie = new MovieEntities();
            dbMovie.Movie.Add(movie);
            dbMovie.SaveChanges();
            return true;
        }

        public bool UpdateMovie(DataAccess.Movie movie)     //更新電影
        {
            MovieEntities dbMovie = new MovieEntities();
            DataAccess.Movie queryMovie = dbMovie.Movie.FirstOrDefault(x => x.ID == movie.ID);
            if(queryMovie != null)
            {
                dbMovie.Entry(queryMovie).CurrentValues.SetValues(movie);
                dbMovie.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteMovie(int movieID)        //刪除電影
        {
            MovieEntities dbMovie = new MovieEntities();
            DataAccess.Movie queryMovie = dbMovie.Movie.FirstOrDefault(x => x.ID == movieID);
            if (queryMovie != null)
            {
                dbMovie.Movie.Remove(queryMovie);
                dbMovie.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
