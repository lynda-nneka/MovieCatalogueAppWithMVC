using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieCatalogue.DAL.Entities
{
    public class MovieCatalogueDbContext : IdentityDbContext<ApplicationUser>
    {

        public MovieCatalogueDbContext(DbContextOptions<MovieCatalogueDbContext> options) : base(options)
        {
        }



        public DbSet<Movies> Movies { get; set; }
    }
}
