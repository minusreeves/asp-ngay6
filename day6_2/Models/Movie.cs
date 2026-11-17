using System.ComponentModel.DataAnnotations.Schema;

namespace day6_2.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int GenreId { get; set; }
    }
}
