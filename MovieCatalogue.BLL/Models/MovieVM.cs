using System;
using MovieCatalogue.DAL.Enums;
namespace MovieCatalogue.BLL.Models
{
    public class MovieVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public Rating Rating { get; set; }
        public Review Review { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImdbUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}

