using System.ComponentModel.DataAnnotations;

namespace DigitalLibrary.Models
{
    public class BookType
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string? BookTypeName { get; set; }
    }
}
