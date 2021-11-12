using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using YantoWorkshop.Models;

namespace YantoWorkshop.Data
{
    public class YantoWorkshopDbContext : IdentityDbContext<User>
    {
        public YantoWorkshopDbContext (DbContextOptions<YantoWorkshopDbContext> options) : base(options)
        { }
        public DbSet<Workshop> Workshops { get; set; }
        }
        
}