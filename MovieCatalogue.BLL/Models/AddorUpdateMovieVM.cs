using System;
using System.ComponentModel.DataAnnotations;
using MovieCatalogue.DAL.Enums;

namespace MovieCatalogue.BLL.Models
{
    public class AddorUpdateMovieVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "character limit of 3 and 50 is exceeded" ,MinimumLength = 2)]
        public string Title { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public Rating Rating { get; set; }

        [Required]
        public Review Review { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Imdb Link")]
        public string ImdbUrl { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Display(Name = "Poster")]
        public string ImageUrl { get; set; }
    }
}

