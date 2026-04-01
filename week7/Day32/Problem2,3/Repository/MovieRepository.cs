using WebApplication4.Data;
using WebApplication4.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication4.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }

        public List<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie? GetById(int id)
        {
            return _context.Movies.FirstOrDefault(m => m.Id == id);
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Update(Movie movie)
        {
            _context.Movies.Update(movie);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _context.Movies.FirstOrDefault(m => m.Id == id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }
    }
}