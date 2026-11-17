using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Day6._1.Models
{
    public class ProductModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(100, MinimumLength =3, ErrorMessage = "Nhap ten 3 ki tu thoi")]
        public string name { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
}
