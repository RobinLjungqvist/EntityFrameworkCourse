using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieEFDemo
{
    public partial class Movie
    {
        private MovieEntities ctx = new MovieEntities();
        //Controller
        public List<Movie> GetAllMovies()
        {

            var result = (from m in ctx.Movie
                          join c in ctx.Category on m.CategoryID equals c.ID
                          select m).Include("Category").ToList();
            return result;
            
        }

        public void InsertMovie(Movie movie)
        {
            
                ctx.Movie.Add(movie);
                ctx.SaveChanges();
            
        }
        public void UpdateMovie(Movie movie)
        {
            
                ctx.Movie.Attach(movie);
                ctx.SaveChanges();
            
        }
        public void DeleteMovie(Movie movie)
        {
            
                ctx.Movie.Attach(movie);
                ctx.Movie.Remove(movie);
                ctx.SaveChanges();
            
        }

    }
}