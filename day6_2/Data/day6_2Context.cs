using Microsoft.EntityFrameworkCore;

public class day6_2Context(DbContextOptions<day6_2Context> options) : DbContext(options)
{
    public DbSet<day6_2.Models.Movie> Movie { get; set; } = default!;
}
