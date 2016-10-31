using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBHelper
{
    public static class MovieModel
    {
        public static Entities ctx = new Entities();
        public static IEnumerable<Movie> GetAllMovies()
        {

            var movies = ctx.Movies.Select(x => x);
            return movies;


        }
        public static void UpdateMovie(Movie movie)
        {

            var result = ctx.Movies.Where(x => x.MovieID == movie.MovieID);

            result.FirstOrDefault().MovieName = movie.MovieName;

            ctx.SaveChanges();

        }

        public static void MovieDelete(Movie movie)
        {
            var result = from x in ctx.Movies where x.MovieID == movie.MovieID select x;

            ctx.Movies.Remove(result.FirstOrDefault());
            ctx.SaveChanges();

        }
        public static void InsertBook(Movie movie)
        {

            ctx.Movies.Add(movie);
            ctx.SaveChanges();

        }


    }
}
