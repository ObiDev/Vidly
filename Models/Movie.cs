using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        [Required]
        public Genre Genre { get; set; }

        [Display (Name = "Genre")]
        public int GenreId { get; set; }

        [Required]
        [Display (Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        [Display (Name = "Numbers In Stock")]
        public int NumberInStock { get; set; }
    }
}