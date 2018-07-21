using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTOS
{
    public class MovieDTO
    {
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Complete this field")]
        public string Name { get; set; }
        
        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Select a Movie Genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Required(ErrorMessage = "Introduce the Release Date of the Movie")]
        public DateTime ReleaseDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy hh:mm:ss tt}")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Stock")]
        [Range(0, 20)]
        [Required(ErrorMessage = "Stock must be 0-20")]
        public int NumberInStock { get; set; }

        public int NumberAvailable { get; set; }
    }
}