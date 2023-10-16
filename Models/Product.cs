using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EcomApp.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [StringLength(255)] // Set the maximum length of the image file path or URL
        public string ImageFileName { get; set; }
       
        public virtual Category Category { get; set; } 
    }
}
