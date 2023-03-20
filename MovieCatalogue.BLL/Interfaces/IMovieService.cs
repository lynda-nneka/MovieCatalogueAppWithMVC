using System;
using MovieCatalogue.BLL.Models;
using System.Threading.Tasks;
using MovieCatalogue.DAL.Entities;

namespace MovieCatalogue.BLL.Interfaces
{
    public interface IMovieService
    {
        Task<(bool successful, string msg)> AddOrUpdateAsync(AddorUpdateMovieVM models);
        Task<(bool successful, string msg)> DeleteAsync(int Id);
        Task<IEnumerable<MovieVM>> GetMovies();
        Task<MovieVM> GetMovie(int Id);
        Task<(bool successful, string msg)> Edit(AddorUpdateMovieVM models, int Id);
    }
}

