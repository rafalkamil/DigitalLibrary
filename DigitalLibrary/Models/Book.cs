using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DigitalLibrary.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength]
        public string Author { get; set; }
        [ValidateNever]
        public int CategoryId { get; set; }
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public int BookTypeId { get; set; }
        [ValidateNever]
        public BookType BookType { get; set; }
        [ValidateNever]
        public int GradeId { get; set; }
        [ValidateNever]
        public Grade Grade { get; set; }
        public int StatusId { get; set; }
        [ValidateNever]
        public Status Status { get; set; }
        public string? Description { get; set; }
        public string? ImageURL { get; set; }
        public string? BookURL { get; set; }

    }
}
