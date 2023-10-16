using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace EcomApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
