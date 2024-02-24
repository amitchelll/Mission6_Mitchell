

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission6_Mitchell.Models
{
    public class Movie
    {
        [Key] //Sets MovieID as the primary key and makes it required
        [Required]
        public int MovieId { get; set; }


        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        
        [Required(ErrorMessage ="You must enter a movie title!")]
        public string Title { get; set; }

        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be greater than or equal to 1888")]
        public int Year { get; set; }
        
        public string? Director { get; set; }
        
        public string? Rating { get; set; }

        [Required(ErrorMessage ="You must state if it has been edited")]
        public bool Edited { get; set; }
        public string? LentTo { get; set; }

        [Required(ErrorMessage ="You must fill out Copy To Plex")]
        public bool CopiedToPlex { get; set; }
        
        [StringLength(25)] //Limits the notes input to 25 characters (also implemented on the form itself)
        public string? Notes { get; set; }

    }
}
