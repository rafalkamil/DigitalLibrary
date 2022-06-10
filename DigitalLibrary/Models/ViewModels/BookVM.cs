using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DigitalLibrary.Models.ViewModels
{
    public class BookVM
    {
        public Book Book { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> BookType { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> Category { get; set; }


        [ValidateNever]
        public IEnumerable<SelectListItem> Status { get; set; }
    }
}
