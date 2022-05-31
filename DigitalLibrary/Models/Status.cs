using System.ComponentModel.DataAnnotations;

namespace DigitalLibrary.Models
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? StatusName { get; set; }

    }
}
