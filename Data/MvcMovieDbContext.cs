using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{
public class MvcMovieDbContext : IdentityDbContext<User>
{
public MvcMovieDbContext (DbContextOptions<MvcMovieDbContext> options) : base(options)
{ }

public DbSet<Movie> Movies { get; set; }
}
}