using System.ComponentModel.DataAnnotations;

namespace DigitalLibrary.Models
{
    public class Book
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength]
        public string Author { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TypeId { get; set; }
        public BookType Type { get; set; }
        public int GradeId { get; set; }
        public Grade Grade { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public string? BookURL { get; set; }

    }
}
