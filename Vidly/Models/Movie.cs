using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    // Standard CLR Object:
    // plain old CLR object (POCO) is a simple object created in the Common Language Runtime (CLR) of the .NET Framework which is unencumbered by inheritance or attributes.
    // https://en.wikipedia.org/wiki/Plain_old_CLR_object
    public class Movie
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        // [Required] - This caused an issue within Movies.Controller.Save b/c 
        // Genre = null but Required makes Entity reject null parameter so exception was thrown
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        public byte NumberInStock { get; set; }
    }
}