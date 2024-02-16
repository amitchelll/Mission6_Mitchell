

using System.ComponentModel.DataAnnotations;

namespace Mission6_Mitchell.Models
{
    public class Form
    {
        [Key] //Sets MovieID as the primary key and makes it required
        [Required]
        public int MovieID { get; set; }
        [Required] //Makes Category required
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Rating { get; set; }
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        
        [StringLength(25)] //Limits the notes input to 25 characters (also implemented on the form itself)
        public string Notes { get; set; }

    }
}
