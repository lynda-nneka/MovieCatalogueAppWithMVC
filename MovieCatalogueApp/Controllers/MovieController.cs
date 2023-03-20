using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieCatalogue.BLL.Interfaces;
using MovieCatalogue.BLL.Models;
using MovieCatalogue.DAL.Entities;
using MovieCatalogue.BLL.Implementations;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieCatalogueApp.Controllers
{
    [AutoValidateAntiforgeryToken]

    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
     

        public MovieController( IMovieService movieService)
        {
          
            _movieService = movieService;
        }
        // GET: /<controller>
       
        public  async Task<IActionResult> Index()
        {
            var model = await _movieService.GetMovies();
            return View(model);
        }


        public IActionResult New()
        {
            return View(new AddorUpdateMovieVM());
        }


        [HttpPost]
        public async Task<IActionResult> Save(AddorUpdateMovieVM models)
        {
            if (ModelState.IsValid)
            {

                var (successful, msg) = await _movieService.AddOrUpdateAsync(models);

                if (successful)
                {

                    TempData["SuccessMsg"] = msg;

                    return RedirectToAction("Index");
                }

                // TempData["ErrMsg"] = msg; for both views and redirect to actions

                ViewBag.ErrMsg = msg;

                return View("New");

            }

            return View("New");

        }

        [HttpGet]
        public async Task<IActionResult> DeleteConfirm(int Id)
        {
            var currentMovie = await _movieService.GetMovie(Id);
            if(currentMovie != null)
            {
                return View("Delete", currentMovie);
            }

            TempData["ErrMsg"] = $"Movie with Id:{Id} not found";
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int Id)
        {
            var (success, msg) = await _movieService.DeleteAsync(Id);

            if (success)
            {
                TempData["SuccessMsg"] = msg;
                return RedirectToAction("Index");
            }

            TempData["ErrMsg"] = msg;
            return RedirectToAction("Index");
        }


        public IActionResult Edit()
        {
            return View(new AddorUpdateMovieVM());
        }


        [HttpPost]
        public async Task<IActionResult> Edit(AddorUpdateMovieVM models, int Id)
        {
            if (ModelState.IsValid)
            {

                var (successful, msg) = await _movieService.Edit(models, Id);

                if (successful)
                {

                    TempData["SuccessMsg"] = msg;

                    return RedirectToAction("Index");
                }

                // TempData["ErrMsg"] = msg; for both views and redirect to actions

                ViewBag.ErrMsg = msg;

                return View("New");

            }

            return View("New");

        }

    }
}

