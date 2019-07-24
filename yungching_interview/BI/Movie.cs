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
            MovieTestEntities movieTestEntities = new MovieTestEntities();
            return movieTestEntities.Movie.ToList();
        }
    }
}
