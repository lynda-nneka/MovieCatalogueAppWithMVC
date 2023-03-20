using System;
using Microsoft.AspNetCore.Identity;

namespace MovieCatalogue.DAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}

