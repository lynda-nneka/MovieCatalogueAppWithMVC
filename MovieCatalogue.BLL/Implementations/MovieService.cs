using System;
using MovieCatalogue.BLL.Interfaces;
using MovieCatalogue.BLL.Models;
using MovieCatalogue.DAL.Entities;
using System.Linq;
using MovieCatalogue.DAL.Repository;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieCatalogue.BLL.Implementations
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Movies> _movieRepo;


        public MovieService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _movieRepo = _unitOfWork.GetRepository<Movies>();

        }

        public async Task<(bool successful, string msg)> AddOrUpdateAsync(AddorUpdateMovieVM models)
        {
            Movies movie = await _movieRepo.GetSingleByAsync(movie => movie.Id == models.Id, tracking: true);

            if (movie != null)
            {
                _mapper.Map(models, movie);
                await _movieRepo.SaveAsync();
                return (true, "update Successful");
            }


            var newMovie = _mapper.Map<Movies>(models);

            _movieRepo.Add(newMovie);

            var rowChanges = await _movieRepo.SaveAsync();

            return rowChanges > 0 ? (true, $"Task: {models.Title} was successfully created!") : (false, "Failed To save changes!");



        }
        public async Task<(bool successful, string msg)> DeleteAsync(int Id)
        {
            Movies movies = _movieRepo.GetSingleBy(m => m.Id == Id);
            if (movies != null)
            {
                _movieRepo.Delete(movies);

                return await _unitOfWork.SaveChangesAsync() > 0 ? (true, $"Movie with Title:{movies.Title} was deleted") : (false, $"Delete Failed");
            }
            return (false, $"Movie with id:{Id} was not found");



        }



        public async Task<IEnumerable<MovieVM>> GetMovies()
        {
            IEnumerable<Movies> movies = await _movieRepo.GetAllAsync();


            var getAllMovies = _mapper.Map<IEnumerable<MovieVM>>(movies);



            return getAllMovies;
        }

        public async Task<MovieVM> GetMovie(int Id)
        {
            Movies movies = await _movieRepo.GetByIdAsync(Id);


            var getMovie = _mapper.Map<MovieVM>(movies);



            return getMovie;

        }

        public async Task<(bool successful, string msg)> Edit(AddorUpdateMovieVM models, int Id)
        {
            Movies movie = await _movieRepo.GetSingleByAsync(movie => movie.Id == Id, tracking: true);

            if (movie != null)
            {
                _mapper.Map(models, movie);
                await _movieRepo.SaveAsync();
                return (true, "update Successful");
            }
            return (false, $"Movie with id:{Id} was not found");
        }

    }
}