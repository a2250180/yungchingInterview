using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BI
{
    public class Movie
    {
        public List<DataAccess.Movie> GetAllMovie()
        {
            MovieTestEntities dbMovieTest = new MovieTestEntities();
            return dbMovieTest.Movie.ToList();
        }

        public DataAccess.Movie GetMovie(int movieID)
        {
            MovieTestEntities dbMovieTest = new MovieTestEntities();
            DataAccess.Movie movie = dbMovieTest.Movie.FirstOrDefault(x => x.ID == movieID);
            return movie;
        }

        public bool CreateMovie(DataAccess.Movie movie)
        {
            MovieTestEntities dbMovieTest = new MovieTestEntities();
            dbMovieTest.Movie.Add(movie);
            dbMovieTest.SaveChanges();
            return true;
        }

        public bool UpdateMovie(DataAccess.Movie movie)
        {
            MovieTestEntities dbMovieTest = new MovieTestEntities();
            DataAccess.Movie queryMovie = dbMovieTest.Movie.FirstOrDefault(x => x.ID == movie.ID);
            if(queryMovie != null)
            {
                dbMovieTest.Entry(queryMovie).CurrentValues.SetValues(movie);
                dbMovieTest.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteMovie(int movieID)
        {
            MovieTestEntities dbMovieTest = new MovieTestEntities();
            DataAccess.Movie queryMovie = dbMovieTest.Movie.FirstOrDefault(x => x.ID == movieID);
            if (queryMovie != null)
            {
                dbMovieTest.Movie.Remove(queryMovie);
                dbMovieTest.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
