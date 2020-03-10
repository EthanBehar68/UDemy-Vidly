using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UDemyVidly.Models;

namespace UDemyVidly.ViewModels
{
    // Example of:::Pure View Model:::
    // Replace Movie reference with all of its properties
    public class MovieFormViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter the movie's name.")]
        [StringLength(255)]
        public string Name { get; set; }


        [Required(ErrorMessage = "Please select the movie's genre.")]
        [Display(Name = "Genre")]
        public byte? GenreId { get; set; }

        [Required(ErrorMessage = "Please enter the movie's release date.")]
        [Display(Name = "Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Please enter how many are in stock.")]
        [Display(Name = "Number In Stock")]
        [Range(1, 20, ErrorMessage = "Please enter a number between 1 and 20.")]
        public byte? NumberInStock { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}