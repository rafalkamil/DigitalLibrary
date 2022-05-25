using System.ComponentModel.DataAnnotations;

namespace DigitalLibrary.Models
{
    public class Grade
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string? GradeName { get; set; }
    }
}
