using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MvcMovie.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Avatar { get; set; }

        public virtual List<Movie> Movies { get; set; }
    }
}