using System.ComponentModel.DataAnnotations;

namespace DigitalLibrary.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100, ErrorMessage = "Category Name is too long !")]
        public string CategoryName { get; set; }
    }
}
