using Microsoft.EntityFrameworkCore;

public class Day6_1Context(DbContextOptions<Day6_1Context> options) : DbContext(options)
{
    public DbSet<Day6._1.Models.ProductModel> ProductModel { get; set; } = default!;
}
