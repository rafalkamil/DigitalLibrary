﻿using System.ComponentModel.DataAnnotations;

namespace DigitalLibrary.Models
{
    public class BookType
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string? BookTypeName { get; set; }
    }
}
