using System;
using MovieCatalogue.DAL.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace MovieCatalogue.DAL.Entities
{
    public class Movies : BaseEntity
    {
        
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public Rating Rating { get; set; }
        public Review Review { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ImdbUrl { get; set; }
        public string ImageUrl { get; set; }

    }
}

