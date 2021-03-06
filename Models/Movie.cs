﻿using System;
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
        
        [Required]
        public string Name { get; set; }
        public Genre Genre { get; set; }

        [Display (Name = "Genre")]
        [Required]
        public int GenreId { get; set; }

        [Required]
        [Display (Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        [Display (Name = "Numbers In Stock")]
        [Range(1,20, ErrorMessage = "Number should be between 1 and 20!")]
        public int NumberInStock { get; set; }
    }
}