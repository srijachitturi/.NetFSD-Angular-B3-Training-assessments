using WebApplication4.Models;
using System.Collections.Generic;

namespace WebApplication4.Repositories
{
    public interface IMovieRepository
    {
        List<Movie> GetAll();
        Movie? GetById(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
    }
}