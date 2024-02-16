using Microsoft.EntityFrameworkCore;

namespace Mission6_Mitchell.Models
{
    public class MovieDataContext : DbContext
    {
        public MovieDataContext(DbContextOptions<MovieDataContext> options) : base(options)
        {

        }

        public DbSet<Form> Forms { get; set; }
    }
}
